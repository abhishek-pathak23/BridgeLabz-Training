using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FundooNotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiDemoController : ControllerBase
{
    private readonly ITransientLifecycleService _transientDirect;
    private readonly IScopedLifecycleService _scopedDirect;
    private readonly ISingletonLifecycleService _singletonDirect;
    private readonly IDiLifecycleTracker _tracker;

    public DiDemoController(
        ITransientLifecycleService transientDirect,
        IScopedLifecycleService scopedDirect,
        ISingletonLifecycleService singletonDirect,
        IDiLifecycleTracker tracker)
    {
        _transientDirect = transientDirect;
        _scopedDirect = scopedDirect;
        _singletonDirect = singletonDirect;
        _tracker = tracker;
    }

    /// <summary>
    /// GET /api/DiDemo - Compare Transient, Scoped, and Singleton instance lifecycles
    /// </summary>
    [HttpGet]
    public IActionResult GetLifecycles()
    {
        return Ok(new
        {
            Transient = new
            {
                DirectId = _transientDirect.InstanceId,
                TrackerId = _tracker.TransientService.InstanceId,
                IsSame = _transientDirect.InstanceId == _tracker.TransientService.InstanceId,
                Behavior = "Re-created every injection (Direct != Tracker)"
            },
            Scoped = new
            {
                DirectId = _scopedDirect.InstanceId,
                TrackerId = _tracker.ScopedService.InstanceId,
                IsSame = _scopedDirect.InstanceId == _tracker.ScopedService.InstanceId,
                Behavior = "Shared within same request (Direct == Tracker)"
            },
            Singleton = new
            {
                DirectId = _singletonDirect.InstanceId,
                TrackerId = _tracker.SingletonService.InstanceId,
                IsSame = _singletonDirect.InstanceId == _tracker.SingletonService.InstanceId,
                Behavior = "Shared across entire application lifetime"
            }
        });
    }
}
