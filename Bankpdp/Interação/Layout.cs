using Bankpdp.Interação;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bankpdp.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;
         
        public static void TelaPrincipal() //Metodo
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Red;

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

            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();
            pessoa.SetNome(nome);
            pessoa.setCPF(cpf);
            pessoa.setSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine(" CONTA CADASTRADA COM SUCESSO ");
            Thread.Sleep(1000);
            TelaContaLogada(pessoa);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            
            Console.WriteLine("  Digite o CPF:   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("  Digite sua senha:  ");
            string senha = Console.ReadLine();

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (pessoa!= null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("  pessoa não cadastrada  ");
                Console.WriteLine();
            }

        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgTelaBemVindo = $"{pessoa.Nome} | Conta : {pessoa.Conta.GetCodigoDoBanco()} + " +
                $"| Agencia: {pessoa.Conta.GetNumeroAgencia()} | conta: {pessoa.Conta.GetNumeroConta()}"; 
            
            Console.WriteLine("");
            Console.WriteLine($"     SEJA BEM VINDO,{msgTelaBemVindo} "); //CONCATENAÇÃO 
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine(" DIGITE A OPÇÃO DESEJADA ");
            Console.WriteLine("        ");
            Console.WriteLine("1- REALIZAR UM DEPOSITO");
            Console.WriteLine("2 - REALIZAR UM SAQUE");
            Console.WriteLine("3 - CONSULTAR O SALDO ");
            Console.WriteLine("4- EXTRATO   ");
            Console.WriteLine("5 - SAIR ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção invalida");
                    break;


            }
        }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("    DIGITE O VALOR DO DEPOSITO:    ");
            Double valor = double.Parse(Console.ReadLine());

            pessoa.Conta.Deposita(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("  Deposito realizado com sucesso  ");

            OpcaoVoltarLogado(pessoa);

        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("    DIGITE O VALOR DO SAQUE:    ");
            Double valor = double.Parse(Console.ReadLine());

            bool okSaque = pessoa.Conta.saca(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);
            Console.WriteLine("");
            if (okSaque)
            {
                Console.WriteLine("  SAQUE REALIZADO COM SUCESSO  ");
            }
            else
            {
                Console.WriteLine(" SALDO INSUFICIENTE ");
            }
            
            
            OpcaoVoltarLogado(pessoa);

        }

        private static void TelaSaldo( Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine($"    SEU SALDO É:{pessoa.Conta.ConsultaSaldo()}     ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            if (pessoa.Conta.Extrato().Any())
            {
                //mostrar extrato

                Double total = pessoa.Conta.Extrato().Sum(x => x.Valor);
                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Data de movimentação: {extrato.Data.ToString("dd/mm/yyyy  HH:mm:ss")} ");
                    Console.WriteLine($"Tipo de movimentação: {extrato.Descricao} ");
                    Console.WriteLine($"Valor {extrato.Valor}");
                }

                Console.WriteLine("");
                Console.WriteLine($" SUB TOTAL {total} ");
            }
            else
            {
                Console.WriteLine("   NÃO HÁ CONTRATO A SER EXIBIDO ");
            }

            OpcaoVoltarLogado(pessoa);
        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("  ENTRE COM UMA OPÇÃO ABAIXO  ");
            Console.WriteLine("");
            Console.WriteLine(" 1- VOLTAR PARA MINHA CONTA  ");
            Console.WriteLine("");
            Console.WriteLine(" 2 - SAIR  ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            
                TelaContaLogada(pessoa);
                else
                    TelaPrincipal();
            
        }

        private static void OpcaoVoltarDeslogado()
        {
            Console.WriteLine("  ENTRE COM UMA OPÇÃO ABAIXO  ");
            Console.WriteLine("");
            Console.WriteLine(" 1- VOLTAR PARA O MENU PRINCIPAL  ");
            Console.WriteLine("");
            Console.WriteLine(" 2 - SAIR  ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)

                TelaPrincipal();
            else
            {
                Console.WriteLine("       OPÇÃO INVALIDA    ");
            }
        }
    }
}
