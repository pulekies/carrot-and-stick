using System;

namespace Carrot_and_stick
{
    public class UserTask 
    {
        public String Name { get; set; }

        public bool HasDueDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool Complete { get; set; }


        private int tolerance;
        private int skippedDays;

        private bool taskPaused;

        public UserTask(String name)
        {
            Name = name;
        }
    }
}

