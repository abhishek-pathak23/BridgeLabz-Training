public interface IAppointmentService
{
    void BookAppointment();
    void CheckDoctorAvailability();
    void CancelAppointment();
    void RescheduleAppointment();
    void ViewDailySchedule();
}
