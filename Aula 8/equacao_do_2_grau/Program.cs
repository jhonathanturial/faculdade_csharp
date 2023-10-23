using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Calculadora de Raízes Quadráticas");

        // Ler os valores de a, b e c
        double a, b, c;
        if (!TryGetCoefficient("a", out a) || !TryGetCoefficient("b", out b) || !TryGetCoefficient("c", out c))
        {
            Console.WriteLine("Valores inválidos. Certifique-se de inserir números válidos para 'a', 'b' e 'c'.");
            return;
        }

        // Calcular o delta
        double delta = b * b - 4 * a * c;

        // Verificar se é possível calcular as raízes
        if (a == 0)
        {
            Console.WriteLine("O valor de 'a' não pode ser zero. Impossível calcular.");
        }
        else if (delta < 0)
        {
            Console.WriteLine("Delta é negativo. Impossível calcular as raízes reais.");
        }
        else
        {
            // Calcular as raízes usando a fórmula de Bhaskara
            double sqrtDelta = Math.Sqrt(delta);
            double x1 = (-b + sqrtDelta) / (2 * a);
            double x2 = (-b - sqrtDelta) / (2 * a);
            Console.WriteLine($"As raízes da equação são:\nx1 = {x1}\nx2 = {x2}");
        }
    }

    static bool TryGetCoefficient(string coefficientName, out double coefficient)
    {
        Console.Write($"Digite o valor de {coefficientName}: ");
        return double.TryParse(Console.ReadLine(), out coefficient);
    }
}
