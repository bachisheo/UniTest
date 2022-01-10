using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Task = new HashSet<Task>();
        }

        public int TopicPk { get; set; }
        public string Name { get; set; }
        public int DisciplinePk { get; set; }

        public virtual Discipline DisciplinePkNavigation { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
