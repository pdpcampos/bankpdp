using System;
using System.Collections.Generic;
using System.Text;

namespace Bankpdp.Classes
{
    public class Layout
    {
        private static int opcao = 0;
         
        public static void TelaPrincipal() //Metodo
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Clear();

            Console.WriteLine("                    ");
            Console.WriteLine("  Informe a opção desejada");
            Console.WriteLine("  1- Criar Conta   ");
            Console.WriteLine("  2 - Entrar com cpf e senha  ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;

                case 2:
                    TelaLogin();
                    break;
                default:
                    Console.WriteLine("Opção Invalida");
                    break;
            }
        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("   Digite seu nome  ");
            string nome = Console.ReadLine();
            Console.WriteLine("   Digite o seu CPF  ");
            string cpf = Console.ReadLine();
            Console.WriteLine("   Digite sua senha  ");
            string senha = Console.ReadLine();

            Console.WriteLine(nome);
            Console.WriteLine(cpf);
            Console.WriteLine(senha);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            
            Console.WriteLine("  Digite o CPF:   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("  Digite sua senha:  ");
            string senha = Console.ReadLine();



        }
    }
}
