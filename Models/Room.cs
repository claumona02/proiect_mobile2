using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace proiect_mobile2.Models
{
    public class Room
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string RoomType { get; set; }
        [OneToMany]
        public List<ListRoom> ListRooms { get; set; }

    }
}
