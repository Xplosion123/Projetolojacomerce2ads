using LojaEcomerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaEcomerce.Controllers
{
    public class HamburgueriaController : Controller
    {
        public IActionResult NovoPedido()
        {
            return View();
        }
        // pedido é uma instancia da classe Pedido, que é preenchida com os dados do formulário enviado pelo usuário
        public IActionResult NotaPedido(Pedido pedido)
        {
            ViewBag.total = pedido.CalcularPedido();
            pedido.horarioPedido = DateTime.Now;
            return View(pedido);
        }
        // o viewbag é um objeto dinâmico que permite mostrar dados internos na view
    }
}