using Commons;
using UnityEngine;

namespace Player
{
    public class PlayerModel : MonoBehaviour
    {
        public InGameEnum.State _state;

        public void Initialized()
        {
            _state = InGameEnum.State.Stop;
        }

        public void UpdateState( InGameEnum.State state)
        {
            _state = state;
        }
    }
}