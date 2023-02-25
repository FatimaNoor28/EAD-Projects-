using System;
using System.Collections.Generic;

namespace eadProject.Models;


    public partial class Doctor : FullAudinModel
{
    public int DoctorId { get; set; }

    public string CNIC { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? AppointmentId { get; set; }
    public int? CurrentAppointments { get; set; }

    public int? ApointmentLimitPerDay { get; set; }
}
