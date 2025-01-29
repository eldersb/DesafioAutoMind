using DesafioAutoMind.Entities;
using System;
using System.Collections.Generic;

namespace DesafioAutoMind.Services
{
    public static class UserService
    {
        // Função para cadastrar um novo usuário
        public static void RegisterUsers(List<User> users)
        {
            Console.WriteLine("\nCadastro de Usuário");

            string name = string.Empty;
            while (true)
            {
                try
                {
                    Console.Write("Digite o nome: ");
                    name = Console.ReadLine();

                    // Verifica se já existe um usuário com o mesmo nome
                    if (users.Exists(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new ArgumentException("Já existe um usuário cadastrado com esse nome.");
                    }

                    // Verifica se o nome é nulo ou menor que três
                    if (string.IsNullOrEmpty(name) || name.Length < 3)
                    {
                        throw new ArgumentException("O nome deve ter pelo menos 3 caracteres.");
                    }
                    break; // Se não ocorrer exceção, o nome é válido
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string email = string.Empty;
            while (true)
            {
                try
                {
                    Console.Write("Digite o e-mail: ");
                    email = Console.ReadLine();

                    // Verifica se o email contém '@' e '.'
                    if (!email.Contains("@") || !email.Contains("."))
                    {
                        throw new ArgumentException("E-mail inválido.");
                    }
                    break; // Se não ocorrer exceção, o e-mail é válido
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int age;
            while (true)
            {
                try
                {
                    Console.Write("Digite a idade: ");
                    string input = Console.ReadLine();

                    // Converte o input para um int, sendo que essa conversão só será true se ela falhar
                    // (input não for um número inteiro válido)
                    if (!int.TryParse(input, out age) || age <= 0)
                    {
                        throw new ArgumentException("Idade inválida. A idade deve ser um número positivo.");
                    }
                    break; // Se não ocorrer exceção, a idade é válida
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Instancia um novo usuário e insere na lista de usuários
            User user = new User(name, email, age);
            users.Add(user);

            Console.WriteLine("\nUsuário cadastrado com sucesso!");
        }

        // Função para listar os usuários cadastrados
        public static void ListUsers(List<User> users)
        {
            Console.WriteLine("\nLista de Usuários:");

            if (users.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            // Itera sobre cada usuário na lista
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }

        // Função para buscar um usuário pelo nome
        public static void SearchUsers(List<User> users)
        {
            Console.WriteLine("\nBuscar Usuário");

            Console.Write("Digite o nome do usuário: ");
            string searchName = Console.ReadLine();

            // Compara o nome de cada usuário com o fornecido pelo 'searchName' ignorando diferença entre
            // maiúsculas e minúsculas.
            var userFound = users.Find(u => u.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (userFound != null)
            {
                Console.WriteLine("\nUsuário encontrado:");
                Console.WriteLine(userFound);
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }
    }
}
