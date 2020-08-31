
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simulation.Data;
using Simulation.Dto;
using Simulation.Models;

namespace Simulation.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController :ControllerBase{
        public CustomersController(ICustomerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        private readonly ICustomerRepo _repository;
        private readonly IMapper _mapper;
        [HttpGet]
        public ActionResult <IEnumerable<Customer>> getAllCustomers(){
            var customerItems = _repository.GetAllCustomers();
            return Ok(_mapper.Map<IEnumerable<CustomerGetDto>>(customerItems));
        }
        [HttpGet("{id}",Name="GetCommandById")]
        public ActionResult <Customer> getCustomerById(int id){
            var customerItem = _repository.GetCustomerById(id);
            if(customerItem != null)
            {
                return Ok(_mapper.Map<CustomerGetDto>(customerItem));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult <Customer> CreateCustomer(CustomerPostDto customerCreateDto)
        {
            var customerModel = _mapper.Map<Customer>(customerCreateDto);
            _repository.CreateCustomer(customerModel);
            _repository.SaveChanges();
            return CreatedAtRoute("GetCommandById", new {Id = customerModel.Id}, customerModel);      
        }
    }
}