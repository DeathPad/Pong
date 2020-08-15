using ProgrammingBatch.Pong.Logic;
using UnityEngine;

namespace ProgrammingBatch.Pong.Scene
{
    public sealed class WallComponent : MonoBehaviour
    {
        [SerializeField] private SideEnum sideEnum = default;

        private IHandler _scoreHandler;

        public void OnInitialized(IHandler scoreHandler)
        {
            _scoreHandler = scoreHandler;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Ball") 
            {
                _scoreHandler.TriggerEvent(sideEnum); 
            }
        }
    }
}