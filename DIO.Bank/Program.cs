using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
          Conta minhaConta = new Conta(TipoConta.PessoaFisica,200,300,"Maria");
          Console.WriteLine(minhaConta.ToString());

          string opcaoUsuario = ObterOpcaoUsuario();

          while(opcaoUsuario!="X")
          {
              switch(opcaoUsuario)
              {
                case "1":
                    ListarContas();
                    break;
                case "2":
                    InserirConta();
                    break;
                case "3":
                    Transferir();
                    break;
                case "4":
                    Sacar();
                    break;
                case "5":
                    Depositar();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

              }
              opcaoUsuario = ObterOpcaoUsuario();
          }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista Contas");
            int numerador = 0;
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            else
            {
                foreach(Conta c in listaContas)
                {
                    Console.WriteLine($"#{numerador} - "+c);
                    numerador++;
                }
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");
            Console.Write("Digite 1 para Conta Fisica e 2 para Conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o saldo inicial da conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o crédito da conta: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            //quando se informa o parametro exemplo nome: entradaNome você pode passar os parâmetros fora de ordem
            // para a classe.
            Conta novaConta = new Conta (nome: entradaNome,
                                        tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito);
            listaContas.Add(novaConta);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
            //pede o indice para o usuario para buscalo na lista de contas e aplica
            //o método Sacar() da classe Conta
            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaO = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da conta de destino: ");
            int indiceContaD = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferido = double.Parse(Console.ReadLine());
            listaContas[indiceContaO].Transferir(valorTransferido,listaContas[indiceContaD]);

        }


        private static String ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank ao seu Dispor");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
