using System;
using System.Collections.Generic;

namespace EAD_Project.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public int? Appointments { get; set; }

    public int? ApointmentLimit { get; set; }
}
