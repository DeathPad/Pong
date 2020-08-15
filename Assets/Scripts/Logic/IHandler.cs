using ProgrammingBatch.Pong.Event;

namespace ProgrammingBatch.Pong.Logic
{
    public interface IHandler
    {
        event OnEventHandler HandleEvent;

        void TriggerEvent(object eventValue = null);
    }
}