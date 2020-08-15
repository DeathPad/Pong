using ProgrammingBatch.Pong.Scene;

namespace ProgrammingBatch.Pong.DesignPattern.Command
{
    public abstract class MovementCommand : ICommand
    {
        protected GameActorComponent GameActor { get; private set; }

        public MovementCommand(GameActorComponent actor)
        {
            GameActor = actor;
        }

        public abstract void Execute(object commandValue = null);
    }
}