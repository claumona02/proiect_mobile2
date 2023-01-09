using System;
using proiect_mobile2.Data;
using System.IO;

namespace proiect_mobile2;


public partial class App : Application
{
    static ReservationDatabase database;
    public static ReservationDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               ReservationDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Reservation.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
