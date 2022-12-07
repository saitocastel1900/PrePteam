using UniRx;
using UnityEngine;

namespace Score
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private ScoreModel _model;
        [SerializeField] private ScoreView _view;

        void Start()
        {
            Initialized();
            Bind();
            SetEvent();
        }

        public void Initialized()
        {
            _model.Initialized();
            _view.Initialized();
        }

        public void Bind()
        {
            
            
            _model.TimeProp
                .Subscribe(_=>_view.UpdateText(_model.Time)).AddTo(this);
        }

        public void SetEvent()
        {
        }
    }
}