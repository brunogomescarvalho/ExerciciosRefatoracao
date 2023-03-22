using System;
namespace DiamanteDeX
{
    public class Program
    {
        static int EspacoMargem;
        static int QuantidadeXLinhaCentral;
        static int QuantidadeXPorLinha;
        static int PosicaoPrimeiroX;
        static bool Continuar = true;

        public static void Main(string[] args)
        {
            while (Continuar)
            {
                QuantidadeXLinhaCentral = ReceberTamanhoTriangulo();

                if (!EhNumeroImpar())
                    continue;

                CriarTrianguloSuperior();
                CriarLinhaCentral();
                CriarTrianguloInferior();
                Console.ReadKey();

            }

        }

        static int ReceberTamanhoTriangulo()
        {
            Console.Clear();
            Console.WriteLine("--- Triângulo de X ---\n");
            Console.WriteLine("Informe o tamanho do triângulo que gostaria de construir");
            return Convert.ToInt32(Console.ReadLine());
        }

        static bool EhNumeroImpar()
        {
            if (QuantidadeXLinhaCentral % 2 == 0)
            {
                Console.WriteLine("\nPara que o triângulo seja criado com sucesso o número precisa ser ímpar");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        static void CriarTrianguloSuperior()
        {
            PosicaoPrimeiroX = (QuantidadeXLinhaCentral) / 2;
            QuantidadeXPorLinha = 1;
            EspacoMargem = PosicaoPrimeiroX - 1;

            for (int i = 0; i <= PosicaoPrimeiroX - 1; i++)
            {
                for (int h = 0; h <= EspacoMargem; h++)
                {
                    Console.Write(" ");
                }
                for (int h = 0; h < QuantidadeXPorLinha; h++)
                {
                    Console.Write("X");
                }

                Console.WriteLine();
                EspacoMargem--;
                QuantidadeXPorLinha += 2;
            }

        }

        static void CriarLinhaCentral()
        {
            for (int i = 0; i < QuantidadeXLinhaCentral; i++)
            {
                Console.Write("X");
            }
            Console.WriteLine();
        }

        static void CriarTrianguloInferior()
        {
            PosicaoPrimeiroX = (QuantidadeXLinhaCentral) / 2;
            QuantidadeXPorLinha = QuantidadeXLinhaCentral - 2;
            EspacoMargem = 1;

            for (int i = 0; i < PosicaoPrimeiroX; i++)
            {
                for (int h = 0; h < EspacoMargem; h++)
                {
                    Console.Write(" ");
                }
                for (int h = 0; h < QuantidadeXPorLinha; h++)
                {
                    Console.Write("X");
                }

                Console.WriteLine();
                EspacoMargem++;
                QuantidadeXPorLinha -= 2;
            }
        }
    }
}
