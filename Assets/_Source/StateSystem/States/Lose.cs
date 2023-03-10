using MV;
using UnityEngine;

namespace StateSystem
{
    public class Lose : AStateGame
    {
        public Lose(GameStateMachine owner) : base(owner) { }

        public override void Enter()
        {
            Time.timeScale = 0;
            Score.OnLose?.Invoke();
            Score.OnExpose?.Invoke();
            _owner.Expose();
        }
    }
}