using StateSystem;
using System;

namespace MV
{
    class Score
    {
        private int _score = 0;
        private ScoreAndChargeView _scoreAndChargeView;

        public static Action<int> OnScoreChange;
        public static Action OnWin;
        public static Action OnLose;
        public static Action OnExpose;

        public Score(ScoreAndChargeView scoreAndChargeView)
        {
            _scoreAndChargeView = scoreAndChargeView;
            Bind();
        }

        private void Bind()
        {
            OnScoreChange += ChangeScore;
            OnWin += _scoreAndChargeView.TurnOnWinScreen;
            OnLose += _scoreAndChargeView.TurnOnLoseScreen;
            OnExpose += Expose;
        }

        private void Expose()
        {
            OnScoreChange -= ChangeScore;
            OnWin -= _scoreAndChargeView.TurnOnWinScreen;
            OnLose -= _scoreAndChargeView.TurnOnLoseScreen;
            OnExpose -= Expose;
        }

        private void ChangeScore(int score)
        {
            _score += score;
            _scoreAndChargeView.UpdateScoreText(_score);
            if (_score <= 0)
            {
                GameStateMachine.OnChangeState?.Invoke(typeof(Lose));
            }
        }
    }
}