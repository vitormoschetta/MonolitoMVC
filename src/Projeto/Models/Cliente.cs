using System;
using System.ComponentModel.DataAnnotations;
using Flunt.Validations;

namespace Projeto.Models
{
    public class Cliente : Entity
    {
        public Cliente(string nome, DateTime? dataNascimento, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
        }

        public Cliente(Guid id, string nome, DateTime? dataNascimento, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
        }

        public string Nome { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string Cpf { get; private set; }


        public void Update(string nome, DateTime? dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Nome, 3, "Nome", "Nome tem que ter pelo menos 3 caracteres")
                    .HasLen(Cpf, 11, "CPF", "CPF deve conter 11 digitos")
            );
        }
    }
}