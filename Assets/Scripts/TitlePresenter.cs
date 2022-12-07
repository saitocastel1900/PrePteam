using System;
using Commons.Utility;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Title
{
    public class TitlePresenter : MonoBehaviour
    {
        [SerializeField] private TitleModel _model;
        [SerializeField] private TitleView _view;

        [SerializeField] private AssetReference _scene;
        
        void Start()
        {
            Initialized();
            Bind();
            SetEvent();
        }
        
        private void Initialized()
        {
            _model.Initialized();
            _view.Initialized();
        }

        private void Bind()
        {
            _view.InputSpaceKey()
                .ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Subscribe(_=>_model.BoolUpdate(true)).AddTo(this);
        }

        private void SetEvent()
        {
            _model.IsFadeProp
                .Where(_=>_model.IsFade)
                .DistinctUntilChanged()
                .Subscribe(_=>SceneTransition.LoadScene(_scene)).AddTo(this);
        }
    }
}