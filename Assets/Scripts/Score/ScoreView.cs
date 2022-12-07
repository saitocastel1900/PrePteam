using TMPro;
using UnityEngine;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void Initialized()
        {
            _text.text = "";
        }

        public void UpdateText(float text)
        {
            _text.text = text.ToString();
        }
    }
}