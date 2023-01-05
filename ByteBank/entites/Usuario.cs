﻿using ByteBank.exception;

namespace ByteBank.entites
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public Conta Conta { get; set; }
        public string Cpf { get; set; }

        public Usuario()
        {
        }
        public Usuario(string cpf, string senha)
        {
            Cpf = cpf;
            Senha = senha;
        }

        public Usuario(string nomeTitular, string cpf, string senha)
        {
            Nome = nomeTitular;
            Cpf = cpf;
            Senha = senha;
            Conta = new Conta();
        }
        public Usuario(string cpf)
        {
            Cpf = cpf;
        }

        public void InsercaoUsuario(List<Usuario> usuarios, List<Conta> contas)
        {
            Usuario usuario;
            Conta conta;
            string nome, numCpf, senha, temp = "";

            Console.Write("Nome do usuário: ");
            nome = Console.ReadLine();
            Console.Write("Cpf do usuário: ");
            numCpf = Console.ReadLine();
            Console.Write("Crie a senha do usuário: ");
            senha = Console.ReadLine();
            usuario = new Usuario(nome, numCpf, senha);

            if (usuarios.Count == 0)
            {
                usuarios.Add(usuario);
                conta = new Conta(usuario.Conta.Agencia, usuario.Conta.NumConta);
                contas.Add(conta);
                temp = "Usuário cadastrado com sucesso!";
            }
            else
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (usuario.Cpf.Equals(usuarios[i].Cpf))
                    {
                        temp = "Cpf já está cadastrado!!! \nInserção não efetuada...";
                    }
                    else
                    {
                        if (!usuario.Cpf.Equals(usuarios[i].Cpf))
                        {
                            usuarios.Add(usuario);
                            conta = new Conta(usuario.Conta.Agencia, usuario.Conta.NumConta);
                            contas.Add(conta);
                            temp = "Usuário cadastrado com sucesso!";
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(temp);
        }
        public void RemoverUsuario(List<Usuario> usuarios, List<Conta> contas)
        {
            Usuario usuario;
            string cpf, aux = "";

            if (usuarios.Count == 0)
            {
                aux = "Não há usuários cadastrados...";
            }
            else
            {
                Console.Write("Cpf do usuário: ");
                cpf = Console.ReadLine();
                usuario = new Usuario(cpf);

                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (usuario.Cpf.Equals(usuarios[i].Cpf))
                    {
                        contas.RemoveAt(i);
                        usuarios.RemoveAt(i);
                        aux = "Usuário removido com sucesso!";
                        break;
                    }
                    else
                    {
                        aux = "Usuário não encontrado! \nRemoção não efetuada...";
                    }
                }
            }
            Console.WriteLine(aux);
        }
        public void ExibeInfoUsuario(List<Usuario> usuarios)
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados...");
            }
            else
            {
                Usuario usuario;
                string cpf, aux = "";

                Console.Write("Cpf do usuário: ");
                cpf = Console.ReadLine();
                usuario = new Usuario(cpf);

                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (usuario.Cpf.Equals(usuarios[i].Cpf))
                    {
                        aux = $"Nome: {usuarios[i].Nome}\n" +
                            $"Cpf: {usuarios[i].Cpf}\n" +
                            $"Ag: {usuarios[i].Conta.Agencia} Conta:{usuarios[i].Conta.NumConta}";
                        break;
                    }
                    else
                    {
                        aux = "Usuário não encontrado...";
                    }
                }
                Console.WriteLine(aux);
            }
        }
        public void LoginUsuario(List<Usuario> usuarios, List<Conta> contas)
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Não há contas/usuários cadastrados...");
            }
            else
            {
                Usuario usuario;
                string cpf, senha, nome;
                char esc, opc;
                double valor, saque;

                Console.Write("Cpf do usuário: ");
                cpf = Console.ReadLine();
                Console.Write("Senha do usuário: ");
                senha = Console.ReadLine();
                usuario = new Usuario(cpf, senha);
                string aux = "";

                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (usuario.Cpf.Equals(usuarios[i].Cpf) && usuario.Senha.Equals(usuarios[i].Senha))
                    {
                        Console.WriteLine("Usuário logado com sucesso!");
                        aux = "Usuário logado com sucesso!";

                        do
                        {
                            Console.WriteLine("-------------------------------------------------------------------------");
                            MenuUsuario();
                            try
                            {
                                esc = char.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                throw new Excecao("Você deveria digitar uma opção válida... Entre 0 - 5!");
                            }
                            Console.WriteLine("-------------------------------------------------------------------------");

                            switch (esc)
                            {
                                case '1':
                                    Console.WriteLine("O que deseja alterar? 1 - Nome | 2 - Senha | 0 - Menu anterior");
                                    try
                                    {
                                        opc = char.Parse(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        throw new Excecao("Você deveria digitar uma opção válida... Entre 0 - 2!");
                                    }
                                    switch (opc)
                                    {
                                        case '1':
                                            Console.Write("Digite o novo nome: ");
                                            nome = Console.ReadLine();
                                            usuarios[i].Nome = nome;
                                            Console.WriteLine("Nome alterado com sucesso.");
                                            break;
                                        case '2':
                                            Console.Write("Digite a nova senha: ");
                                            senha = Console.ReadLine();
                                            usuarios[i].Senha = senha;
                                            Console.WriteLine("Senha alterada com sucesso.");
                                            break;
                                        case '0':
                                            Console.WriteLine("Retornando ao menu anterior!");
                                            break;
                                        default:
                                            Console.WriteLine("Opção inválida... Digite uma opção válida!");
                                            break;
                                    }
                                    break;

                                case '2':
                                    try
                                    {
                                        Console.Write("Digite o valor do depósito: ");
                                        valor = double.Parse(Console.ReadLine());
                                        usuarios[i].Conta.Saldo = (usuarios[i].Conta.Saldo + valor);
                                        Console.WriteLine("Deposito realizado com sucesso!");
                                    }
                                    catch (FormatException)
                                    {
                                        throw new Excecao("Erro... Você deveria digitar um valor numérico para efetuar o depósito!!!!");
                                    }
                                    break;

                                case '3':
                                    try
                                    {
                                        Console.Write("Digite o valor do saque: ");
                                        saque = double.Parse(Console.ReadLine());

                                        if (usuarios[i].Conta.Saldo >= saque)
                                        {
                                            usuarios[i].Conta.Saldo = (usuarios[i].Conta.Saldo - saque);
                                            aux = "Saque realizado com sucesso";
                                        }
                                        else
                                        {
                                            aux = "Saldo insuficiente para saque!";
                                        }
                                        Console.WriteLine(aux);
                                        aux = " ";
                                    }
                                    catch (FormatException)
                                    {
                                        throw new Excecao("Erro... Você deveria digitar um valor numérico para efetuar o saque!!!!");
                                    }
                                    break;

                                case '4':
                                    Console.Write($"Saldo em conta: R$ {usuarios[i].Conta.Saldo:F2}");
                                    Console.WriteLine();
                                    break;

                                case '5':
                                    try
                                    {
                                        Console.Write("Digite o número da conta para transferência: ");
                                        int numConta = int.Parse(Console.ReadLine());
                                        string temp = "";

                                        for (int j = 0; j < contas.Count; j++)
                                        {
                                            if (numConta == usuarios[j].Conta.NumConta)
                                            {
                                                temp = "Conta encontrada!";
                                            }
                                            else
                                            {
                                                temp = "Conta não encontrada!";
                                            }
                                        }
                                        Console.WriteLine(temp);
                                        for (int j = 0; j < contas.Count; j++)
                                        {
                                            if (numConta == usuarios[j].Conta.NumConta)
                                            {
                                                Console.Write("Digite o valor a ser transferido: ");
                                                double valorTransf = double.Parse(Console.ReadLine());
                                                if (usuarios[i].Conta.Saldo >= valorTransf)
                                                {
                                                    usuarios[i].Conta.Saldo = (usuarios[i].Conta.Saldo - valorTransf);
                                                    usuarios[j].Conta.Saldo = (usuarios[j].Conta.Saldo + valorTransf);
                                                    aux = "Transferência efetuada com sucesso!";
                                                }
                                                else
                                                {
                                                    aux = "Transferência nao efetuada... Saldo insuficiente!";
                                                }
                                            }
                                            else
                                            {
                                                aux = "Transação não efetuada!";
                                            }
                                        }
                                        Console.WriteLine(aux);
                                        aux = " ";
                                    }
                                    catch (FormatException)
                                    {
                                        throw new Excecao("Erro... Você deveria digitar um valor numérico para efetuar a transferência!!!!");
                                    }
                                    break;

                                case '0':
                                    Console.WriteLine("Retornando ao menu anterior.");
                                    break;

                                default:
                                    Console.WriteLine("Opção inválida... Digite uma opção válida!");
                                    break;
                            }
                        } while (esc != '0');
                    }
                }
                if (aux.Equals(" "))
                {
                    Console.Write("");
                }
                else if (!aux.Equals("Usuário logado com sucesso!"))
                {
                    Console.WriteLine("Cpf e/ou senha incorreto(s)");
                }
            }
        }
        public void MenuUsuario()
        {
            Console.WriteLine("1 - Alteração de dados do usuário");
            Console.WriteLine("2 - Efetuar deposito");
            Console.WriteLine("3 - Efetuar saque");
            Console.WriteLine("4 - Exibir saldo da conta");
            Console.WriteLine("5 - Tranferência entre contas");
            Console.WriteLine("0 - Sair do menu do usuário");
            Console.Write("Digite a opção desejada: ");
        }
    }
}
