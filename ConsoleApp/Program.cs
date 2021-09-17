using Application.Commands.Categories;
using Application.Commands.Products;
using Application.Common.Behaviors;
using Application.Queries.Products;
using Domain.Entities;
using FluentValidation;
using IoC;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleApp
{
    class Program
    {        
        static IMediator Mediator;
        static void Main(string[] args)
        {
            Mediator = ConfigureServices(new ServiceCollection(), Configure()).GetService<IMediator>();

            //Products
            CreateProduct();
            //Creates();

            CreateCategory();

            //var p = Retrieve();
            //var ps = Retrieves();

            //Update();
            //Updates();

            //Delete();
            //Deletes();

            //int Count = Conteo();

            Console.WriteLine("Listo!");
            Console.ReadLine();
        }

        private static IConfiguration Configure()
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }

        private static ServiceProvider ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMediatR(Assembly.Load("Application"));
            services.AddRepositories(Configuration);

            //Para las validaciones fluídas
            services.AddValidatorsFromAssembly(Assembly.Load("Application"));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services.BuildServiceProvider();
        }

        private static int ConteoProducts()
        {
            return Mediator.Send(new CountProductsQuery(x => true)).Result;
        }

        private static Category CreateCategory()
        {
            return Mediator.Send(new CreateCategoryCommand(new Category() { })).Result;
        }

        private static Product CreateProduct()
        {
            return Mediator.Send(new CreateProductCommand(new Product() { Name = "" })).Result;
        }

        private static bool Creates()
        {
            return Mediator.Send(new CreateProductsCommand(new List<Product>()
                        {
                            new Domain.Entities.Product() { Name = "Jugo de avena" },
                            new Domain.Entities.Product() { Name = "Arroz" },
                            new Domain.Entities.Product() { Name = "Sal molida" }
                        })).Result;
        }

        private static Product Retrieve()
        {
            return Mediator.Send(new GetProductQuery(x => x.Id == 2)).Result;
        }

        private static IEnumerable<Product> Retrieves()
        {
            return Mediator.Send(new GetProductsQuery(x => true)).Result;
        }

        private static bool Update()
        {
            return Mediator.Send(new UpdateProductCommand(new Product() { Id = 1, FechaModificado = DateTime.Now })).Result;
        }

        private static bool Updates()
        {
            return Mediator.Send(new UpdateProductsCommand(new List<Product>()
                        {
                            new Domain.Entities.Product() { Name = "Jugo de avena", FechaModificado = DateTime.Now, Id = 1 },
                            new Domain.Entities.Product() { Name = "Arroz", FechaModificado = DateTime.Now, Id = 2 },
                            new Domain.Entities.Product() { Name = "Sal molida", FechaModificado = DateTime.Now, Id = 3 }
                        })).Result;
        }

        private static bool Delete()
        {
            return Mediator.Send(new DeleteProductCommand(x => x.Id == 4)).Result;
        }

        private static bool Deletes()
        {
            return Mediator.Send(new DeleteProductsCommand(Mediator.Send(new GetProductsQuery(x => true)).Result)).Result;
        }
    }
}
