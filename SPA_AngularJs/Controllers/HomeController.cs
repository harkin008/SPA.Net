using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPA_AngularJs.Models;

namespace SPA_AngularJs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBooks()
        {
            using(bookDBContext contDB= new bookDBContext()){
                var bookList = contDB.books.ToList();
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetBookById(string id)
        {
            using (bookDBContext contDB = new bookDBContext()) {
                var bookId = Convert.ToInt32(id);
                var getBook = contDB.books.Find(bookId);

                return Json(getBook, JsonRequestBehavior.AllowGet);
                           
            }

        }

        public string updateBook(book bk)
        {
            if (bk != null)
            {
                using (bookDBContext contDB = new bookDBContext())
                {
                    int bookId = Convert.ToInt32(bk.Id);
                    book _book = contDB.books.Where(a => a.Id == bookId).FirstOrDefault();
                    _book.Title = bk.Title;
                    _book.publisher = bk.publisher;
                    _book.Isbn = bk.Isbn;
                    contDB.SaveChanges();

                    return "book updated successfully";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }


        public string AddBook(book bk)
        {
            if (bk != null)
            {
                using (bookDBContext contDB = new bookDBContext())
                {
                    contDB.books.Add(bk);
                    contDB.SaveChanges();

                    return  "Book saved successfully";    
                }
            }
            else
            {
                return "Invalid book record";
            }
        }

        public string DeleteBook(string bookId)
        {
            if(!string.IsNullOrEmpty(bookId))
            {
                try
                {
                    int _bookId = Int32.Parse(bookId);
                    using (bookDBContext contDB = new bookDBContext())
                    {
                        var _book = contDB.books.Find(_bookId);
                        contDB.books.Remove(_book);
                        contDB.SaveChanges();
                        return "Book deleted successfully";

                    }
                }
                catch (Exception)
                {
                    return "Book details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}