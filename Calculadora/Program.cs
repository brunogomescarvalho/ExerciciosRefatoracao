namespace Calculadora
{
    public class Program
    {
        static decimal PrimeiroValor;
        static decimal SegundoValor;
        static string[] Historico = new string[100];
        static bool Continuar = true;
        static string? Expressao;
        static int Posicao = -1;
        static int Opcao;

        static void Main(string[] args)
        {
            while (Continuar)
            {
                Opcao = Menu();

                if (VerificarSeEOperacao())
                {
                    PrimeiroValor = SolicitarEConverterValor("Informe o primeiro valor:");
                    SegundoValor = SolicitarEConverterValor("Informe o segundo valor:");

                    if (!VerificarNumeroValido())
                    {
                        MostrarMensagem("Para dividir, o segundo número não pode ser Zero!", true);
                        continue;
                    }
                }

                switch (Opcao)
                {
                    case 1:
                        Somar();
                        break;

                    case 2:
                        Subtrair();
                        break;

                    case 3:
                        Dividir();
                        break;

                    case 4:
                        Multiplicar();
                        break;

                    case 5:
                        GerarTabuada();
                        break;

                    case 6:
                        MostrarOperacoesEfetuadas();
                        break;

                    case 7:
                        Sair();
                        break;

                    default:
                        MostrarMensagem("Opção Inválida", true);
                        break;
                }
            }
        }

        static decimal SolicitarEConverterValor(string mensagem)
        {
            Console.Clear();
            Console.Write(mensagem);
            return Convert.ToDecimal(Console.ReadLine());
        }

        static void MostrarMensagem(string mensagem, bool ehErro)
        {
            Console.Clear();

            if (ehErro)
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadKey();

        }

        static void FinalizarOperacao()
        {
            IncluirNoHistorico();
            MostrarMensagem(Expressao!, false);
        }

        static void Somar()
        {
            Expressao = $"{PrimeiroValor} + {SegundoValor} = {PrimeiroValor + SegundoValor}";
            FinalizarOperacao();
        }

        static void Subtrair()
        {
            Expressao = $"{PrimeiroValor} - {SegundoValor} = {PrimeiroValor - SegundoValor}";
            FinalizarOperacao();
        }

        static void Dividir()
        {
            Expressao = $"{PrimeiroValor} / {SegundoValor} = {Math.Round((PrimeiroValor / SegundoValor), 2)}";
            FinalizarOperacao();
        }

        static void Multiplicar()
        {
            Expressao = $"{PrimeiroValor} x {SegundoValor} = {PrimeiroValor * SegundoValor}";
            FinalizarOperacao();
        }

        static void GerarTabuada()
        {
            Console.Clear();
            System.Console.WriteLine("Digite o número da tabuada que gostaria de gerar");
            var opcao = int.Parse(Console.ReadLine()!);

            for (int i = 0; i <= 10; i++)
            {
                System.Console.WriteLine($"{opcao} x {i} = {opcao * i}");
            }

            Console.ReadKey();
        }

        static void MostrarOperacoesEfetuadas()
        {
            Console.Clear();
            System.Console.WriteLine(" -- Operações Salvas -- \n");

            if (Posicao < 0)
                MostrarMensagem("Nenhuma operação efetuada até o momento!", true);

            else
            {
                foreach (string expressao in Historico)
                {
                    if (expressao != null)
                        Console.WriteLine(expressao);
                }
                Console.ReadKey();
            }
        }

        static bool VerificarSeEOperacao()
        {
            return (Opcao == 1 || Opcao == 2 || Opcao == 3 || Opcao == 4);
        }

        static bool VerificarNumeroValido()
        {
            return (Opcao == 3 && SegundoValor == 0) == false;
        }


        static void IncluirNoHistorico()
        {
            Posicao++;
            Historico[Posicao] = Expressao!;
        }

        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("--- [CALCULADORA] ---\nSelecione uma Opção\n");
            Console.WriteLine("[1] Adição");
            Console.WriteLine("[2] Subtração");
            Console.WriteLine("[3] Divisão");
            Console.WriteLine("[4] Multiplicação");
            Console.WriteLine("[5] Gerar Tabuada");
            Console.WriteLine("[6] Mostrar Operações Efetuadas");
            Console.WriteLine("[7] Sair");

            return int.Parse(Console.ReadLine()!);
        }

        static void Sair()
        {
            Continuar = false;
        }


    }

}