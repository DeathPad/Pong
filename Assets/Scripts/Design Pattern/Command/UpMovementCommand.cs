using ProgrammingBatch.Pong.Scene;

namespace ProgrammingBatch.Pong.DesignPattern.Command
{
    public sealed class UpMovementCommand : MovementCommand
    {
        private UnityEngine.Vector2 _movementVector;

        public UpMovementCommand(GameActorComponent actor, float speed) : base(actor)
        {
            _movementVector = new UnityEngine.Vector2(0, speed);
        }

        public override void Execute(object commandValue = null)
        {
            GameActor.GetRigidbody().velocity = _movementVector;
        }
    }
}