using System.Collections.Generic;
using Flunt.Notifications;

namespace Projeto.Models
{
    public class ResultMessage
    {
        public ResultMessage() { }

        public ResultMessage(bool success, string message, IReadOnlyCollection<Notification> data, object Object)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public IReadOnlyCollection<Notification> Data { get; set; } // Retornar uma lista com notificações
        public object Object { get; set; } // Retorna o objeto cadastrado, atualizado ou excluído.
    }
}