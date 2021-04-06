using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using week1.Models;

namespace week1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockMarketController : ControllerBase
    {
        private List<StockMarket> StockList()
        {
            var stockList = new List<StockMarket>();
            stockList.Add(new StockMarket() { Id = 1, Name = "GUNKUL", Price = 4.10 });
            stockList.Add(new StockMarket() { Id = 2, Name = "DOD", Price = 13.90 });
            stockList.Add(new StockMarket() { Id = 3, Name = "CSS", Price = 2.30 });
            stockList.Add(new StockMarket() { Id = 4, Name = "ITEL", Price = 4.02 });
            stockList.Add(new StockMarket() { Id = 5, Name = "BBL", Price = 127.50 });
            stockList.Add(new StockMarket() { Id = 6, Name = "TWZ", Price = 0.15 });
            stockList.Add(new StockMarket() { Id = 7, Name = "IND", Price = 2.12 });
            stockList.Add(new StockMarket() { Id = 8, Name = "BLAND", Price = 1.15 });
            return stockList;
        }
        [HttpGet("GetAllStock")]

        public IActionResult GetAllStock()
        {
            var stockList = StockList();
            return Ok(stockList);
        }

        [HttpGet("SearchStokByName")]
        public IActionResult SearchStokByName(string name)
        {
            var stockList = StockList();

            var searchStock = stockList.Where(x => x.Name.Contains(name.ToUpper())).OrderBy(o => o.Id).ToList();
            if (searchStock.Count() != 0)
            {
                var countStock = searchStock.Count();
                var minPriceStock = searchStock.Min(n => n.Price);
                var nameMin = stockList.Where(x => x.Price == minPriceStock).FirstOrDefault();
                var maxPriceStock = searchStock.Max(m => m.Price);
                var nameMax = stockList.Where(x => x.Price == maxPriceStock).FirstOrDefault();


                string find = $"Total stocks = {countStock}  {Environment.NewLine}";
                int i = 0;
                foreach (var item in searchStock)
                {
                    i++.ToString();
                    find += "Id :" + item.Id + ", Name : " + item.Name + ", Price : " + item.Price + Environment.NewLine;
                }

                find += $"{Environment.NewLine} Minimal =  {nameMin.Name} -> {minPriceStock}{Environment.NewLine} Maximum = {nameMax.Name} -> {maxPriceStock}";
                return Ok(find);
            }
            else
            {
                return NotFound("Can not found this stock name!");
            }

        }
        [HttpPost("AddNewStock")]
        public IActionResult AddNewStock(StockMarket newItem)
        {
            var addNew = new List<StockMarket>();
            addNew.Add(new StockMarket { Id = newItem.Id, Name = newItem.Name, Value = newItem.Value, Price = newItem.Price });
            return Ok(newItem);

        }

        [HttpPost("Buy")]
        public IActionResult Buy(int id, double value)
        {
            var stockList = StockList();

            var findStock = stockList.Where(w => w.Id == id).FirstOrDefault();
            findStock.Value = value;
            double totalPrice = findStock.Price * findStock.Value;
            string calculatePrice = $"You want to buy {findStock.Name}.{Environment.NewLine} Value = {findStock.Value} " +
            $"Price / Unit = {findStock.Price} {Environment.NewLine} Total Price = {totalPrice}";
            return Ok(calculatePrice);

        }

        [HttpPut("UpdateStock")]
        public IActionResult UpdateStock(int id, string name, double value, double price)
        {
            if (id == 0 && name == null && value == 0 && price == 0)
            {
                return Ok("All value must not be null");
            }
            else
            {
                var stockList = StockList().Where(x => x.Id == id).FirstOrDefault();
                if (stockList == null)
                {
                    return Ok("Not found this Id");
                }
                else
                {
                    string oriStock = $"Old Data ==> Id : {stockList.Id}, Name : {stockList.Name}, Value {stockList.Value}, Price : {stockList.Price}";
                    bool checkedChange = false;
                    if (stockList.Id != id)
                    {
                        stockList.Id = id;
                        checkedChange = true;
                    }
                    if (stockList.Name != name)
                    {
                        if (name != null)
                        {
                            stockList.Name = name.ToUpper();
                            checkedChange = true;
                        }
                    }
                    if (stockList.Value != value)
                    {
                        if (value != 0)
                        {
                            checkedChange = true;
                            stockList.Value = value;
                        }
                    }
                    if (stockList.Price != price && price != 0)
                    {
                        if (price != 0)
                        {
                            checkedChange = true;
                            stockList.Price = price;
                        }
                    }
                    if (checkedChange)
                    {
                        oriStock += $"{Environment.NewLine} Change Successfully";
                    }
                    else
                    {
                        oriStock += $"{Environment.NewLine} Nothing changed";

                    }
                    string changeStock = $"{oriStock} {Environment.NewLine} " + $"Update Data ==> Id : {stockList.Id}, Name : {stockList.Name}, Value {stockList.Value}, Price : {stockList.Price}";
                    return Ok(changeStock);
                }

            }


        }


        [HttpDelete("DeleteStock")]
        public IActionResult DeleteStock(int id)
        {
            var stockList = StockList();
            stockList.RemoveAll(r => r.Id == id);
            return Ok(stockList);
        }

    }
}