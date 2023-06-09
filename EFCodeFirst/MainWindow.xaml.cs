using EFCodeFirst.DataAccess;
using EFCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace EFCodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryContext _context = new LibraryContext();
        public MainWindow()
        { 
            InitializeComponent();
            _context.Database.CreateIfNotExists();

          LoadCategories();
          LoadAuthors();
          LoadBooks();
        }

        private async void LoadBooks()
        {
            if (_context.Books.Count() == 0)
            {
                await AddBooksAsync();
            }

            var books = await _context.Books.ToListAsync();
            booksGrid.ItemsSource = books;
        }

        private async Task AddBooksAsync()
        {
            _context.Books.Add(new Book
            {
                AuthorId = 1,
                CategoryId = 1,
                Pages = 100,
                Name = "My Best Book"
            });
            await _context.SaveChangesAsync();
        }

        public async void LoadAuthors()
        {
            if (_context.Authors.Count() == 0)
            {
                await AddAuthorsAsync();
            }
           
            var authors = await _context.Authors.ToListAsync();
            authorsGrid.ItemsSource=authors;
        }

        private async Task AddAuthorsAsync()
        {
            _context.Authors.Add(new Author
            {
                Firstname="Linus",
                Lastname="Torvalds",
                Age=35
            });

            _context.Authors.Add(new Author
            {
                Firstname = "Leyla",
                Lastname = "Mammadli",
                Age = 35
            });

            _context.Authors.Add(new Author
            {
                Firstname = "Axmed",
                Lastname = "Axmedli",
                Age = 35
            });

            await _context.SaveChangesAsync();
        }

        public async void LoadCategories()
        {
            if (_context.Categories.Count() == 0)
            {
                await AddCategoriesAsync();
            }
            var categories=await _context.Categories.ToListAsync();
            categoryGrid.ItemsSource = categories;
        }

        public async Task AddCategoriesAsync()
        {
            _context.Categories.Add(new Category
            {
                Name="Adventure"
            });

            _context.Categories.Add(new Category
            {
                Name = "Sci-Fi"
            });

            _context.Categories.Add(new Category
            {
                Name="Programming"
            });

            await _context.SaveChangesAsync();
        }

    }
}
