using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateSystem
{
    public abstract class AStateGame
    {
        protected GameStateMachine _owner;
        protected AStateGame(GameStateMachine owner)
        {
            _owner = owner;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}