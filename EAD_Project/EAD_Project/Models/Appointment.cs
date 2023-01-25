using System;
using System.Collections.Generic;

namespace EAD_Project.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? Date { get; set; }
}
