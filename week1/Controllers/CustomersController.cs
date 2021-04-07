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
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;

        //List<Customer> = list of customer
        private List<Customer> customerList = new List<Customer>();

        public CustomersController(IMapper mapper)
        {
            customerList.Add(new Customer() { Id = 1, FirstName = "A", BankAccount = "1234", ATMCode = "1238", Balance = 100 });
            customerList.Add(new Customer() { Id = 2, FirstName = "B", BankAccount = "2345", ATMCode = "4568", Balance = 200 });
            customerList.Add(new Customer() { Id = 3, FirstName = "C", BankAccount = "3456", ATMCode = "3544", Balance = 300 });
            customerList.Add(new Customer() { Id = 4, FirstName = "D", BankAccount = "4567", ATMCode = "1400", Balance = 400 });
            customerList.Add(new Customer() { Id = 5, FirstName = "E", BankAccount = "6789", ATMCode = "1200", Balance = 500 });
            this._mapper = mapper;
        }

        // [HttpGet] // NoMapper
        // public IActionResult GetAllCustomers()
        // {
        //     return Ok(customerList);
        // }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var result = _mapper.Map<List<CustomerDTO_ToReturn>>(customerList);
            return Ok(result);
        }


        // [HttpGet("{id}")]  // url/api/Customer/1
        // public IActionResult GetCustomer(int id)
        // {
        //     var result = customerList.Where(x => x.Id == id).SingleOrDefault();

        //     var resultToReturn = new CustomerDTO_ToReturn();
        //     //No AutoMapper  >>>>>    CreateMap<Customer, CustomerDTO_ToReturn>().ReverseMap();
        //     resultToReturn.Id = result.Id;
        //     resultToReturn.FirstName = result.FirstName;
        //     resultToReturn.BankAccount = result.BankAccount;
        //     resultToReturn.Balance = result.Balance;

        //     return Ok(resultToReturn);
        // }



        [HttpGet("GetId/{id}")] // url/api/Customer/1    [HttpGet("GetId/{id}")] = ไม่ค่อยใช้
        public IActionResult GetCustomers(int id)
        {
            //primakey unique อะไรที่ไม่ซ้ำใช้ SingleOrDefault
            var customerFromGet = customerList.Where(x => x.Id == id).SingleOrDefault();
            var result = _mapper.Map<CustomerDTO_ToReturn>(customerFromGet);
            return Ok(result);
        }
    }
}