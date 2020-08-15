using ProgrammingBatch.Pong.Logic;
using UnityEngine;

namespace ProgrammingBatch.Pong.Scene
{
    public sealed class UnityGUIComponent : MonoBehaviour
    {
        private int _scoreLeft;
        private int _scoreRight;

        private IHandler _scoreHandler;

        private GameStateHandler _gameStateHandler;
        private GameEnum _gameEnum;

        public void OnInitialized(IHandler scoreHandler, GameStateHandler gameStateHandler)
        {
            _scoreHandler = scoreHandler;
            _gameStateHandler = gameStateHandler;

            _scoreHandler.HandleEvent -= OnScoreEvent;
            _scoreHandler.HandleEvent += OnScoreEvent;

            _gameStateHandler.GameEvent -= OnGameStateChanged;
            _gameStateHandler.GameEvent += OnGameStateChanged;
        }

        private void OnScoreEvent(object data)
        {
            SideEnum _side = (SideEnum)data;

            switch(_side)
            {
                case SideEnum.Left:
                    _scoreLeft++;
                    break;

                case SideEnum.Right:
                    _scoreRight++;
                    break;
            }
        }

        private void OnGameStateChanged(GameEnum gameEnum)
        {
            _gameEnum = gameEnum;

            switch(_gameEnum)
            {
                case GameEnum.Play:
                    _scoreLeft = 0;
                    _scoreRight = 0;
                    break;
            }
        }

        private void OnGUI()
        {
            switch(_gameEnum)
            {
                case GameEnum.Play:
                    GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + _scoreLeft);
                    GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + _scoreRight);
                    break;

                case GameEnum.End:
                    if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
                    {
                        _gameStateHandler.StateChanged(GameEnum.Play);
                    }

                    if (_scoreLeft > _scoreRight) { GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS"); }
                    else { GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS"); }
                    break;
            }
        }

        private void OnDestroy()
        {
            _scoreHandler.HandleEvent -= OnScoreEvent;
            _gameStateHandler.GameEvent -= OnGameStateChanged;
        }
    }
}