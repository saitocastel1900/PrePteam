using Gauge;
using Player;
using RipCurrent;
using UnityEngine;

namespace InGame
{
    public class InGamePresenter : MonoBehaviour
    {
        [SerializeField] private InGameView _view;
        [SerializeField] private InGameModel _model;
        
        [SerializeField] private RipCurrentPresenter _ripCurrent;
        [SerializeField] private PlayerPresenter _player;
        [SerializeField] private GaugePresenter _gauge;

        private void Initialized()
        {
            _model.Initialized();
            _view.Initialized();
            
            _ripCurrent.Initialized();
            _player.Initialized();
        }

        private void Bind()
        {
            _ripCurrent.Bind();
            _player.Bind();
            _gauge.Bind();
        }

        private void SetEvents()
        {
            _gauge.SetEvent();
        }

        private void Start()
        {
            Initialized();
            Bind();
            SetEvents();
        }

        private void Update()
        {
            _player.ManualUpdate();
        }

        private void FixedUpdate()
        {
            _player.ManualFixedUpdate();
        }
    }
}