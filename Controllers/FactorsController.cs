using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simulation.Data;
using Simulation.Dto;
using Simulation.Models;

namespace Simulation.Controllers
{
    [Route("api/factor")]
    [ApiController]
    public class FactorsController : ControllerBase
    {
        public FactorsController(IFactorRepo repository, IProductRepo productRepo, ICustomerRepo customerRepo, IOrderItemRepo orderItemRepo, IMapper mapper)
        {
            _repository = repository;
            _productRepo = productRepo;
            _customerRepo = customerRepo;
            _orderItemRepo = orderItemRepo;
            _mapper = mapper;
        }
        private readonly IFactorRepo _repository;
        private readonly IProductRepo _productRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly IOrderItemRepo _orderItemRepo;
        private readonly IMapper _mapper;
        [HttpGet]
        public ActionResult<IEnumerable<Factor>> getAllFactors()
        {
            var factorItems = _repository.GetAllFactors();
            return Ok(factorItems);
        }
        [HttpGet("{id}", Name = "GetFactorById")]
        public ActionResult<Factor> getFactorById(int id)
        {
            var factorItem = _repository.GetFactorById(id);
            if (factorItem != null)
            {
                return Ok(factorItem);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<Factor> createFactor(FactorPostClass factor)
        {
            // second find customer
            var _customer = _customerRepo.GetCustomerById(factor.customerId);
            if (_customer == null)
            {
                return NotFound("The customer Not Found");
            }
            // first find products
            List<OrderItem> _orderItems = new List<OrderItem>();
            foreach (var order in factor.orderItems)
            {
                var p = _productRepo.GetProductById(order.productId);
                if (p == null)
                {
                    return NotFound("The Product " + order.productId.ToString() + " Not Found");
                }
                else
                {
                    OrderItem o = new OrderItem { count = order.count, product = p, productId = order.productId };
                    _orderItems.Add(o);
                }
            }
            foreach (var o in _orderItems)
            {
                _orderItemRepo.CreateOrderItem(o);
                _orderItemRepo.SaveChanges();
            }
            Factor f = new Factor { orderItems = _orderItems, customer = _customer, customerId = factor.customerId, WriteDate = factor.WriteDate, paymentStatus = 0, total = factor.total };
            _repository.CreateFactor(f);
            _repository.SaveChanges();
            return CreatedAtRoute("GetFactorById", new {Id = f.factorId}, f);
            // third create a Factor Object and save it to DB and return back to client
            // var _factor = _mapper.Map<Factor>(factor);
            // _repository.CreateFactor(_factor);
            // _repository.SaveChanges();
            // return CreatedAtRoute("GetFactorById", new {Id = _factor.factorId}, _factor);
        }
    }
}