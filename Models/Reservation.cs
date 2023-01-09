using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace proiect_mobile2.Models
{
    public class Reservation
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        [MaxLength(250), Unique]

        public string Name { get; set; }
        [Display(Name="Booking time:")]
        public DateTime Date { get; set; }

    }
}
