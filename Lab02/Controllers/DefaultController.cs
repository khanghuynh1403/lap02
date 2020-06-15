using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;


namespace Lab02.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML 5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/book1cover.jpg"));
            books.Add(new Book(2, "HTML 5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/images/book3cover.jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML 5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/book1cover.jpg"));
            books.Add(new Book(2, "HTML 5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/images/book3cover.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.ID==id)
                {
                    book = b;
                    break;
                }
            }
            if(book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact1(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML 5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/book1cover.jpg"));
            books.Add(new Book(2, "HTML 5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/images/book3cover.jpg"));
            foreach (Book b in books)
            {
                if (b.ID == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_Cover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel",books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact2([Bind(Include ="Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML 5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/book1cover.jpg"));
            books.Add(new Book(2, "HTML 5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/images/book3cover.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch(RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save data");
            }
            return View("ListBookModel", books);
        }
    }
}