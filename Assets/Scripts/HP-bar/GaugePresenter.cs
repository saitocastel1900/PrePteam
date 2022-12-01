using System;
using UniRx;
using UnityEngine;

namespace Gauge
{
    public class GaugePresenter : IDisposable
    {
        //view
        private GaugeView _view;
        //model
        private GaugeModel _model;
        
       CompositeDisposable disposables = new CompositeDisposable();
       
       public GaugePresenter(GaugeModel model, GaugeView view)
       {
           Debug.Log("コンストラクタ発動");
           _model = model;
           _view = view;

           _view.Initialized();

           Bind();
           SetEvent();
       }

       public void Initialized()
       {
           _view.Initialized();
           _model.Initialized();
       }

       public void Bind()
        {
            //view=>model
            _view.ObservableClickButton()
                .Select(_ => +1)
                .Subscribe(
                    value => _model.UpdateCount(_model.Value.Value + (int) value),
                    ex => Debug.LogError("OnError!"),
                    () => Debug.Log("")).AddTo(disposables);

            //model=>view
            _model.Value
                .Subscribe(x =>
                    {
                        _view.UpdateText(x);
                        _view.GaugeValue = x;
                        _view.GaugeAnimation();
                    },
                    ex => Debug.LogError("OnError!"),
                    () => Debug.Log("OnCompleted!")).AddTo(disposables);
        }

       public void SetEvent()
        {
            _model.OnCallback += _view.UnInteractiveClick;
        }
        
        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}