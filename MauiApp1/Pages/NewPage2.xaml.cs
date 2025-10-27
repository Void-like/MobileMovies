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
   ListMovies SelectedMovies = new ListMovies();

    

    public NewPage2()
	{
        InitializeComponent();
        
    }
    public async Task SaveAuthor()
    {
       await db.ListMoviesAdd(int.Parse(AuthorId.Text),int.Parse(MovieId.Text));
       
        Tablichka();
    }
    
    public async void Tablichka()
    {

        tablichka.ItemsSource = await db.GetMovieAuthorList();
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
            await db.DelAuthorMovies(SelectedMovies.Id);

        }
        else
        {
            await DisplayAlert("ОШИБКА МОЛОДОСТИ", "Не выбран айтем", "Емае");
        }
        Tablichka();
    }
}