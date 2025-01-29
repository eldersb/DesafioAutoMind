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
            bool isNameValid = false;

            while(!isNameValid)
            {
                Console.Write("Digite o nome: ");
                name = Console.ReadLine();

                if (name == null || name.Length >= 3) 
                {
                    isNameValid = true; // Nome é válido
                }
                else
                {
                    Console.WriteLine("Nome inválido. O nome deve ter pelo menos 3 caracteres.");
                }
            }

            string email = string.Empty;
            bool isEmailValid = false;

            while (!isEmailValid)
            {
                Console.Write("Digite o e-mail: ");
                email = Console.ReadLine();

                // Verifica se o e-mail contém "@" e "."
                if (email.Contains("@") && email.Contains("."))
                {
                    isEmailValid = true; // E-mail é válido
                }
                else
                {
                    Console.WriteLine("E-mail inválido.");
                }
            }

            Console.Write("Digite a idade: ");
            int age;
            // Loop que valida a entrada do usuário. Tenta converter a string para um int, retornando true se for bem sucedida 
            // e false se falhar (Um usuário digitar algo diferente de um número)
            while (!int.TryParse(Console.ReadLine(), out age) || age <= 0) 
            {
                Console.WriteLine("Idade inválida.");
                Console.Write("Digite a idade: ");
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

            // Percorre(itera) os elementos na lista users, para cada usuário na lista, será executado o bloco
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
