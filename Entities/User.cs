
namespace DesafioAutoMind.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public User(string name, string email, int age)
        {
            Name = name;
            Email = email;
            Age = age;
        }

        public override string ToString()
        {
            return $"Nome: {Name}, E-mail: {Email}, Idade: {Age}";
        }

    }
}
