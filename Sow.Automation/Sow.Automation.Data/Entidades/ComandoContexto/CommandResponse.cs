using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ComandoContexto
{
    public class CommandResponse
    {
        public CommandResponse(bool success = false, string message = "Commit Efetuado com Sucesso!")
        {
            Success = success;
            Message = message;
        }
        public static CommandResponse Ok = new CommandResponse() { Success = true };
        public static CommandResponse Fail = new CommandResponse() { Success = false };
        public string Message { get; private set; }
        public bool Success { get; private set; }
    }
}
