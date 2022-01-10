using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class Admin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int AdminPk { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronimyc { get; set; }
    }
}
