using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Book_Markov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<Classes.Author> AllAuthors = Classes.Author.AllAuthors();

        // <summary> Все жанры </summary>
        List<Classes.Genre> AllGenres = Classes.Genre.AllGenres();

        // <summary> Все книги </summary>
        List<Classes.Book> AllBooks = Classes.Book.AllBook();
        public MainWindow()
        {
            InitializeComponent();
            AddAuthors();
            AddGenres();
            AddYears();
            CreateUI(AllBooks);
        }
        void CreateUI(List<Classes.Book> AllBooks)
        {
            // Очищаем холст
            parent.Children.Clear();

            // Перебираем книги
            foreach (Classes.Book Book in AllBooks)
            {
                // Добавляем элемент в StackPanel
                parent.Children.Add(new Elements.Element(Book));
            }
        }

        private void Search_Book(object sender, KeyEventArgs e)
        {
            Search();
        }

        private void SelectAuthor(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        /// <summary>Метод поиска и сортировки</summary>
        public void Search()
        {
            // Ищем книги при поиске
            List<Classes.Book> FindBook = AllBooks.FindAll(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower()));

            // Если выбран автор
            if (cbAuthors.SelectedIndex > 0)
            {
                // Ищем выбранного автора
                Classes.Author SelectAuthor = AllAuthors.Find(x => x.FIO == cbAuthors.SelectedItem.ToString());
                // Ищем выбранные книги
                FindBook = FindBook.FindAll(x => x.Authors.Find(y => y.Id == SelectAuthor.Id) != null);
            }

            // Если выбран жанр
            if (cbGenres.SelectedIndex > 0)
            {
                // Ищем выбранный жанр
                Classes.Genre SelectGenre = AllGenres.Find(x => x.Name == cbGenres.SelectedItem.ToString());
                // Ищем выбранные книги
                FindBook = FindBook.FindAll(x => x.Genres.Find(y => y.Id == SelectGenre.Id) != null);
            }

            // Если выбран год
            if (cbYear.SelectedIndex > 0)
            {
                // Ищем выбранные книги по году
                FindBook = FindBook.FindAll(x => x.Year == Convert.ToInt32(cbYear.SelectedItem.ToString()));
            }

            // Генерируем интерфейс
            CreateUI(FindBook);
        }
        
        
        
        
        
        
        
        
        
        
        public void AddAuthors()
        {
            cbAuthors.Items.Add("Выберите ...");
            foreach (Classes.Author Author in AllAuthors)
            {
                cbAuthors.Items.Add(Author.FIO);
            }
        }
        public void AddGenres()
        {
            cbGenres.Items.Add("Выберите ...");
            foreach (Classes.Genre Genre in AllGenres)
            {
                cbGenres.Items.Add(Genre.Name);
            }
        }
        public void AddYears()
        {
            cbYear.Items.Add("Выберите ... ");
            List<int> AllYears = new List<int>();
            foreach (Classes.Book Book in AllBooks)
            {
                if (AllYears.Find(x => x == Book.Year) == 0)
                {
                    AllYears.Add(Book.Year);
                    cbYear.Items.Add(Book.Year);
                }
            }
        }
    }
}
