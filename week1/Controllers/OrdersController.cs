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
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _db;
        private List<Order> orderist = new List<Order>();
        private List<Product> productList = new List<Product>();

        public OrdersController(IMapper mapper,AppDBContext db)
        {
     
            this._mapper = mapper;
            this._db = db;
        }
        [HttpGet("GetOrderT")]
        public IActionResult GetProduct()
        {
            var result = _mapper.Map<List<OrderDTO_ToReturn>>(_db.Orders.ToList());
            return Ok(result);
        }

   [HttpPost("AddNewOrder")]
        public IActionResult AddNewOrder(OrderDTO_ToCreate newItem)
        {
            var addNew = new Order();
            addNew.ProductId = newItem.Id;   
            addNew.PayType = newItem.PayType;
            addNew.TotalItem = newItem.TotalItem;
            var product = _db.Products.Where(x => x.Id ==  newItem.Id).FirstOrDefault();
            addNew.TotalPrice =  addNew.TotalItem * product.Price;
            addNew.OrderDate = DateTime.Now;
            _db.Add(addNew);
            _db.SaveChanges();
            return Ok(_mapper.Map<OrderDTO_ToReturn>(addNew));

        }
        [HttpGet("{id}")]
        public IActionResult GetOrderByOrderId(int id)
        {
            var order = _db.Orders.Where(x => x.Id == id).SingleOrDefault();
            var result = _mapper.Map<OrderDTO_ToReturn>(order);
            return Ok(result);
        }

        [HttpGet("GetOrderByPay/{pay}")]
        public IActionResult GetOrderByPay(string pay)
        {
            var order = _db.Orders.Where(x => x.PayType.ToLower().Contains(pay.ToLower())).ToList();
            var result = _mapper.Map<List<OrderDTO_ToReturn>>(order);
            return Ok(result);  
        }


    }
}