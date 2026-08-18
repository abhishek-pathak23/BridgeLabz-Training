using BusinessLayer.Interface;

namespace BusinessLayer.Service;

public class TransientLifecycleService : ITransientLifecycleService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
    public string LifetimeName => "Transient (New instance created every time requested)";
    public DateTime CreatedAtUtc { get; } = DateTime.UtcNow;
}

public class ScopedLifecycleService : IScopedLifecycleService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
    public string LifetimeName => "Scoped (Created once per client HTTP request scope)";
    public DateTime CreatedAtUtc { get; } = DateTime.UtcNow;
}

public class SingletonLifecycleService : ISingletonLifecycleService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
    public string LifetimeName => "Singleton (Created once for application lifetime)";
    public DateTime CreatedAtUtc { get; } = DateTime.UtcNow;
}

public class DiLifecycleTracker : IDiLifecycleTracker
{
    public Guid ScopeId { get; } = Guid.NewGuid();
    public ITransientLifecycleService TransientService { get; }
    public IScopedLifecycleService ScopedService { get; }
    public ISingletonLifecycleService SingletonService { get; }

    public DiLifecycleTracker(
        ITransientLifecycleService transientService,
        IScopedLifecycleService scopedService,
        ISingletonLifecycleService singletonService)
    {
        TransientService = transientService;
        ScopedService = scopedService;
        SingletonService = singletonService;
    }

    public DiDiagnosticReportDto GenerateReport(
        ITransientLifecycleService directTransient,
        IScopedLifecycleService directScoped,
        ISingletonLifecycleService directSingleton)
    {
        var transientSnapshot = new LifecycleSnapshotDto(
            Lifetime: "Transient",
            DirectInstanceId: directTransient.InstanceId,
            TrackerInstanceId: TransientService.InstanceId,
            IsSameInstanceAcrossServices: directTransient.InstanceId == TransientService.InstanceId,
            CreatedAtUtc: directTransient.CreatedAtUtc
        );

        var scopedSnapshot = new LifecycleSnapshotDto(
            Lifetime: "Scoped",
            DirectInstanceId: directScoped.InstanceId,
            TrackerInstanceId: ScopedService.InstanceId,
            IsSameInstanceAcrossServices: directScoped.InstanceId == ScopedService.InstanceId,
            CreatedAtUtc: directScoped.CreatedAtUtc
        );

        var singletonSnapshot = new LifecycleSnapshotDto(
            Lifetime: "Singleton",
            DirectInstanceId: directSingleton.InstanceId,
            TrackerInstanceId: SingletonService.InstanceId,
            IsSameInstanceAcrossServices: directSingleton.InstanceId == SingletonService.InstanceId,
            CreatedAtUtc: directSingleton.CreatedAtUtc
        );

        var explanation = "DI Lifecycle Behavior: Transient services are recreated every time injected (Direct != Tracker). " +
                          "Scoped services share the same instance within the same HTTP request (Direct == Tracker). " +
                          "Singleton services share the single instance across all requests and throughout the whole application lifecycle.";

        return new DiDiagnosticReportDto(
            RequestScopeId: ScopeId.ToString(),
            TimestampUtc: DateTime.UtcNow,
            Transient: transientSnapshot,
            Scoped: scopedSnapshot,
            Singleton: singletonSnapshot,
            Explanation: explanation
        );
    }
}
