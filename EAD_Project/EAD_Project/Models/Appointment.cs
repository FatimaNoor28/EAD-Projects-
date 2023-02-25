using System;
using System.Collections.Generic;

namespace EAD_Project.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public string? DoctorName { get; set; }

    public int? PatientId { get; set; }

    public int  Date { get; set; }

    public int Month { get; set; }

    public string time { get; set; }

    public string? PhoneNo { get; set; }


}
