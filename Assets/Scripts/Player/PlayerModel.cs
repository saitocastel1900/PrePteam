using Commons.Enum;
using UniRx;
using UnityEngine;

namespace Player
{
    public class PlayerModel : MonoBehaviour
    {
        private BoolReactiveProperty _running;
        public IReadOnlyReactiveProperty<bool> Running => _running;

        //private EnumReactiveProperty _state;
        //public IReadOnlyReactiveProperty<InGameEnum.State> State=>_state;
        
        //TODO:InGameEnumのリアクティブプロパティに変える
        //TODO:Modelの_stateが使われていないので、こっちの_stateを使うようにする
        public InGameEnum.State _state;

        public void Initialized()
        {
            _state = InGameEnum.State.Stop;
            _running = new BoolReactiveProperty(false);
        }

        public void UpdateState(InGameEnum.State state)
        {
            _state = state;
        }

        public void UpdateBool(bool isRun)
        {
            _running.Value = isRun;
        }
    }
}