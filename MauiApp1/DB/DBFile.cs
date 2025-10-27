using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace MauiApp1.DB
{
    public class DBFile
    {
        private List<Author> authorList  = new List<Author>();
        private List<Movies> moviesList  = new List<Movies>();
        private  List<ListMovies> listMovies = new List<ListMovies>();
        private List<int> ints = new List<int> { 0,0,0};






        public DBFile()
        {
            LoadDis();

        } 



        public async Task ListMoviesAdd(int idAuthor,int idMovies)
        {
            ListMovies movies = new ListMovies();
            movies.Id = ints[2];
          
            foreach (Movies author in moviesList)
            {
                if (author.Id == idAuthor)
                {
                    movies.Title = author.Name;
                }
            }
            foreach (Author moviesik in authorList)
            {
                if (moviesik.Id == idMovies)
                {
                    movies.FirstName = moviesik.Name;
                    movies.SecondName = moviesik.SecondName;
                    movies.LastName = movies.LastName;
                }
            }
            listMovies.Add(movies);
            await SaveFileListMovie();
            await SaveFileDiscriminant();
            ints[2] = ints[2] + 1;
        }

        public async Task ListMoviesChange(int id ,int idAuthor, int idMovies)
        {
            ListMovies movies = new ListMovies();
            movies.Id = id;
            movies.Title = moviesList[idMovies].Name;
            movies.FirstName = authorList[idAuthor].Name;
            movies.SecondName = authorList[idAuthor].SecondName;
            movies.LastName = authorList[idAuthor].ThrityName;
            int a = 0;
            int b = 0;
            foreach (ListMovies author in listMovies)
            {

                if (author.Id == id)
                {

                    b = a;
                }
                a++;

            }
            listMovies[b] = movies;
            await SaveFileListMovie();
     
        }
        public async Task ListMoviesDel(int id)
        {
            int a = 0;
            int b = 0;
            await Task.Delay(1000);
            foreach (ListMovies author in listMovies)
            {
                if (author.Id == id)
                {
                    b = a;
                }
                a++;
            }
            moviesList.RemoveAt(b);
            await SaveFileListMovie();

        }
        public async Task ChangeMovie(int id, string name,string description ,DateTime date)
        {
            Movies movies = new Movies();
            movies.Id = id;
            movies.Name = name;
            movies.Description = description;
            movies.Date = date;
            int a = 0;
            int b = 0;
            foreach (Movies author in moviesList) 
            {

                if (author.Id == id)
                {
                    
                    b = a;
                }
            a++;
            
            }
            moviesList[b] = movies;
            await SaveFileMovie();
            
        }
        public async Task ChangeAuthor(int id, string name, string secondName,string thrityName, DateTime birthDay)
        {
            int a = 0;
            int b = 0;
            Author authors = new Author();
            authors.Id = id;
            authors.Name = name;
            authors.SecondName = secondName;
            authors.BirthDay = birthDay;
            authors.ThrityName = thrityName;
            foreach (Author author in authorList)
            {

                if (author.Id == id)
                {
                    b = a;
                }
                a++;

            }
            authorList[b] = authors;
            await SaveFileAuthor();
        }
        public async void LoadDis()
        {
         
            await  LoadDiscriminant();
            await LoadFileAuthor();
            await LoadFileMovie();
        }

        public async Task SaveFileDiscriminant()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "discriminant.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, ints);
            }
            LoadDis();
        }
        public async Task LoadDiscriminant()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "discriminant.db");
            if (File.Exists(targetFile))
            {
                string a = await File.ReadAllTextAsync(targetFile);
                ints = JsonSerializer.Deserialize<List<int>>(a);

            }

        }

        public  async Task<IReadOnlyList<Author>> GetAuthorList()
        {
         await Task.Delay(1000);
         return authorList;

        }
        public async  Task<IReadOnlyList<Movies>> GetMovieList()
        {
            await Task.Delay(1000);
            return moviesList;

        }
        public async Task<IReadOnlyList<ListMovies>> GetMovieAuthorList()
        {
            await Task.Delay(1000);
            return listMovies;

        }

        public async Task DelAuthor(int id)
        {
            int a = 0;
            int b = 0;
            await Task.Delay(1000);
            foreach (Author author in authorList)
            {
                if (author.Id == id)
                {
                    b = a;
                }
                a++;
            }
            authorList.RemoveAt(b);
            await SaveFileAuthor();
        }
        public async Task DelMovie(int id)
        {
            
            int a = 0;
            int b = 0;
            await Task.Delay(1000);
            foreach (Movies author in moviesList)
            {

                if (author.Id == id)
                {

                    b = a;
                }
                a++;

            }
            moviesList.RemoveAt(b);
            await SaveFileMovie();
        }
        public async Task DelAuthorMovies(int id)
        {
            foreach (ListMovies author in listMovies)
            {
                if (author.Id == id)
                {
                    listMovies.Remove(author);
                }
            }
        }

        public async Task AddAuthor(string name,string secondName,string thrityName,DateTime birthDay)
        {
            Author author = new Author();
            author.Id = ints[0];
            author.Name = name;
            author.SecondName = secondName;
            author.ThrityName = thrityName;
            author.BirthDay = birthDay;
            authorList.Add(author);
            ints[0] = ints[0]+1;
            await SaveFileDiscriminant();
            await SaveFileAuthor();
        }
        public async Task AddMovies(string name ,string description,DateTime date)
        {
            Movies movies = new Movies();
            movies.Id = ints[1];
            movies.Name = name;
            movies.Description = description;
            movies.Date = date;
            moviesList.Add(movies);
            ints[1] = ints[1] + 1;
            await SaveFileDiscriminant();
            await SaveFileMovie();
        }
        public async Task AddMoviesList(int IdAuthor,int IdMovies, string Title,string FirstName,string LastName, string SecondName)
        {

            ListMovies listMoviesAdd = new ListMovies();
            listMoviesAdd.Id = ints[2];
            listMoviesAdd.IdAuthor = IdAuthor;
            listMoviesAdd.IdMovies = IdMovies;
            listMoviesAdd.Title = Title;
            listMoviesAdd.FirstName = FirstName;
            listMoviesAdd.LastName = LastName;
            listMoviesAdd.SecondName = SecondName;

            listMovies.Add(listMoviesAdd);
            ints[2] = ints[2] + 1;
            await SaveFileDiscriminant();
            await SaveFileListMovie();


        }

        public  async Task SaveFileMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, moviesList);
            }
            LoadDis();
        }

        public async Task LoadFileMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            if (File.Exists(targetFile))
            {
                string a = await File.ReadAllTextAsync(targetFile);
                moviesList = JsonSerializer.Deserialize<List<Movies>>(a);
                
            }
            
        }
        public async Task SaveFileListMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "listmovie.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, listMovies);
            }
            LoadDis();
        }

        public async Task LoadFileListMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "listmovie.db");
            if (File.Exists(targetFile))
            {
                string a = await File.ReadAllTextAsync(targetFile);
                listMovies = JsonSerializer.Deserialize<List<ListMovies>>(a);

            }

        }
        public async Task SaveFileAuthor()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, authorList);
            }
            LoadDis();
        }
        public async Task LoadFileAuthor()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
            if (File.Exists(targetFile))
            {
                string a = await File.ReadAllTextAsync(targetFile);

                authorList =  JsonSerializer.Deserialize<List<Author>>(a);

            }
       
        }
    
    }




}
