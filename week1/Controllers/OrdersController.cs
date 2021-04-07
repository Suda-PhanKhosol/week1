using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using week1.DTOs;
using week1.Models;

namespace week1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private List<Order> orderist = new List<Order>();
        private List<Product> productList = new List<Product>();

        public OrdersController(IMapper mapper)
        {
            productList.Add(new Product { Id = 1, NameItem = "120 GB SSD SATA APACER AS340 (AP120GAS340G-1)", Price = 705, Descr = "-", CodeType = "A505" });
            productList.Add(new Product { Id = 2, NameItem = "4 Port USB HUB V.3.0 Magictech (MT29) White", Price = 170, Descr = "-", CodeType = "A501" });
            productList.Add(new Product { Id = 3, NameItem = "4 Port USB HUB OKER (H1) Green", Price = 175, Descr = "-", CodeType = "A505" });
            productList.Add(new Product { Id = 4, NameItem = "Car Camera 'Magic Tech' H2", Price = 480, Descr = "-", CodeType = "A502" });
            productList.Add(new Product { Id = 5, NameItem = "Cooler Pad พับเก็บได้ (2Fan) คละสี", Price = 85, Descr = "-", CodeType = "A505" });
            productList.Add(new Product { Id = 6, NameItem = "500VA APC BK500EI", Price = 3000, Descr = "-", CodeType = "A505" });
            productList.Add(new Product { Id = 7, NameItem = "500VA APC BK500EI", Price = 705, Descr = "-", CodeType = "A505" });
            productList.Add(new Product { Id = 8, NameItem = "650VA APC BX650LI MS", Price = 4000, Descr = "-", CodeType = "A500" });
            productList.Add(new Product { Id = 9, NameItem = "1100VA APC BX1100LI MS", Price = 2000, Descr = "-", CodeType = "A505" });
            productList.Add(new Product { Id = 10, NameItem = "Notebook Acer Aspire A315-22-90B3/00H (Black)", Price = 9900, Descr = "-", CodeType = "A509" });
            productList.Add(new Product { Id = 11, NameItem = "Notebook Lenovo IdeaPad 5 15ITL05 82FG006CTA (Graphite)", Price = 25000, Descr = "-", CodeType = "A505" });


            DateTime date = DateTime.Now;

            orderist.Add(new Order
            {
                Id = 1,
                ProductId = 1,
                TotalItem = 5,
                TotalPrice = 5 * 705,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 1).ToList()
            });
            orderist.Add(new Order
            {
                Id = 2,
                ProductId = 2,
                TotalItem = 5,
                TotalPrice = 5 * 170,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 2).ToList()
            });
            orderist.Add(new Order
            {
                Id = 3,
                ProductId = 3,
                TotalItem = 5,
                TotalPrice = 5 * 175,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 3).ToList()
            });
            orderist.Add(new Order
            {
                Id = 4,
                ProductId = 4,
                TotalItem = 5,
                TotalPrice = 5 * 480,
                PayType = "Cash",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 4).ToList()
            });
            orderist.Add(new Order
            {
                Id = 5,
                ProductId = 5,
                TotalItem = 5,
                TotalPrice = 5 * 85,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 5).ToList()
            });
            orderist.Add(new Order
            {
                Id = 6,
                ProductId = 6,
                TotalItem = 5,
                TotalPrice = 5 * 3000,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 6).ToList()
            });
            orderist.Add(new Order
            {
                Id = 7,
                ProductId = 7,
                TotalItem = 5,
                TotalPrice = 5 * 705,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 7).ToList()
            });
            orderist.Add(new Order
            {
                Id = 8,
                ProductId = 8,
                TotalItem = 5,
                TotalPrice = 5 * 4000,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 8).ToList()
            });
            orderist.Add(new Order
            {
                Id = 9,
                ProductId = 9,
                TotalItem = 5,
                TotalPrice = 5 * 2000,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 9).ToList()
            });
            orderist.Add(new Order
            {
                Id = 10,
                ProductId = 10,
                TotalItem = 5,
                TotalPrice = 5 * 9900,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 10).ToList()
            });
            orderist.Add(new Order
            {
                Id = 11,
                ProductId = 11,
                TotalItem = 5,
                TotalPrice = 5 * 25000,
                PayType = "Online Banking",
                OrderDate = date,
                ProductDetail = productList.Where(x => x.Id == 11).ToList()
            });
            this._mapper = mapper;
        }
        [HttpGet("GetOrder")]
        public IActionResult GetProduct()
        {
            var result = _mapper.Map<List<OrderDTO_ToReturn>>(orderist);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderByOrderId(int id)
        {
            var order = orderist.Where(x => x.Id == id).SingleOrDefault();
            var result = _mapper.Map<OrderDTO_ToReturn>(order);
            return Ok(result);
        }

        [HttpGet("GetOrderByPay/{pay}")]
        public IActionResult GetOrderByPay(string pay)
        {
            var order = orderist.Where(x => x.PayType.ToLower().Contains(pay.ToLower())).ToList();
            var result = _mapper.Map<List<OrderDTO_ToReturn>>(order);
            return Ok(result);
        }

        [HttpGet("FindByDTOOreder")]
        public IActionResult FindByDTOOreder(FindOrderDTO_ToReturn findOrderDTO_ToReturn){
            return Ok();
        }

    }
}