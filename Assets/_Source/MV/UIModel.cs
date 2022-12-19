using Observer;
using StateSystem;
using System;

namespace MV
{
    class UIModel : IObserver
    {
        private int _score = 0;
        private GameStateMachine _gameStateMachine;
        private UIView _uiView;

        public static Action OnWin;
        public static Action OnLose;
        public static Action OnExpose;
        public UIModel(IObservable obs, GameStateMachine gameStateMachine, UIView uiView)
        {
            _uiView = uiView;
            _gameStateMachine = gameStateMachine;
            obs.AddObserver(this);
            Bind();
        }
        private void Bind()
        {
            OnWin += _uiView.TurnOnWinScreen;
            OnLose += _uiView.TurnOnLoseScreen;
            OnExpose += Expose;
        }
        private void Expose()
        {
            OnWin -= _uiView.TurnOnWinScreen;
            OnLose -= _uiView.TurnOnLoseScreen;
            OnExpose -= Expose;
        }
        public void Update(int score)
        {
            _score += score;
            _uiView.UpdateScoreText(_score);
            if (_score <= 0)
            {
                _gameStateMachine.ChangeState(typeof(Lose));
            }
        }
    }
}