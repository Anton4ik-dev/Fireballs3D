using UnityEngine;

namespace StateSystem
{
    public class Game : AStateGame
    {
        public Game(GameStateMachine owner) : base(owner)
        {

        }

        public override void Enter()
        {
            Time.timeScale = 1;
        }
        public override void Exit()
        {
            Time.timeScale = 0;
        }
    }
}