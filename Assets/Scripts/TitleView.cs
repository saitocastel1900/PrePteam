using System;
using InputAsRx;
using UniRx;
using UnityEngine;

namespace Title
{
    public class TitleView : MonoBehaviour
    {
        public void Initialized()
        {
            
        }

        public IObservable<Unit> InputSpaceKey()
        {
            return InputAsObservable.GetKeyDown(KeyCode.Space);
        }
    }
}