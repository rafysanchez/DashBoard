using Sow.Automation.Agendamento.Abstracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Agendamento.Repository
{
    public class JobRepository<T> : IJobRepository<T>
    {
        public Queue<T> _queue;

        public JobRepository()
        {

            _queue = new Queue<T>();

        }

        public int GetMessageInRepository()
        {
            return _queue.Count;
        }

        public IEnumerable<T> GetMessages()
        {
            return _queue;
        }

        public T ReadMessage()
        {
            return _queue.Dequeue();
        }

        public void SetMessage(T message)
        {
            _queue.Enqueue(message);
        }
    }
}
