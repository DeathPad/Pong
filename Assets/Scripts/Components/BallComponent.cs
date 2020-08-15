using ProgrammingBatch.Pong.Logic;
using System.Collections;
using UnityEngine;

namespace ProgrammingBatch.Pong.Scene
{
    public sealed class BallComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody2D = default;
        [SerializeField] private float xInitialForce = 0;
        [SerializeField] private float yInitialForce = 0;

        private GameStateHandler _gameStateHandler;
        private GameEnum _gameEnum;
        private IHandler _scoreHandler;

        public void OnInitialized(GameStateHandler gameStateHandler, IHandler scoreHandler)
        {
            _gameStateHandler = gameStateHandler;
            _scoreHandler = scoreHandler;

            _gameStateHandler.GameEvent -= OnGameStateChanged;
            _gameStateHandler.GameEvent += OnGameStateChanged;

            _scoreHandler.HandleEvent -= OnScoreEvent;
            _scoreHandler.HandleEvent += OnScoreEvent;
        }

        private void OnGameStateChanged(GameEnum gameEnum)
        {
            _gameEnum = gameEnum;
            switch (gameEnum)
            {
                case GameEnum.Start:
                    break;

                case GameEnum.Play:
                    ResetBall();
                    Invoke("PushBall", 2);
                    break;

                case GameEnum.End:
                    break;
            }
        }

        private void OnScoreEvent(object data = null)
        {
            if (_gameEnum != GameEnum.Play)
            {
                return;
            }

            ResetBall();
            Invoke("PushBall", 2);
        }

        private void ResetBall()
        {
            transform.position = Vector2.zero;
            rigidBody2D.velocity = Vector2.zero;
        }

        private void PushBall()
        {
            float randomDirection = Random.Range(0, 2);
            if (randomDirection < 1.0f) { rigidBody2D.AddForce(new Vector2(-xInitialForce, yInitialForce)); }
            else { rigidBody2D.AddForce(new Vector2(xInitialForce, yInitialForce)); }
        }

        private void OnDestroy()
        {
            _gameStateHandler.GameEvent -= OnGameStateChanged;
            _scoreHandler.HandleEvent -= OnScoreEvent;
        }
    }
}