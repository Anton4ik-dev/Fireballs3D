using StateSystem;
using System;

namespace MV
{
    public class Score
    {
        private int _score = 0;
        private Hud _uiView;

        public static Action<int> OnScoreChange;
        public static Action OnWin;
        public static Action OnLose;
        public static Action OnExpose;

        public Score(Hud uiView)
        {
            _uiView = uiView;
            Bind();
        }
        private void Bind()
        {
            OnScoreChange += ChangeScore;
            OnWin += _uiView.TurnOnWinScreen;
            OnLose += _uiView.TurnOnLoseScreen;
            OnExpose += Expose;
        }
        private void Expose()
        {
            OnScoreChange -= ChangeScore;
            OnWin -= _uiView.TurnOnWinScreen;
            OnLose -= _uiView.TurnOnLoseScreen;
            OnExpose -= Expose;
        }
        private void ChangeScore(int score)
        {
            _score += score;
            _uiView.UpdateScoreText(_score);
            if (_score <= 0)
            {
                GameStateMachine.OnChangeState?.Invoke(typeof(Lose));
            }
        }
    }
}