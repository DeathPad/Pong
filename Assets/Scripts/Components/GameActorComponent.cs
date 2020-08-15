using ProgrammingBatch.Pong.Logic;
using UnityEngine;

namespace ProgrammingBatch.Pong.Scene
{
    public abstract class GameActorComponent : MonoBehaviour
    {
        [SerializeField] protected float movementPower = 0;
        [SerializeField] private Rigidbody2D rigidBody = default;

        [SerializeField] protected float topClamp = 0;
        [SerializeField] protected float botClamp = 0;

        public abstract void OnInitialized(IHandler ihandler = default);

        public Rigidbody2D GetRigidbody()
        {
            return rigidBody;
        }
    }
}