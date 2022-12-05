using System.Collections;
using System.Collections.Generic;
using Commons.Enum;
using Input;
using UnityEngine;
using Zenject;

namespace InGame
{
    public class InGameView : MonoBehaviour
    {
        [Inject] private IInputMoveProvider _input;
        
        /// <summary>
        /// それぞれの入力からEnumを返す
        /// </summary>
        /// <returns></returns>
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
    }
}