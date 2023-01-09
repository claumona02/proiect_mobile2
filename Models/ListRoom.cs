using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace proiect_mobile2.Models
{
    public class ListRoom
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Reservation))]
        public int ReservationID { get; set; }
        public int RoomID { get; set; }

    }
}
