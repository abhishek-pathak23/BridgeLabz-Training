namespace BusinessLayer.Interface;

public interface ILifecycleService
{
    Guid InstanceId { get; }
    string LifetimeName { get; }
    DateTime CreatedAtUtc { get; }
}

public interface ITransientLifecycleService : ILifecycleService
{
}

public interface IScopedLifecycleService : ILifecycleService
{
}

public interface ISingletonLifecycleService : ILifecycleService
{
}

public record LifecycleSnapshotDto(
    string Lifetime,
    Guid DirectInstanceId,
    Guid TrackerInstanceId,
    bool IsSameInstanceAcrossServices,
    DateTime CreatedAtUtc
);

public record DiDiagnosticReportDto(
    string RequestScopeId,
    DateTime TimestampUtc,
    LifecycleSnapshotDto Transient,
    LifecycleSnapshotDto Scoped,
    LifecycleSnapshotDto Singleton,
    string Explanation
);

public interface IDiLifecycleTracker
{
    Guid ScopeId { get; }
    ITransientLifecycleService TransientService { get; }
    IScopedLifecycleService ScopedService { get; }
    ISingletonLifecycleService SingletonService { get; }
    DiDiagnosticReportDto GenerateReport(
        ITransientLifecycleService directTransient,
        IScopedLifecycleService directScoped,
        ISingletonLifecycleService directSingleton
    );
}
