using ProgrammingBatch.FlappyBirdClone.Event;

namespace ProgrammingBatch.Pong.Logic
{
    public sealed class GameStateHandler
    {
        public event GameEventHandler GameEvent;

        public GameStateHandler()
        {
        }

        public void StateChanged(GameEnum newEnum)
        {
            GameEvent?.Invoke(newEnum);
        }
    }
}