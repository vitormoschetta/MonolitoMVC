using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Interfaces;
using Projeto.Models;

namespace Tests.FakeRepository
{
    public class FakeClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> listaClientes;
        public FakeClienteRepository()
        {
            listaClientes = new List<Cliente>() {
                new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0537"), "Vitor", DateTime.Now, "00000000000"),
                new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538"), "teste", DateTime.Now, "00000000001"),
                new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0539"), "teste", DateTime.Now, "00000000001"),
            };
        }

        public bool CpfExists(string cpf)
        {
            foreach (var item in listaClientes)
            {
                if (cpf == item.Cpf)
                    return true;
            }

            return false;
        }

        public void Create(Cliente cliente)
        {
            listaClientes.Add(cliente);
        }

        public void Delete(Guid id)
        {
            foreach (var item in listaClientes)
            {
                if (id == item.Id)
                    listaClientes.Remove(item);
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            return listaClientes;
        }

        public Cliente GetById(Guid id)
        {
            foreach (var item in listaClientes)
            {
                if (id == item.Id)
                    return item;
            }

            return null;
        }

        public IEnumerable<Cliente> Search(int? pageNumber, string parametro)
        {
            return listaClientes.Where(x =>
                x.Nome.Contains(parametro) ||
                x.Cpf.Contains(parametro)
                );
        }

        public void Update(Cliente cliente)
        {
            foreach (var item in listaClientes)
            {
                if (cliente.Id == item.Id)
                {
                    listaClientes.Remove(item);
                    listaClientes.Add(cliente);
                }

            }
        }
    }
}