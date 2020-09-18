using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto.Models;
using Projeto.Util;
using Projeto.ViewModels;

namespace Projeto.Repository.Interfaces
{
    public interface IClienteRepository
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Guid id);
        Cliente GetById(Guid id);
        IEnumerable<Cliente> GetAll();
        bool CpfExists(string cpf);
        IEnumerable<Cliente> Search(int? pageNumber, string parametro);

    }
}