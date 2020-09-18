using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace Projeto.Models
{
    public class Entity : Notifiable
    {
        public Entity(Guid id)
        {
            Id = id;
        }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }


    }
}