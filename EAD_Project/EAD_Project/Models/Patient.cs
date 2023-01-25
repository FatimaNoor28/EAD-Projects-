using System;
using System.Collections.Generic;

namespace EAD_Project.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? Name { get; set; }

    public string? Cnic { get; set; }

    public string? PhoneNo { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public int? AppointmentId { get; set; }
}
