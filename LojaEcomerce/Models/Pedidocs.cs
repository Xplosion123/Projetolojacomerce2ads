namespace LojaEcomerce.Models {
using System.Security.Cryptography.X509Certificates;
    public class Pedido
    {
        // as propriedades get e set permitem respectivamente acessar e modificar o valor da variável
        public string? tamanho { get; set; }
        public string? sabor { get; set; }
        public string? carnes { get; set; }
        public List<string> adicionais { get; set; } = new List<string>();
        public string? endereco { get; set; }
        public double valorEntrega { get; set; }
        public DateTime horarioPedido { get; set; }
        public DateTime previsaoEntrega => horarioPedido.AddHours(1);

        public double CalcularPedido()
        {
            double total = 0;
            total += tamanho switch
            {
                "1 Smash Burguer" => 24.99,
                "2 Smash Burguer" => 29.99,
                "3 Smash Burguer" => 34.99,
                _ => 0.00
            };
            total += sabor switch
            {
                "X-Burguer" => 1.00,
                "X-Salada" => 1.00,
                "X-Bacon" => 5.00,
                "X-Cheddar" => 5.00,
                "X-Egg" => 5.00,
                "X-Tudo" => 10.00,
                _ => 1.00
            };
            total += carnes switch
            {
                "- Nenhuma -" => 0.00,
                "Batata + Refrigerante" => 10.00,
                "Batata + Suco" => 10.00,
                "Batata + Sobremesa" => 10.00,
                _ => 0.00
            };
            total += adicionais.Count * 5.00;
            total += 10.00; // valor fixo para entrega
            return total;
        }
    }
}

