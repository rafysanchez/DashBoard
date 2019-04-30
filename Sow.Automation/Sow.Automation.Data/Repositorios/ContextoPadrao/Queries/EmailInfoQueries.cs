using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios.ContextoPadrao.Queries
{
    public class EmailInfoQueries
    {
        public static string SelectEmailInfoPorId(string Id)
        {
            return $"SELECT IdProcesso,Assunto ,Remetente ,Destinatario,Destinatario_CC ,Destinatario_CO FROM EmailInfo Where IdProcesso = '{Id}'";
        }
        public static string DeleteEmailInfo(string id)
        {
            return $"DELETE FROM EmailInfo  Where IdProcesso = '{id}'";
        }
        public static string UpdateEmailInfoPorId(EmailInfo email)
        {
            return $"UPDATE EmailInfo SET  IdProcesso = '{email.IdProcesso}', Assunto = '{email.Assunto}' ,Remetente = '{email.Remetente}' ,Destinatario = '{email.Destinatario}',Destinatario_CC = '{email.Destinatario_CC}' ,Destinatario_CO = '{email.Destinatario_CO}'  Where IdProcesso = '{email.IdProcesso}'";
        }

        public static string InsertEmailInfoPorId()
        {
            return "INSERT INTO EmailInfo (IdProcesso ,Assunto ,Remetente ,Destinatario ,Destinatario_CC ,Destinatario_CO) VALUES (@IdProcesso, @Assunto, @Remetente, @Destinatario, @Destinatario_CC, @Destinatario_CO)";
        }
    }
}
