using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Agendamento.Abstracao
{
    public interface IJobRepository<T>
    {
        T ReadMessage();

        void SetMessage(T message);

        int GetMessageInRepository();

        IEnumerable<T> GetMessages();
    }
}
