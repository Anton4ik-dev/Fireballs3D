using System;
using System.Collections.Generic;

namespace StateSystem
{
    public class GameStateMachine
    {
        private Dictionary<Type, AStateGame> _states;
        private AStateGame _activeState;

        public Dictionary<Type, AStateGame> States { get => _states; }

        public static Action<Type> OnChangeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, AStateGame>();

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
            _activeState = _states[type];
            _activeState.Enter();
        }

        public void Update()
        {
            _activeState.Update();
        }
    }
}