using UniRx;
using UnityEngine;

namespace Commons.Enum
{
    public class ReactiveGameManager : MonoBehaviour
    {
        public StepReactiveProperty _state;

        void Start()
        {
            _state
                .DistinctUntilChanged()
                .Where(x => x != STEP.CLEAR)
                .Subscribe(_ => { Result(); }).AddTo(this);
        }

        void Result()
        {
            //GUI‚Ì•\Ž¦‚Æ‚©... 
        }
    }
}