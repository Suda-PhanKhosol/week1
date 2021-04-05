using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using week1.Models;

namespace week1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string name)
        {
            var result = "Hello" + name;
            return Ok(result);
        }

        [HttpGet("GetBooks")]
        public IActionResult GetBooks(int count)
        {
            var bookListx = new List<Book>();

            //shorthand
            bookListx.Add(new Book() { Id = 1, Name = "Salmon", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 2, Name = "Berger", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 3, Name = "Salad", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 4, Name = "Stake", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 5, Name = "Mango", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 6, Name = "Banan", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 7, Name = "Orange", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 8, Name = "Orange", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 9, Name = "Orange", Price = 20, CreatedDate = DateTime.Now });


            //1. เก็บไว้ก่อน
            var baconBook = new Book()
            {
                Id = 10,
                Name = "Bacon",
                Price = 20,
                CreatedDate = DateTime.Now
            };
            //2. Add เข้า
            bookListx.Add(baconBook);

            return Ok(bookListx);
        }

        [HttpGet("SearchBook")]
        public IActionResult SearchBook(string searchText)
        {
            var bookListx = new List<Book>();

            bookListx.Add(new Book() { Id = 1, Name = "Salmon", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 2, Name = "Berger", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 3, Name = "Salad", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 4, Name = "Stake", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 5, Name = "Mango", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 6, Name = "Banan", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 7, Name = "Orange", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 8, Name = "Orange", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 9, Name = "Orange", Price = 20, CreatedDate = DateTime.Now });
            bookListx.Add(new Book() { Id = 10, Name = "Tomato", Price = 20, CreatedDate = DateTime.Now });
            //search SQL Like use Tolist because multi object
            var searchResult = bookListx.Where(x => x.Name.Contains(searchText)).ToList();

            //search SQL Like use First เอาตัวแรก
            var searchResultFirst = bookListx.Where(x => x.Name.Contains(searchText)).First();

            return Ok(searchResultFirst);
        }

        [HttpPost("PostFromModel")]
        public IActionResult PostFromModel(Book input)
        {
            var result = input;
            return Ok(result);
        }

        [HttpGet("Tests")]
        public IActionResult Tests()
        {
            return Ok("result");
        }

        [HttpGet("Now")]
        public IActionResult GetNow()
        {
            var result = DateTime.Now;
            return Ok(result);
        }

        [HttpGet("News")]
        public IActionResult GetNews(string name)
        {
            var result = "Hello" + name;
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(int id, string name)
        {
            var result = id.ToString() + name;
            // var a =0;
            // var b =0;
            // var resault = a/b;
            return Ok(result);
            //return Create(resault);
        }

        [HttpPost("CalAvgs")]
        public IActionResult CalAvg(decimal math, decimal eng, decimal sci)
        {
            decimal avg = (math + eng + sci) / 3;
            var result = "Avg = " + avg.ToString("F");
            return Ok(result);
        }

        [HttpPost("ConvertCDates")]
        public IActionResult ConvertCDates(string date)
        {
            //start,length
            string d = date.Substring(0, 2);
            string m = date.Substring(3, 2);
            string y = date.Substring(6, 4);
            DateTime dt = new DateTime(Int32.Parse(y), Int32.Parse(m), Int32.Parse(d));

            return Ok(String.Format("{0:d MMMM  yyyy}", dt));
        }

        [HttpPost("ConvertPDates")]
        public IActionResult ConvertPDates(string date)
        {
            //start,length
            string d = date.Substring(0, 2);
            string m = date.Substring(3, 2);
            string y = date.Substring(6, 4);
            int newY = Int32.Parse(y) - 543;
            DateTime dt = new DateTime(newY, Int32.Parse(m), Int32.Parse(d));

            return Ok(String.Format("{0:d MMMM  yyyy}", dt) + newY);
        }
        [HttpPost("CalGrades")]
        public IActionResult CalGrade(decimal math, decimal eng, decimal sci)
        {
            decimal avg = (math + eng + sci) / 3;
            string grade = "";
            if (avg >= 80 && avg < 100)
            {
                grade = "A";
            }
            else if (avg >= 60 && avg <= 79)
            {
                grade = "B";
            }
            else if (avg >= 40 && avg <= 59)
            {
                grade = "C";
            }
            else if (avg <= 39)
            {
                grade = "D";
            }

            var result = "Grade = " + grade;
            return Ok(result);
        }

        [HttpPost("CalSqaures")]
        public IActionResult CalSqaures(decimal width, decimal height)
        {
            decimal area = width * height;
            var result = "Area = " + area;
            return Ok(result);
        }

    }
}