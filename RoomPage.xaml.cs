using proiect_mobile2.Models;
namespace proiect_mobile2;

public partial class RoomPage : ContentPage
{
    Reservation sl;

    public RoomPage(Reservation slist)
    {
        InitializeComponent();
        sl = slist;

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var Room = (Room)BindingContext;
        await App.Database.SaveRoomAsync(Room);
        listView.ItemsSource = await App.Database.GetRoomsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var Room = (Room)BindingContext;
        await App.Database.DeleteRoomAsync(Room);
        listView.ItemsSource = await App.Database.GetRoomsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRoomsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Room p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Room;
            var lp = new ListRoom()
            {
                ReservationID = sl.ID,
                RoomID = p.ID
            };
            await App.Database.SaveListRoomAsync(lp);
            p.ListRooms = new List<ListRoom> { lp };
            await Navigation.PopAsync();
        }

    }
}