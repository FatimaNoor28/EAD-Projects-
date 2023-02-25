using eadProject.Models;
using System;
using System.Collections.Generic;

namespace eadProject.Models
{

    public partial class Admin : FullAudinModel
    {
        public int AdminId { get; set; }

        public string? Name { get; set; }
        public string? CNIC { get; set; }

        public string? Password { get; set; }
    }

}