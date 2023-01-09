using proiect_mobile2.Models;
namespace proiect_mobile2;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Reservation)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveReservationAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Reservation)BindingContext;
        await App.Database.DeleteReservationAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoomPage((Reservation)
       this.BindingContext)
        {
            BindingContext = new Room()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Reservation)BindingContext;

        listView.ItemsSource = await App.Database.GetListRoomsAsync(shopl.ID);
    }


}