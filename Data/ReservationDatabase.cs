using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using proiect_mobile2.Models;


namespace proiect_mobile2.Data
{
    public class ReservationDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ReservationDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Reservation>().Wait();
            _database.CreateTableAsync<Room>().Wait();
            _database.CreateTableAsync<ListRoom>().Wait();

        }
        public Task<int> SaveRoomAsync(Room Room)
        {
            if (Room.ID != 0)
            {
                return _database.UpdateAsync(Room);
            }
            else
            {
                return _database.InsertAsync(Room);
            }
        }
        public Task<int> DeleteRoomAsync(Room Room)
        {
            return _database.DeleteAsync(Room);
        }
        public Task<List<Room>> GetRoomsAsync()
        {
            return _database.Table<Room>().ToListAsync();
        }
    


public Task<List<Reservation>> GetReservationsAsync()
        {
            return _database.Table<Reservation>().ToListAsync();
        }
        public Task<Reservation> GetReservationAsync(int id)
        {
            return _database.Table<Reservation>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveReservationAsync(Reservation slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteReservationAsync(Reservation slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveListRoomAsync(ListRoom listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Room>> GetListRoomsAsync(int Reservationid)
        {
            return _database.QueryAsync<Room>(
            "select P.ID, P.RoomType from Room P"
            + " inner join ListRoom LP"
            + " on P.ID = LP.RoomID where LP.ReservationID = ?",
            Reservationid);
        }
    }
}
