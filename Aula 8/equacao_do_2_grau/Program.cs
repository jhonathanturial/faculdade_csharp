using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Calculadora de Raízes Quadráticas");

        while (true)
        {
            // Ler o RU do usuário
            Console.Write("Digite seu RU de 7 números (ou pressione Ctrl+C para sair): ");
            string ru = Console.ReadLine();

            // Verificar se a entrada tem 7 dígitos
            if (ru.Length != 7 || !IsNumeric(ru))
            {
                Console.WriteLine("O RU deve conter exatamente 7 dígitos numéricos.");
                continue;
            }

            // Extrair os valores de A, B e C
            char a = ru[0];
            char b = ru[1];
            char c = ru[2];

            double coeficienteA = double.Parse(a.ToString());
            double coeficienteB = double.Parse(b.ToString());
            double coeficienteC = double.Parse(c.ToString());

            // Calcular o delta
            double delta = coeficienteB * coeficienteB - 4 * coeficienteA * coeficienteC;

            // Verificar se é possível calcular as raízes
            if (coeficienteA == 0)
            {
                Console.WriteLine("O valor de A não pode ser zero. Impossível calcular.");
            }
            else if (delta < 0)
            {
                Console.WriteLine("Delta é negativo. Impossível calcular as raízes reais.");
            }
            else
            {
                // Calcular as raízes usando a fórmula de Bhaskara
                double sqrtDelta = Math.Sqrt(delta);
                double x1 = (-coeficienteB + sqrtDelta) / (2 * coeficienteA);
                double x2 = (-coeficienteB - sqrtDelta) / (2 * coeficienteA);
                Console.WriteLine($"Os valores de A, B e C a partir do RU são:\nA = {coeficienteA}\nB = {coeficienteB}\nC = {coeficienteC}");
                Console.WriteLine($"As raízes da equação são:\nx1 = {x1}\nx2 = {x2}");
            }
        }
    }

    static bool IsNumeric(string input)
    {
        return int.TryParse(input, out _);
    }
}
