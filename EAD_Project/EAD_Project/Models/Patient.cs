using System;
using System.Collections.Generic;

namespace EAD_Project.Models;

public partial class Patient
{
    public int Id { get; set; }
    public string CNIC { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

}
