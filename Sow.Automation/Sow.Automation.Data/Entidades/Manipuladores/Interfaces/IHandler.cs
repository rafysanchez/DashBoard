using Sow.Automation.Data.Entidades.ComandoContexto;

namespace Sow.Automation.Data.Entidades.Manipuladores.Interfaces
{
    public interface IHandler<in T> where T : EntidadeBase<T>
    {
        void HandleInsert(T message);
        void HandleDelete(T message);
        void HandleUpdate(T message);
    }
}
