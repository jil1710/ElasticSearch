
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using SearchingOptimize.Models;
using System.Collections.Generic;

namespace SearchingOptimize
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddElasticSearch(builder.Configuration).Wait();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGet("/seed", async (IElasticClient client) =>
            {
                

                for (int i = 0; i < 100000; i++)
                {
                    var customer = new Customer() { CusId = Guid.NewGuid(), CusName = "Demo" + i, CusCity = "City" + i, CusPan = Random.Shared.NextInt64(1000000000, 9999999999).ToString(), CusPhone = Random.Shared.NextInt64(1000000000, 9999999999).ToString(),
                    AccountType = new AccountType() { AccTypeId = Guid.NewGuid(), AccType = new string[] { "Saving", "Fixed", "Current" }[Random.Shared.Next(0, 3)] },
                    CreatedAt = DateTime.Now,
                    Account = new Account() { AccId = Guid.NewGuid(),AccBalance= 4545+i,AccStatus = new string[] { "Active", "InActive" }[Random.Shared.Next(0,2)] },
                    TransactionHistory = new List<TransactionHistory> { new TransactionHistory() { TranId=Guid.NewGuid(),Amount= 500+i,CreatedAt= DateTime.Now,FromCusId= Guid.NewGuid(),ToCusId= Guid.NewGuid(),TansGateway="Stripe",TranMethod="Card" },
                    new TransactionHistory() {  TranId=Guid.NewGuid(),Amount= 6500+i,CreatedAt= DateTime.Now,FromCusId= Guid.NewGuid(),ToCusId= Guid.NewGuid(),TansGateway="UPI",TranMethod="Paytm" }}
                    };

                    var res = await client.IndexAsync(customer, index => index.Index("customer"));

                }

                

                return Results.Ok("Seeding Completed");
            });

            // Find by customer Name data we have 300000 customers
            app.MapGet("/get-custoemr-by-name", async (string name, IElasticClient client) =>
            {
                var searchResponse = await client.SearchAsync<Customer>(s => s
                                    .Query(q => q
                                        .Match(m => m.Field(f => f.CusName).Query(name)))
                                );
                if(searchResponse == null && !searchResponse.IsValid)
                {
                    return Results.BadRequest("Customer not found");
                }

                return Results.Ok(searchResponse.Documents);
            });



            // Get all customer by their account type [ Saving, Fixed, Current ]
            app.MapGet("/find-by-account-type", async (string accountType,IElasticClient client) =>
            {
                var searchResponse = await client.SearchAsync<Customer>(s => s
                                    .Query(q => q
                                        .Nested(n => n
                                            .Path(p => p.AccountType) 
                                            .Query(nq => nq
                                                .Match(m => m
                                                    .Field(f => f.AccountType.AccType) 
                                                    .Query(accountType)
                                                )
                                            )
                                        )
                                    )
                                );

                if (searchResponse == null && !searchResponse.IsValid)
                {
                    return Results.BadRequest("Customer not found");
                }

                return Results.Ok(searchResponse.Documents);

            });

            app.MapPost("/create", async (IElasticClient client, [FromBody] CRUD data) =>
            {
                
                var res = await client.IndexAsync(data, index => index.Index("crud"));
                if (!res.IsValid)
                {
                    return Results.BadRequest("Something went wrong! Try again..");
                }

                return Results.Ok("Customer create successfully");
            });


            app.MapGet("/readById", async (int id , IElasticClient client) =>
            {
                var res = await client.GetAsync<CRUD>(id, index => index.Index("crud"));
                if(res.IsValid)
                {
                    return Results.Ok(res.Source);
                }
                return Results.BadRequest("Not Found");
            });

            app.MapPut("/update", async (CRUD data,int d,IElasticClient client) =>
            {
                var updateResponse = await client.UpdateAsync<CRUD>(data.Id, u => u.Doc(data));
                return updateResponse.IsValid;
            });


            app.MapDelete("/delete", async (int id, IElasticClient client) =>
            {
                var deleteResponse = await client.DeleteAsync<CRUD>(id);
                return deleteResponse.IsValid;
            });



            /// Search The Documents by Name Field
            app.MapGet("get-by-name-field", async (string pattern, IElasticClient client) =>
            {
                var searchResponse = await client.SearchAsync<CRUD>(s => s
                                        .Query(q => q
                                            .Match(m => m
                                                .Field(f => f.Name) 
                                                .Query(pattern)
                                            )
                                        )
                                    );

                if(searchResponse.IsValid)
                {
                    return Results.Ok(searchResponse.Documents);
                }

                return Results.BadRequest("Not Record Found");
            });


            app.MapGet("get-by-age", async (IElasticClient client) =>
            {
                var searchResponse =await client.SearchAsync<CRUD>(s => s
                                .Query(q => q
                                    .DateRange(dr => dr
                                        .Field(f => f.DOB)
                                        .LessThanOrEquals("now-18y/y")
                                    )
                                )
                               );
                if (searchResponse.IsValid)
                {
                    return Results.Ok(searchResponse.Documents);
                }

                return Results.BadRequest("Not Record Found");

            });

       
            app.Run();
        }
    }
}