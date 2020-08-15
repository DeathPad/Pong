using ProgrammingBatch.Pong.Core;
using ProgrammingBatch.Pong.Logic;
using ProgrammingBatch.Pong.Scene;
using UnityEngine;

namespace ProgrammingBatch.Pong
{
    public sealed class PongSceneController : SceneController
    {
        [SerializeField] private GameActorComponent leftActor = default;
        [SerializeField] private GameActorComponent rightActor = default;

        [SerializeField] private UnityGUIComponent guiComponent = default;

        [SerializeField] private BallComponent ballComponent = default;

        [SerializeField] private WallComponent leftWall = default;
        [SerializeField] private WallComponent rightWall = default;

        public override void InitializeCoreModules()
        {
        }

        public override void InitializeGameModules()
        {
        }

        public override void InitializeSceneComponents()
        {
            GameStateHandler _gameStateHandler = new GameStateHandler();
            ScoreHandler _scoreHandler = new ScoreHandler(_gameStateHandler, 5);

            leftActor.OnInitialized();
            rightActor.OnInitialized();
            ballComponent.OnInitialized(_gameStateHandler, _scoreHandler);
            guiComponent.OnInitialized(_scoreHandler, _gameStateHandler);
            leftWall.OnInitialized(_scoreHandler);
            rightWall.OnInitialized(_scoreHandler);

            _gameStateHandler.StateChanged(GameEnum.Play);
        }
    }
}