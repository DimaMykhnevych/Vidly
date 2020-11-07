using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VidlyDbContext _context;
        private static MapperConfiguration config;
        private IMapper mapper;

        public CustomersController()
        {
            config = new AutoMapperConfiguration().Configure();
            _context = new VidlyDbContext();
            mapper = config.CreateMapper();

        }
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c=>c.Name.Contains(query));
            }

            var customerDtos = customersQuery
                .ToList()
                .Select(mapper.Map<Customer, CustomerDto>);

            //var customerDtos = mapper.Map<IEnumerable<CustomerDto>>(_context.Customers
            //    .Include(c => c.MembershipType).ToList());
            return Ok(customerDtos);
            //return _context.Customers.ToList().Select(mapper.Map<Customer, CustomerDto>);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(mapper.Map<CustomerDto>(customer));
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
            return Ok();

        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
