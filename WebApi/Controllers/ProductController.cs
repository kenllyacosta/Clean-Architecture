using Application.Commands.Products;
using Application.Queries.Products;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMediator Mediator;
        public ProductController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("create-one-product")]
        public IActionResult Post()
        {
            return Ok(Mediator.Send(new CreateProductCommand(new Domain.Entities.Product() { Name = "Bananas" })).Result);
        }

        [HttpPost("create-some-products")]
        public IActionResult Posts()
        {
            return Ok(
                Mediator.Send(
                    new CreateProductsCommand(new List<Product>()
                        {
                            new Domain.Entities.Product() { Name = "Jugo de avena" },
                            new Domain.Entities.Product() { Name = "Arroz" },
                            new Domain.Entities.Product() { Name = "Sal molida" }
                        })).Result);
        }

        [HttpPatch("update-product")]
        public IActionResult Patch()
        {
            Product P = Mediator.Send(new GetProductQuery(x => x.Id == 2)).Result;
            return Ok(Mediator.Send(new UpdateProductCommand(P)).Result);
        }

        [HttpPatch("update-product-property-name")]
        public IActionResult PatchPropertyName()
        {
            return Ok(Mediator.Send(new UpdateProductPropertyNameCommand(id: 2, propertyName: "FechaModificado", value: DateTime.Now)).Result);
        }

        [HttpPatch("update-some-products")]
        public IActionResult PatchProducts()
        {
            return Ok(Mediator.Send(new UpdateProductsCommand(new List<Product>()
                        {
                            new Domain.Entities.Product() { Name = "Jugo de avena", Id = 6, FechaModificado = DateTime.Now },
                            new Domain.Entities.Product() { Name = "Arroz", FechaModificado = DateTime.Now, Id = 7 },
                            new Domain.Entities.Product() { Name = "Sal molida", FechaModificado = DateTime.Now, Id = 8 }
                        })).Result);
        }

        [HttpGet("get-product")]
        public IActionResult Get()
        {
            return Ok(Mediator.Send(new GetProductQuery(x => x.Id == 7)).Result);
        }

        [HttpGet("get-products")]
        public IActionResult Gets()
        {
            return Ok(Mediator.Send(new GetProductsQuery(x => true)).Result);
        }

        [HttpDelete("delete-product")]
        public IActionResult Delete()
        {
            return Ok(Mediator.Send(new DeleteProductCommand(x => x.Id == 3)).Result);
        }

        [HttpDelete("delete-products")]
        public IActionResult Deletes()
        {
            return Ok(Mediator.Send(new DeleteProductsCommand(Mediator.Send(new GetProductsQuery(x => true)).Result)).Result);
        }
    }
}
