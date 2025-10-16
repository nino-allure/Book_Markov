using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Markov.Classes
{
    public class Author
    {
        // Код автора
        public int Id { get; set; }

        // ФИО автора
        public string FIO { get; set; }

        // Конструктор автора
        public Author(int Id, string FIO)
        {
            this.Id = Id;
            this.FIO = FIO;
        }

        // Репозиторий авторов
        public static List<Author> AllAuthors()
        {
            // Создаём список авторов
            List<Author> allAuthors = new List<Author>();

            // Заполняем список
            allAuthors.Add(new Author(1, "Виктор Пелевин"));
            allAuthors.Add(new Author(2, "Александра Маринина"));
            allAuthors.Add(new Author(3, "Ольга Герр"));

            // Возвращаем список
            return allAuthors;
        }
    }
}
