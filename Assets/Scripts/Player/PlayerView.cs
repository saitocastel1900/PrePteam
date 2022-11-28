using Commons.Enum;
using Input;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [Inject] private IInputMoveProvider _input;
        private Animator _animator;

        public void Initialized()
        { 
            _animator = this.GetComponent<Animator>();
        }

        public InGameEnum.State InputMove()
        {
            if (_input.InputAhead())
            {
                return InGameEnum.State.Ahead;
            }else if (_input.InputBack())
            {
                return InGameEnum.State.Back;
            }else if (_input.InputLeft())
            {
                return InGameEnum.State.Left;
            }else if (_input.InputRight())
            {
                return InGameEnum.State.Right;
            }
            else
            {
                return InGameEnum.State.Stop;
            }
        }

        public void UpdateView(bool isWalk)
        {
            _animator.SetBool("running",isWalk);
        }
    }
}