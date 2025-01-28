using System;
using DesafioAutoMind.Entities;
using System.Collections.Generic;
using DesafioAutoMind.Services;


class Program
{
    static List<User> users = new List<User>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Buscar Usuário");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    UserService.CadastrarUsuario(users);
                    break;
                case "2":
                    UserService.ListarUsuarios(users);
                    break;
                case "3":
                    UserService.BuscarUsuario(users);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }
}
