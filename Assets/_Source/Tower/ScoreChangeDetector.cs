using Observer;
using System;
using System.Collections.Generic;

namespace TowerSystem
{
    class ScoreChangeDetector : IObservable
    {
        private List<IObserver> _observers;
        public static Action<int> OnScoreChange;
        public ScoreChangeDetector()
        {
            _observers = new List<IObserver>();
            OnScoreChange += NotifyObservers;
        }
        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers(int cost)
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].Update(cost);
            }
        }
    }
}