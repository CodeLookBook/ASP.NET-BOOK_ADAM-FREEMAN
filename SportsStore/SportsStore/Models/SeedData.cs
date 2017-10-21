﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name        = "Kayak",
                        Description = "А boat for one person",
                        Category    = "Watersports",
                        Price       = 275
                    },
                    new Product
                    {
                        Name        = "Lifejacket",
                        Description = "Protective and fashionaЫe",
                        Category    = "Watersports",
                        Price       = 48.95m
                    },
                    new Product
                    {
                        Name        = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category    = "Soccer",
                        Price       = 19.50m
                    },
                    new Product
                    {
                        Name        = "Corner  Flags",
                        Description = "Give your playing field а professional touch",
                        Category    = "Soccer",
                        Price       = 34.95m
                    },
                    new Product
                    {
                        Name        = "Stadium",
                        Description = "Fl at-packed 35, 000-seat stadi um",
                        Category    = "Soccer",
                        Price       = 79500
                    },
                    new Product
                    {
                        Name        = "Thinking Сар",
                        Description = "Improve brain  efficiency Ьу 7 5%",
                        Category    = "Chess",
                        Price       = 16
                    },
                    new Product
                    {
                        Name        = "Unst eady Chair",
                        Description = "Secretly give your  opponent а disadvantage",
                        Category    = "Chess",
                        Price       = 29.95m
                    },
                    new Product
                    {
                        Name        = "Human Chess  Board",
                        Description = "А fun game for  the family",
                        Category    = "Chess",
                        Price       = 75
                    },
                    new Product
                    {
                        Name        = "Bling-Bl ing Ki ng",
                        Description = "Gold-plated, diamond-st udded King",
                        Category    = "Chess",
                        Price       = 1200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
