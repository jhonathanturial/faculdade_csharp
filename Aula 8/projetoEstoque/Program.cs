using System;

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }

    public double valorTotalEmEstoque()
    {
        return Preco * Quantidade;
    }

    public void adicionarProduto(int quantidade)
    {
        Quantidade += quantidade;
    }

    public void removerProdutos(int quantidade)
    {
        if (Quantidade >= quantidade)
        {
            Quantidade -= quantidade;
        }
        else
        {
            Console.WriteLine("Quantidade insuficiente em estoque.");
        }
    }
}

class Program
{
    static void Main()
    {
        Produto produto = new Produto();

        Console.WriteLine("Entre os dados do produto:");
        Console.Write("Nome: ");
        produto.Nome = Console.ReadLine();
        Console.Write("Preço: ");
        produto.Preco = double.Parse(Console.ReadLine());
        Console.Write("Quantidade no estoque: ");
        produto.Quantidade = int.Parse(Console.ReadLine());
        // Jhonathan Turial - RU: 3993727
        Console.WriteLine($"Dados do produto: {produto.Nome}, $ {produto.Preco:F2}");
        Console.WriteLine($"{produto.Quantidade} unidades");
        Console.WriteLine($"Total: $ {produto.ValorTotalEmEstoque():F2}");

        Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
        int numeroProdutosAdicionar = int.Parse(Console.ReadLine());

        while (numeroProdutosAdicionar % 10 != 0)
        {
            Console.WriteLine("O último dígito do RU do aluno não é zero. Tente novamente.");
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            numeroProdutosAdicionar = int.Parse(Console.ReadLine());
        }

        produto.AdicionarProduto(numeroProdutosAdicionar);

        Console.WriteLine($"Dados atualizados: {produto.Nome}, $ {produto.Preco:F2}, {produto.Quantidade} unidades, Total: $ {produto.ValorTotalEmEstoque():F2}");

        Console.Write("Digite o número de produtos a ser removido do estoque: ");
        int numeroProdutosRemover = int.Parse(Console.ReadLine());

        produto.RemoverProdutos(numeroProdutosRemover);

        Console.WriteLine($"Dados atualizados: {produto.Nome}, $ {produto.Preco:F2}, {produto.Quantidade} unidades, Total: $ {produto.ValorTotalEmEstoque():F2}");
    }
}
