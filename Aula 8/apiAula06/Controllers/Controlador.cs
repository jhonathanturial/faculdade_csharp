using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace apiAula06.Controllers
{
    [ApiController]
    [Route("api")]
    public class ControladorController : ControllerBase
    {

        [HttpGet("pitagoras/calculo")]
        public ActionResult<object> CalcularPitagoras(int ru, string nome)
        {
            // Extrair o primeiro dígito (B) e o segundo dígito (C) do RU
            int b = (ru / 1000000) % 10; // Primeiro dígito
            int c = (ru / 100000) % 10;   // Segundo dígito

            // Calcular o valor de A com base na fórmula C*C = A*A + B*B
            double a = Math.Sqrt(c * c - b * b);

            // Verificar se os valores formam um triângulo pitagórico
            bool eTrianguloPitagorico = ETrianguloPitagorico(a, b, c);

            var informacoesPitagoricas = new { a, b, c };

            if (eTrianguloPitagorico)
            {
                return Ok($"Resultado: É pitagórico. valor de A: {a}, B: {b}, C: {c}.\nNome: {nome} \nRU: {ru}");
            }
            else
            {
                return Ok($"Resultado: É pitagórico. valor de A: {a}, B: {b}, C: {c}.\nNome: {nome} \nRU: {ru}");
            }
        }


        // Função para verificar se os valores formam um triângulo pitagórico
        private bool ETrianguloPitagorico(double a, double b, double c)
        {
            return a * a + b * b == c * c || b * b + c * c == a * a || c * c + a * a == b * b;
        }
    }
}
