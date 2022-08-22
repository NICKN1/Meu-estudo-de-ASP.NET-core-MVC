namespace Api_Teste.Models
{
    public class RepoCliente
    {
        List<Cliente> listaClientes = new List<Cliente>();
        public string cadastrar(Cliente cliente)
        {
            listaClientes.Add(cliente);
            return "Cliente Cadastrado";
        }
        public List<Cliente> listar()
        {
            return listaClientes;
        }
        public string atualizar(Cliente cliente)
        {
            string response = "Cliente não localizado";
            for(int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].NomeCliente.Equals(cliente.NomeCliente))
                {
                    listaClientes[i].IdCliente = cliente.IdCliente;
                    listaClientes[i].NomeCliente = cliente.NomeCliente;
                    listaClientes[i].email = cliente.email;
                    listaClientes[i].Idade = cliente.Idade;
                    response = "Cliente Atualizado";
                    break;
                }
            }
            return response;
        }
        public string apagar(int id)
        {
            string response = "Cliente não Localizado";
            for(int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].NomeCliente.Equals(id))
                {
                    listaClientes.RemoveAt(i);
                    response = "Cliente Apagado";
                    break;
                }
            }
            return response;
        }
    }
}
