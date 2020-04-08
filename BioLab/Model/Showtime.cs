using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BioLab
{
    public class Showtime
    {
        [Key]
        public Guid Id { get; set; }
        public virtual Movie ShowtimeMovie { get; set; }
        public int NumOfSeats { get; set; }
        public DateTime ShowtimeDate { get; set; }
        public int NumberOfBookedSeats { get; set; }

    }
}
