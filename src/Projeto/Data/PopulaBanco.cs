using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Models;

namespace Projeto.Data
{
    public static class PopulaBanco
    {
        public static void PopulaTabelaCliente(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Cliente.Any())
                {
                    return;   // Se já possui dados, não prossegue
                }

                for (int i = 0; i < 50; i++)
                {
                    var cliente = new Cliente($"Fulano {i}",
                                            DateTime.Now.AddYears(-(18 + i)),
                                            $"0000000000{i}");

                    context.Cliente.Add(cliente);
                    context.SaveChanges();
                }

            }
        }
    }
}