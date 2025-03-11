using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DailyTask
    {
        public int Id { get; set; }
        public string? Start { get; set; }
        public string? End { get; set; }
        public string? Task { get; set; }
        public DateTime Date { get; set; }
    }
}
