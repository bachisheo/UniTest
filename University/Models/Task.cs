using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class Task
    {
        public Task()
        {
            TaskInTest = new HashSet<TaskInTest>();
        }

        public int TaskPk { get; set; }
        public string Answers { get; set; }
        public string RightAnswer { get; set; }
        public int TopicPk { get; set; }
        public string Question { get; set; }
        public string Name { get; set; }

        public virtual Topic TopicPkNavigation { get; set; }
        public virtual ICollection<TaskInTest> TaskInTest { get; set; }
    }
}
