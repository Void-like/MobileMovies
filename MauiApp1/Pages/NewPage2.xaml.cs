using MauiApp1.DB;
using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MauiApp1.Pages;
public partial class NewPage2 : ContentPage
{
    DBFile db = new DBFile();
   Movies SelectedMovies = new Movies();
    Author SelectedAuthor = new Author();
    

    public NewPage2()
	{
        InitializeComponent();
        Tablichka();
    }
    public async void SaveAuthor()
    {
        await db.ListMoviesAdd(SelectedAuthor.Id, SelectedMovies.Id);

        Tablichka();
    }
    
    public async void Tablichka()
    {
        PickerAuthor.ItemsSource = await db.GetAuthorList();
        PickerMovie.ItemsSource = await db.GetMovieList();
        tablichka.ItemsSource = await db.GetMovieAuthorList();
        OnPropertyChanged(nameof(db.GetMovieAuthorList));
        OnPropertyChanged(nameof(db.GetMovieList));
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private void Button_Clicked_Save(object sender, EventArgs e)
    {
        SaveAuthor();
    }
    private async void OnChangeClicked(object sender, EventArgs e)
    {

        if (SelectedMovies != null)
        {
            
        }
        else
        {
            await DisplayAlert("ОШИБКА МОЛОДОСТИ", "Не выбран айтем", "Емае");
        }
        Tablichka();
    }
   
    private async void OnDeleteClicked(object sender, EventArgs e)
    {

        if (SelectedMovies != null)
        {
           

        }
        else
        {
            await DisplayAlert("ОШИБКА МОЛОДОСТИ", "Не выбран айтем", "Емае");
        }
        Tablichka();
    }
}