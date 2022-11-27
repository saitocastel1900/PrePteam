using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactiveGameManager : MonoBehaviour
{
    public StepReactiveProperty _state;
    
    void Start()
    {
        _state
            .DistinctUntilChanged()
            .Where(x => x != STEP.CLEAR)
            .Subscribe(_ =>
            {
                Result();
            }).AddTo(this);
    }
    
    void Result()
    {
        //GUI‚Ì•\Ž¦‚Æ‚©... 
    }
}
