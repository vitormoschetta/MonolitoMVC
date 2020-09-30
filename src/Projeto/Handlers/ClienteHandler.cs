using System;
using System.Collections.Generic;
using AutoMapper;
using Flunt.Notifications;
using Projeto.Interfaces;
using Projeto.Models;
using Projeto.Utils;
using Projeto.ViewModels;

namespace Projeto.Handlers
{
    public class ClienteHandler : Notifiable, IClienteHandler
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteHandler(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public IEnumerable<Cliente> GetAll(int? pageNumber)
        {
            var lista = _repository.GetAll();
            var itensPorPagina = 5;
            PaginatedList<Cliente> listaPaginada = PaginatedList<Cliente>.Create(lista, pageNumber ?? 1, itensPorPagina);
            return listaPaginada;
        }

        public IEnumerable<Cliente> Search(int? pageNumber, string parametro)
        {
            var lista = _repository.Search(pageNumber, parametro);
            var itensPorPagina = 5;
            PaginatedList<Cliente> listaPaginada = PaginatedList<Cliente>.Create(lista, pageNumber ?? 1, itensPorPagina);
            return listaPaginada;
        }

        public ClienteViewModel GetById(Guid id)
        {
            var cliente = _repository.GetById(id);
            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);
            return clienteViewModel;
        }

        public bool CpfExists(string cpf)
        {
            return _repository.CpfExists(cpf);
        }


        public DataResult Create(ClienteViewModel clienteViewModel)
        {

            if (_repository.CpfExists(clienteViewModel.Cpf))
                AddNotification("CPF", "Este CPF já está em uso. ");

            // Gerar Value Objecst (caso esteja trabalhando com VOs)

            var cliente = new Cliente(clienteViewModel.Nome, clienteViewModel.DataNascimento, clienteViewModel.Cpf);

            // Agrupar as Validações
            AddNotifications(cliente);

            // Checa se existem notificações
            if (Invalid)
                return new DataResult(false, "Não foi possível realizar o cadastro. ", Notifications, null);

            // Salvar cliente no banco:     
            _repository.Create(cliente);

            clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

            return new DataResult(true, "Cadastro realizado com sucesso. ", Notifications, clienteViewModel);
        }


        public DataResult Update(ClienteViewModel clienteViewModel)
        {
            // Recupera o cliente (Rehidratação)
            var cliente = _repository.GetById(clienteViewModel.Id);

            // Valida e atualiza o objeto
            cliente.Update(clienteViewModel.Nome, clienteViewModel.DataNascimento, clienteViewModel.Cpf);

            // Agrupar as Validações
            AddNotifications(cliente);

            // Checa se existem notificações
            if (Invalid)
                return new DataResult(false, "Não foi possível atualizar. ", Notifications, null);

            // Salva no banco
            _repository.Update(cliente);

            clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

            // Retornar informações : command result
            return new DataResult(true, "Cadastro atualizado com sucesso. ", Notifications, clienteViewModel);
        }


        public DataResult Delete(Guid id)
        {
            // Recupera o cliente (Rehidratação)
            var cliente = _repository.GetById(id);
            if (cliente == null)
                return new DataResult(false, "Cliente não existe. ", Notifications, null);

            // Salva no banco
            _repository.Delete(cliente.Id);

            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

            // Retornar informações : command result
            return new DataResult(true, "Informações Excluídas. ", Notifications, clienteViewModel);
        }




    }
}