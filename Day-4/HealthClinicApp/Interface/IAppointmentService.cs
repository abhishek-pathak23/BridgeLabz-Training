using System;
using System.Collections.Generic;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Interface
{
    public interface IAppointmentService
    {
        int BookAppointment(int patientId, int doctorId, DateTime date);
        List<Appointment> GetAllAppointments();
        bool UpdateAppointmentStatus(int appointmentId, string newStatus);
        bool CancelAppointment(int appointmentId);
        List<Appointment> GetAppointmentsByDoctorId(int doctorId);
        List<Appointment> GetAppointmentsByPatientId(int patientId);
    }
}
