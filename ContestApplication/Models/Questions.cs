using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContestApplication.Models
{
    public class Questions
    {
        public string QId { get; set; }

        public string MId { get; set; }

        public string Question { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }

        public string Option4 { get; set; }

        public string CorrectOption { get; set; }
    }
}
