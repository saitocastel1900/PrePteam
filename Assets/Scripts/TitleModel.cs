using UniRx;
using UnityEngine;

namespace Title
{
    public class TitleModel : MonoBehaviour
    {
        private BoolReactiveProperty _isFadeProp;
        public IReactiveProperty<bool> IsFadeProp => _isFadeProp;
        public bool IsFade => _isFadeProp.Value;
        
        public void Initialized()
        {
            _isFadeProp = new BoolReactiveProperty(false);
        }

        public void BoolUpdate(bool isFade)
        {
            _isFadeProp.Value = isFade;
        }
    }
}