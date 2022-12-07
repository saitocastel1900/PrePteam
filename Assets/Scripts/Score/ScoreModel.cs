using UniRx;
using UnityEngine;

namespace Score
{
    public class ScoreModel : MonoBehaviour
    {
        private FloatReactiveProperty _timeProp;
        public IReactiveProperty<float> TimeProp => _timeProp;
        public float Time => _timeProp.Value;
        
        public void Initialized()
        {
            _timeProp = new FloatReactiveProperty(60);
        }

        public void UpdateTime(float time)
        {
            _timeProp.Value = time;
        }
    }
}