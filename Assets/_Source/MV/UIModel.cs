using Observer;
using System;

namespace MV
{
    class UIModel : IObserver
    {
        private int _score = 0;
        private UIView _uiView;
        public Action<int> OnScoreChange;
        public UIModel(IObservable obs, UIView uiView)
        {
            _uiView = uiView;
            obs.AddObserver(this);
            Bind();
        }
        public void Bind()
        {
            OnScoreChange += _uiView.UpdateScoreText;
        }
        public void Update(int score)
        {
            _score += score;
            OnScoreChange?.Invoke(_score);
            if (_score <= 0)
            {
                //lose
            }
        }
    }
}