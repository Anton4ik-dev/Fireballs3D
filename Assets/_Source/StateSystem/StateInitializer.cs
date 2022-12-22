using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateSystem
{
    public class StateInitializer
    {
        public StateInitializer(GameStateMachine gameStateMachine)
        {
            gameStateMachine.States.Add(typeof(Game), new Game(gameStateMachine));
            gameStateMachine.States.Add(typeof(Win), new Win(gameStateMachine));
            gameStateMachine.States.Add(typeof(Lose), new Lose(gameStateMachine));
        }
    }
}