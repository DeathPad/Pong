using ProgrammingBatch.Pong.Event;

namespace ProgrammingBatch.Pong.Logic
{
    public sealed class ScoreHandler : IHandler
    {
        public event OnEventHandler HandleEvent;

        private GameStateHandler _gameStateHandler;
        private GameEnum _gameEnum;

        private int _leftSideScore = 0;
        private int _rightSideScore = 0;

        private int _maxScore;

        public ScoreHandler(GameStateHandler gameStateHandler, int maxScore)
        {
            _gameStateHandler = gameStateHandler;

            _maxScore = maxScore;
        }

        public void TriggerEvent(object data = null)
        {
            SideEnum side = (SideEnum)data;
            switch (side)
            {
                case SideEnum.Left:
                    _leftSideScore++;
                    if (_leftSideScore >= _maxScore) { _gameStateHandler.StateChanged(GameEnum.End); }
                    break;

                case SideEnum.Right:
                    _rightSideScore++;
                    if (_rightSideScore >= _maxScore) { _gameStateHandler.StateChanged(GameEnum.End); }
                    break;
            }

            HandleEvent?.Invoke(side);
        }

        ~ScoreHandler()
        {
        }
    }
}