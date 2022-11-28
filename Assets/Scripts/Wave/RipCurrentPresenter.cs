using Player;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentPresenter : MonoBehaviour , IPushable
    {
        [SerializeField] private RipCurrentModel _model;
        [SerializeField] private RipCurrentView _view;
        
        
        public void Push()
        {
            Debug.Log("波が衝突してます");
        }
    }
}