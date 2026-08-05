using System.Collections.Generic;
using System.Data;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Interface
{
    public interface IVisitHistoryService
    {
        List<VisitHistory> GetPatientVisitHistory(int patientId);
        DataTable GetPatientAuditLogs();
        DataTable GetAppointmentAuditLogs();
    }
}
