using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Interfaces;
using Projeto.Models;

namespace Projeto.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Cliente.ToList();
        }

        public Cliente GetById(Guid id)
        {
            return _context.Cliente.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var cliente = _context.Cliente.FirstOrDefault(x => x.Id == id);
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public bool CpfExists(string cpf)
        {
            var cliente = _context.Cliente.FirstOrDefault(x => x.Cpf == cpf);
            if (cliente != null) return true;
            return false;
        }

        public IEnumerable<Cliente> Search(int? pageNumber, string parametro)
        {
            var query = $"select * from Cliente where nome like '%{parametro}%' ";
            query += $" or cpf like '%{parametro}%' ";
            query += $" or datanascimento like '%{parametro}%' ";
            return _context.Cliente.FromSqlRaw(query).ToList();
        }
    }
}