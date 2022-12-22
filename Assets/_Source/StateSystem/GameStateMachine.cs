using System;
using System.Collections.Generic;

namespace StateSystem
{
    public class GameStateMachine
    {
        private Dictionary<Type, AStateGame> states;
        private AStateGame _activeState;
        public static Action<Type> OnChangeState;

        public GameStateMachine()
        {
            states = new Dictionary<Type, AStateGame>();
            states.Add(typeof(Game), new Game(this));
            states.Add(typeof(Win), new Win(this));
            states.Add(typeof(Lose), new Lose(this));
            Bind();
        }
        private void Bind()
        {
            OnChangeState += ChangeState;
        }
        public void Expose()
        {
            OnChangeState -= ChangeState;
        }
        public void ChangeState(Type type)
        {
            _activeState.Exit();
            StartState(type);
        }

        public void StartState(Type type)
        {
            _activeState = states[type];
            _activeState.Enter();
        }

        public void Update()
        {
            _activeState.Update();
        }
    }
}