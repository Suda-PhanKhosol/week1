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
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private List<Product> productList = new List<Product>();
        public ProductsController(IMapper mapper)
        {
            productList.Add(new Product { Id = 1, NameItem = "120 GB SSD SATA APACER AS340 (AP120GAS340G-1)", Price = 705, Descr = "-" ,CodeType="A505"});
            productList.Add(new Product { Id = 2, NameItem = "4 Port USB HUB V.3.0 Magictech (MT29) White", Price = 170, Descr = "-",CodeType="A501" });
            productList.Add(new Product { Id = 3, NameItem = "4 Port USB HUB OKER (H1) Green", Price = 175, Descr = "-" ,CodeType="A505"});
            productList.Add(new Product { Id = 4, NameItem = "Car Camera 'Magic Tech' H2", Price = 480, Descr = "-",CodeType="A502" });
            productList.Add(new Product { Id = 5, NameItem = "Cooler Pad พับเก็บได้ (2Fan) คละสี", Price = 85, Descr = "-" ,CodeType="A505"});
            productList.Add(new Product { Id = 6, NameItem = "500VA APC BK500EI", Price = 3000, Descr = "-" ,CodeType="A505"});
            productList.Add(new Product { Id = 7, NameItem = "500VA APC BK500EI", Price = 705, Descr = "-" ,CodeType="A505"});
            productList.Add(new Product { Id = 8, NameItem = "650VA APC BX650LI MS", Price = 4000, Descr = "-" ,CodeType="A500"});
            productList.Add(new Product { Id = 9, NameItem = "1100VA APC BX1100LI MS", Price = 2000, Descr = "-" ,CodeType="A505"});
            productList.Add(new Product { Id = 10, NameItem = "Notebook Acer Aspire A315-22-90B3/00H (Black)", Price = 9900, Descr = "-" ,CodeType="A509"});
            productList.Add(new Product { Id = 11, NameItem = "Notebook Lenovo IdeaPad 5 15ITL05 82FG006CTA (Graphite)", Price = 25000, Descr = "-",CodeType="A505" });
            this._mapper = mapper;
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(){
            var result = _mapper.Map<List<ProductDTO_ToReturn>>(productList);
            return Ok(result);
        }

          [HttpGet("{id}")]
        public IActionResult GetOrderByOrderId(int id)
        {
            var product = productList.Where(x => x.Id == id).SingleOrDefault();
            var result = _mapper.Map<ProductDTO_ToReturn>(product);
            return Ok(result);
        }
    }
}