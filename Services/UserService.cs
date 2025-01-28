using DesafioAutoMind.Entities;
using System;
using System.Collections.Generic;

namespace DesafioAutoMind.Services
{
    public static class UserService
    {
        // Função para cadastrar um novo usuário
        public static void CadastrarUsuario(List<User> users)
        {
            Console.WriteLine("\nCadastro de Usuário");

            Console.Write("Digite o nome: ");
            string name = Console.ReadLine();

            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine();

            Console.Write("Digite a idade: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.WriteLine("Idade inválida. Por favor, insira um número válido.");
                Console.Write("Digite a idade: ");
            }

            User user = new User(name, email, age);
            users.Add(user);

            Console.WriteLine("\nUsuário cadastrado com sucesso!");
        }

        // Função para listar os usuários cadastrados
        public static void ListarUsuarios(List<User> users)
        {
            Console.WriteLine("\nLista de Usuários:");

            if (users.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }

        // Função para buscar um usuário pelo nome
        public static void BuscarUsuario(List<User> users)
        {
            Console.WriteLine("\nBuscar Usuário");

            Console.Write("Digite o nome do usuário: ");
            string nomeBusca = Console.ReadLine();

            var usuarioEncontrado = users.Find(u => u.Name.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

            if (usuarioEncontrado != null)
            {
                Console.WriteLine("\nUsuário encontrado:");
                Console.WriteLine(usuarioEncontrado);
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }
    }
}
