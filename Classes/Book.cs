using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Markov.Classes
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }   
        public Book( int Id, string Name, List<Genre> genres, List<Author> Authors, int Year )
        {
            this.Id = Id;
            this.Name = Name;
            this.Genres = Genres;
            this.Authors = Authors;
            this.Year = Year;
        }
        public static List<Book> AllBook()
        {
            List<Book> allBook = new List<Book>();
            allBook.Add(new Book(
                1, "Whole Lotta Red",
                Genre.AllGenres().FindAll(x => x.Id == 1),
                Author.AllAuthors().FindAll(x => x.Id == 1), 2021));
            allBook.Add(new Book(
                2, "Finnaly Rich",
                Genre.AllGenres().FindAll(x => x.Id == 1),
                Author.AllAuthors().FindAll(x => x.Id == 1), 2013));
            allBook.Add(new Book(
                3, "Dirty Sprite 2",
                Genre.AllGenres().FindAll(x => x.Id == 2),
                Author.AllAuthors().FindAll(x => x.Id == 2), 2015));
            allBook.Add(new Book(
                4, "E",
                Genre.AllGenres().FindAll(x => x.Id == 2),
                Author.AllAuthors().FindAll(x => x.Id == 2), 2021));
            allBook.Add(new Book(
                5, "Cold Visions",
                Genre.AllGenres().FindAll(x => x.Id == 2 || x.Id == 3 || x.Id == 4),
                Author.AllAuthors().FindAll(x => x.Id == 3), 2024));
            return allBook;
        }
        public string ToGenres()
        {
            string ToGenres = "";
            for (int iGenre = 0; iGenre < Genres.Count; iGenre++)
            {
                ToGenres += this.Genres[iGenre].Name;
                if (iGenre < Genres.Count - 1)
                    ToGenres += ", ";
            }
            return ToGenres;
        }
        public string ToAuthors()
        {
            string toAuthors = "";
            for (int iAuthor = 0; iAuthor < this.Authors.Count; iAuthor++)
            {
                toAuthors += this.Authors[iAuthor].FIO;
                if (iAuthor < this.Authors.Count - 1)
                    { toAuthors += ", "; }
            }
            return toAuthors;
        }
    }
}
