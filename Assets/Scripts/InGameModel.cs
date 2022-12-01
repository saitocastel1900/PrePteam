using Commons.Enum;
using UniRx;
using UnityEngine;

namespace InGame
{
    public class InGameModel : MonoBehaviour
    {
        private EnumReactiveProperty _state;
        public IReadOnlyReactiveProperty<InGameEnum.State> State => _state;

        public void Initialized()
        {
            _state = new EnumReactiveProperty(InGameEnum.State.Stop);
        }

        /// <summary>
        /// Enumを書き換える
        /// </summary>
        /// <param name="state"></param>
        public void UpdateState(InGameEnum.State state)
        {
            _state.Value = state;
        }
    }
}