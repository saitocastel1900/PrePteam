using System;
using Player;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentPresenter : MonoBehaviour , IPushable
    {
        [SerializeField] private RipCurrentModel _model;
        [SerializeField] private RipCurrentView _view;

        public void Initialized()
        {
            _view.Initialized();
            _model.Initialized();
        }

        public void Bind()
        {
            //Where()
            //_model.PosProp.DistinctUntilChanged().Subscribe().AddTo(this);
        }

        //TODO:流れる方向を変更できるようにする
        public void Push(Action OnCallBack)
        {
            OnCallBack?.Invoke();
        }
    }
}