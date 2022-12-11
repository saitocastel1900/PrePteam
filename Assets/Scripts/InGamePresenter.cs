using Commons.Const;
using Commons.Enum;
using Gauge;
using Player;
using RipCurrent;
using Score;
using UniRx;
using UnityEngine;
using Zenject;

namespace InGame
{
    public class InGamePresenter : MonoBehaviour
    {
        [SerializeField] private InGameView _view;
        [SerializeField] private InGameModel _model;

        [SerializeField] private RipCurrentPresenter _ripCurrent;
        [SerializeField] private PlayerPresenter _player;
        [SerializeField] private ScorePresenter _score;
        
        [Inject]
        private GaugePresenter _gauge;

        private void Start()
        {
            Initialized();
            Bind();
            SetEvent();
        }

        private void Update()
        {
            _model.UpdateState(_view.InputMove());
            _score.ManualUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _player.ManualFixedUpdate();
        }
        
        private void Initialized()
        {
            _model.Initialized();
            _player.Initialized();
            _gauge.Initialized();
            _ripCurrent.Initialized();
            _score.Initialized();
        }

        private void Bind()
        {
            _player.Bind();
            
            _ripCurrent.OnCollisionEnter();

            _gauge.Bind();
            
            _model.StatePrp
                .DistinctUntilChanged().Subscribe(OnStateChanged).AddTo(this);
            
            _score.Bind();
        }

        private void SetEvent()
        {
            //_gauge.SetEvent();
        }

        private void OnStateChanged(InGameEnum.State state)
        {
            switch (state)
            {
                //TODO:Presenterは繋げるだけにしたいので、メソッドを呼ぶだけにしたい
                case InGameEnum.State.Stop:
                    _player.MoveSpeed = new Vector3(_player.Rigidbody.velocity.x, Physics.gravity.y, _player.Rigidbody.velocity.z);
                    _player.UpdateBool(false);
                    break;
                case InGameEnum.State.Ahead:
                    _player.MoveSpeed = new Vector3(0, _player.Rigidbody.velocity.y, InGameConst.MoveSpeed * 1);
                    _player.UpdateBool(true);
                    break;
                case InGameEnum.State.Back:
                    _player.MoveSpeed = new Vector3(0, _player.Rigidbody.velocity.y, InGameConst.MoveSpeed * -1);
                    _player.UpdateBool(true);
                    break;
                case InGameEnum.State.Left:
                    _player.MoveSpeed = new Vector3(InGameConst.MoveSpeed * -1, _player.Rigidbody.velocity.y, 0);
                    _player.UpdateBool(true);
                    break;
                case InGameEnum.State.Right:
                    _player.MoveSpeed = new Vector3(InGameConst.MoveSpeed * 1, _player.Rigidbody.velocity.y, 0);
                    _player.UpdateBool(true);
                    break;
            }
        }
    }
}