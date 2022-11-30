using Commons.Const;
using Commons.Enum;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Player
{
    //TODO:コメントを書こう
    //TODO:移動を単純な物ではなく、浮力や水力、波の影響を受けたリアルな移動方法に
    //変更する
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerModel _model;
        [SerializeField] private PlayerView _view;
        
        private Vector3 _moveSpeed;
        private Rigidbody _rigidbody;
       
        void Start()
        {
            Initialized();
            Bind();
        }
        
        private void Update()
        {
            _model.UpdateState(_view.InputMove());
        }

        private void FixedUpdate()
        {
            OnStateChanged();
            _rigidbody.velocity = _moveSpeed;
            
            //BUG:カメラで回転させるのでいらなくなる
            if(_moveSpeed!=Vector3.zero)transform.forward = new Vector3(_moveSpeed.x,0,_moveSpeed.z);;
        }

        private void Initialized()
        {
            _view.Initialized();
            _model.Initialized();
            
            _rigidbody = this.GetComponent<Rigidbody>();
            _moveSpeed = Vector3.zero;
        }

        private void Bind()
        {
            _model.Running.Subscribe(value=>_view.UpdateView(value)).AddTo(this);
            
            this.gameObject.OnCollisionEnterAsObservable()
                .Subscribe(target =>
                {
                    var hit = target.gameObject.GetComponent<IPushable>();
                    hit?.Push(default);
                }).AddTo(this);
        }
        
        private void OnStateChanged()
        {
            switch (_model._state)
            {
                case InGameEnum.State.Stop:
                    _moveSpeed = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _rigidbody.velocity.z);
                    _model.UpdateBool(false);
                    break;
                case InGameEnum.State.Ahead:
                    _moveSpeed = new Vector3(0, _rigidbody.velocity.y, InGameConst.MoveSpeed * 1);
                    _model.UpdateBool(true);
                    break;
                case InGameEnum.State.Back:
                    _moveSpeed = new Vector3(0, _rigidbody.velocity.y, InGameConst.MoveSpeed * -1);
                    _model.UpdateBool(true);
                    break;
                case InGameEnum.State.Left:
                    _moveSpeed = new Vector3(InGameConst.MoveSpeed * -1, _rigidbody.velocity.y, 0);
                    _model.UpdateBool(true);
                    break;
                case InGameEnum.State.Right:
                    _moveSpeed = new Vector3(InGameConst.MoveSpeed * 1, _rigidbody.velocity.y, 0);
                    _model.UpdateBool(true);
                    break;
            }
        }
    }
}