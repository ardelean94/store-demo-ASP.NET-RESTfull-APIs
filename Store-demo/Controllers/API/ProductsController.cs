using Store_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Store_demo.Dto;

namespace Store_demo.Controllers.API
{
    public class ProductsController : ApiController
    {
        ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/products
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            var productDtos = _context.Products
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        //GET api/products/1
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            var productInDb = _context.Products
                .Single(p => p.Id == id);

            if (productInDb == null)
                return NotFound();  //RESTfull convention - 404

            return Ok(Mapper.Map<Product, ProductDto>(productInDb));
        }

        //POST api/products
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();    //RESTfull convention - 400

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.Id = product.Id;

            //RESTfull convention - 201 Created
            return Created(new Uri(Request.RequestUri + "/" + productDto.Id), productDto);
        }

        //PUT api/products/2
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                BadRequest();   //400

            var productInDb = _context.Products
                .SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                NotFound(); //404

            Mapper.Map(productDto, productInDb);
            _context.SaveChanges();

            return Ok();

        }

        //DELETE api/products/3
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = _context.Products
                .SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                NotFound(); //404

            _context.Products.Remove(productInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
