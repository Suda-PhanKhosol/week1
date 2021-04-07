using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using week1.Data;
using week1.DTOs;
using week1.Models;

namespace week1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;

        public BooksController(AppDBContext db,IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }
        [HttpGet("GetBooks")]
        public IActionResult GetBooks()
        {
            var bookListx = _db.Books.ToList();
            return Ok(_mapper.Map<List<BookDTO_ToReturnAddBook>>(bookListx));
        }

        [HttpGet("SearchBook")]
        public IActionResult SearchBook(string searchText)
        {
            var bookListx = _db.Books.ToList();
            //search SQL Like use Tolist because multi object
            var searchResult = bookListx.Where(x => x.Name.Contains(searchText)).ToList();

            //search SQL Like use First เอาตัวแรก
            var searchResultFirst = bookListx.Where(x => x.Name.Contains(searchText)).First();

            return Ok(_mapper.Map<List<BookDTO_ToReturnAddBook>>(searchResult));
        }
        [HttpPost("AddBook")]
        public IActionResult PostFromModel(BookDTO_ToCreate input)
        {
            var book = new Book();
            book.Name = input.Name;
            book.Price = input.Price;
            book.CreatedDate = DateTime.Now;
            _db.Add(book);
            _db.SaveChanges();
            return Ok(_mapper.Map<BookDTO_ToReturnAddBook>(book));
        }
        [HttpGet("GetBookByName")]
        public IActionResult GetBookByName(string name)
        {
            var result = _db.Books.Where(x => x.Name.Contains(name)).ToList();
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