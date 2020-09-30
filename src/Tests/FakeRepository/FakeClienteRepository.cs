namespace Tests.FakeRepository
{
    // public class FakeClienteRepository : IClienteRepository
    // {
    //     private readonly List<Cliente> listaClientes;
    //     public FakeClienteRepository()
    //     {
    //         listaClientes = new List<Cliente>() {
    //             new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0537"), "Vitor", DateTime.Now, "00000000000"),
    //             new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538"), "teste", DateTime.Now, "00000000001"),
    //             new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0539"), "teste", DateTime.Now, "00000000001"),
    //         };
    //     }


    //     public async Task<PaginatedList<Cliente>> BuscarTodos(int? pageNumber)
    //     {
    //         var lista = listaClientes;
    //         int pageSize = 5;
    //         PaginatedList<Cliente> listaPaginada = PaginatedList<Cliente>.Create(lista, pageNumber ?? 1, pageSize);
    //         return listaPaginada;
    //     }



    //     public Task<ResultMessage> Atualizar(ClienteViewModel viewModel)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public Task<ClienteViewModel> BuscarPorId(Guid id)
    //     {
    //         throw new NotImplementedException();
    //     }



    //     public Task<ResultMessage> Cadastrar(ClienteViewModel viewModel)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public bool CpfExists(string cpf)
    //     {
    //         foreach (var item in listaClientes)
    //         {
    //             if (cpf == item.Cpf)
    //                 return true;
    //         }

    //         return false;
    //     }

    //     public void Create(Cliente cliente)
    //     {
    //         listaClientes.Add(cliente);
    //     }


    //     public void Delete(Guid id)
    //     {
    //         foreach (var item in listaClientes)
    //         {
    //             if (id == item.Id)
    //                 listaClientes.Remove(item);
    //         }
    //     }

    //     public Task<ResultMessage> Excluir(Guid id)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public bool Exist(Guid id)
    //     {
    //         foreach (var item in listaClientes)
    //         {
    //             if (id == item.Id)
    //                 return true;
    //         }

    //         return false;
    //     }

    //     public bool Exist(Guid id)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public IEnumerable<Cliente> GetAll()
    //     {
    //         return listaClientes;
    //     }

    //     public Cliente GetById(Guid id)
    //     {
    //         foreach (var item in listaClientes)
    //         {
    //             if (id == item.Id)
    //                 return item;
    //         }

    //         return null;
    //     }

    //     public Task<PaginatedList<Cliente>> Procurar(int? pageNumber, string parametro)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public void Update(Cliente cliente)
    //     {
    //         foreach (var item in listaClientes)
    //         {
    //             if (cliente.Id == item.Id)
    //             {
    //                 listaClientes.Remove(item);
    //                 listaClientes.Add(cliente);
    //             }

    //         }
    //     }
}