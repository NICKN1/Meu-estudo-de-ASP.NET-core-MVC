using Camadas_MVC_dados_Mockados.Models;
using Microsoft.AspNetCore.Mvc;

namespace Camadas_MVC_dados_Mockados.Controllers
{
    public class ProdutoController : Controller
    {
        static List<Produto> lista = new List<Produto>();
        public IActionResult Index()
        {
            lista.Add(new Produto() { NomeProduto = "Mouse", Descricao = "Sem Fio", Categoria = "Informática,", Quantidade = 23, Preco = 50.60 });
            lista.Add(new Produto() { NomeProduto = "Teclado", Descricao = "Sem Fio", Categoria = "Informática,", Quantidade = 13, Preco = 150.00 });
            lista.Add(new Produto() { NomeProduto = "SSD", Descricao = "SSD 480GB", Categoria = "Informática,", Quantidade = 23, Preco = 500.90 });
            ViewBag.Produto = lista;

            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Atualizar(int? id)
        {
            return View();
        }
        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Produto novoProduto)
        {
            lista.Add(novoProduto);
            return RedirectToAction("Index");
        }

        //Necessário essa duplicação????
        
        [HttpPost]
        public IActionResult Atualizar(int? id, Produto produto)
        {
            Produto produtoAlterado = new Produto();
            int i = 0;
            foreach(var item in lista)
            {
                if(item.Id == id)
                {
                    item.NomeProduto = produto.NomeProduto;
                    item.Descricao = produto.Descricao;
                    item.Categoria = produto.Categoria;
                    item.Quantidade = produto.Quantidade;
                    item.Preco = produto.Preco;
                    lista[i] = item;
                    break;
                }
                i++;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Apagar(int? id)
        {
            Produto produtoAlterado = new Produto();
            int i = 0;
            foreach (var item in lista)
            {
                if (item.Id == id)
                {
                    lista.RemoveAt(i);
                }
                i++;
            }
            return RedirectToAction("Index");
        }
    }
}
