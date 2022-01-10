using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            StudyPlan = new HashSet<StudyPlan>();
        }

        public int SpecialityPk { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudyPlan> StudyPlan { get; set; }
    }
}
