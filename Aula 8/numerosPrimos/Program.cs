using System;
using System.Threading;

class ImpressoraNumerosPrimos
{
    static bool EPrimo(int num)
    {
        if (num < 2)
            return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    static void ImprimirPrimosNoIntervalo(int inicio, int fim, ManualResetEvent doneEvent, int[] resultados)
    {
        int[] primos = new int[fim - inicio + 1];
        int contador = 0;
        for (int num = inicio; num <= fim; num++)
        {
            if (EPrimo(num))
            {
                primos[contador] = num;
                contador++;
            }
        }

        // Copia os resultados para o array compartilhado
        Array.Copy(primos, 0, resultados, inicio, contador);
        doneEvent.Set();
    }

    static void Main(string[] args)
    {
        Console.Write("Digite os dois últimos dígitos do seu RU: ");
        string ruCompleto = Console.ReadLine();

        // Extrair os dois últimos dígitos do RU
        int ultimosDigitosRU;
        if (ruCompleto.Length >= 2 && int.TryParse(ruCompleto.Substring(ruCompleto.Length - 2), out ultimosDigitosRU))
        {
            int numThreads = ultimosDigitosRU / 10;
            int[] resultados = new int[ultimosDigitosRU + 1];

            ManualResetEvent[] doneEvents = new ManualResetEvent[numThreads + 1];

            for (int i = 0; i <= numThreads; i++)
            {
                int inicio = i * 10;
                int fim = i == numThreads ? ultimosDigitosRU : inicio + 9;
                doneEvents[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    ImprimirPrimosNoIntervalo(inicio, fim, doneEvents[(int)state], resultados);
                }, i);
            }

            WaitHandle.WaitAll(doneEvents);

            // Imprime os resultados em ordem sequencial
            for (int i = 0; i <= ultimosDigitosRU; i++)
            {
                if (resultados[i] != 0)
                {
                    Console.Write(resultados[i] + ", ");
                }
            }
        }
        else
        {
            Console.WriteLine("Os dois últimos dígitos do RU não puderam ser extraídos corretamente.");
        }
    }
}
