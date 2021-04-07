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
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _db;

        //List<Customer> = list of customer
     

        public CustomersController(IMapper mapper , AppDBContext db)
        {
            this._mapper = mapper;
            this._db = db;
        }

        // [HttpGet] // NoMapper
        // public IActionResult GetAllCustomers()
        // {
        //     return Ok(customerList);
        // }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customer = _db.Customers.ToList();
            var sum = _db.Customers.Sum(x => x.Balance);
            var count = customer.Count();
            var result = _mapper.Map<List<CustomerDTO_ToReturn>>(customer.ToList());
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
            var customerFromGet = _db.Customers.Where(x => x.Id == id).SingleOrDefault();
            var result = _mapper.Map<CustomerDTO_ToReturn>(customerFromGet);
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult CreateCustomer(CustomerDTO_ToCreate input){
            var customer = new Customer();
            customer.FirstName = input.FirstName;
            customer.LastName = input.LastName;
            customer.ATMCode = input.ATMCode;
            customer.Balance = input.Balance;
            customer.BankAccount = input.BankAccount;
           // var cusMap = _mapper.Map<Customer>(input);
            _db.Customers.Add(customer);
            _db.SaveChanges();
            var resultCustomerToReturn = _mapper.Map<CustomerDTO_ToReturn>(customer);
            return Ok(resultCustomerToReturn);
        }
    }
}