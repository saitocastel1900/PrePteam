using System;
using UniRx;
using UnityEngine;

namespace Commons.Enum
{
    public class ReactiveGameManager : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<InGameEnum.State> State => _state;
        private EnumReactiveProperty _state;
        
        void Start()
        {
            _state = new EnumReactiveProperty(InGameEnum.State.Stop);
            State.DistinctUntilChanged().Subscribe(value=>Debug.Log("‚±‚ñ‚É‚¿‚í"+value)).AddTo(this);
            
            /*
            _state
                .DistinctUntilChanged()
                .Where(x => x != InGameEnum.State.Ahead)
                .Subscribe(_ => { Result(); }).AddTo(this);
            */
        }

        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.W)) UpdateValue(InGameEnum.State.Ahead);
            if(UnityEngine.Input.GetKeyDown(KeyCode.A)) UpdateValue(InGameEnum.State.Right);
            if(UnityEngine.Input.GetKeyDown(KeyCode.D)) UpdateValue(InGameEnum.State.Left);
            if(UnityEngine.Input.GetKeyDown(KeyCode.S)) UpdateValue(InGameEnum.State.Back);
        }

        void Result()
        {
            //GUI‚Ì•\Ž¦‚Æ‚©... 
        }

        private void UpdateValue(InGameEnum.State state)
        {
            _state.Value = state;
        }
    }
}