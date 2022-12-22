using MV;
using UnityEngine;

namespace StateSystem
{
    public class Win : AStateGame
    {
        public Win(GameStateMachine owner) : base(owner) { }

        public override void Enter()
        {
            Time.timeScale = 0;
            Score.OnWin?.Invoke();
            Score.OnExpose?.Invoke();
            _owner.Expose();
        }
    }
}