using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace Projeto.Models
{
    public class DataResult
    {
        public DataResult() { }

        public DataResult(bool success, string message, IReadOnlyCollection<Notification> notifications, Object objeto)
        {
            Success = success;
            Message = message;
            Notifications = notifications;
            Objeto = objeto;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; } // Retornar uma lista com notificações
        public Object Objeto { get; set; } // Retorna o objeto cadastrado, atualizado ou excluído.
    }
}