using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class ListMovies 
    {
        public int Id { get; set; } 
        public int IdAuthor { get; set; }
        public int IdMovies { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }

    }
}
