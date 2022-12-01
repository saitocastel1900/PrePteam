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
            OnCollisionEnter();
        }
        
        private void Update()
        {
            _model.UpdateState(_view.InputMove());
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _moveSpeed;
            
            //BUG:カメラで回転させるのでいらなくなる
            if(_moveSpeed!=Vector3.zero)transform.forward = new Vector3(_moveSpeed.x,0,_moveSpeed.z);;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialized()
        {
            _view.Initialized();
            _model.Initialized();
            
            _rigidbody = this.GetComponent<Rigidbody>();
            _moveSpeed = Vector3.zero;
        }

        /// <summary>
        /// ViewとModelを結び付ける
        /// </summary>
        private void Bind()
        {
            //アニメーションの切り替え
            _model.Running
                .Subscribe(value=>_view.UpdateView(value)).AddTo(this);
            
            //ステートマシンを回す
            _model.State
                .DistinctUntilChanged().Subscribe(OnStateChanged).AddTo(this);
        }

        /// <summary>
        /// 衝突判定
        /// </summary>
        private void OnCollisionEnter()
        {
            this.gameObject.OnCollisionEnterAsObservable()
                .Where(target=>target.gameObject.TryGetComponent<IPushable>(out var t))
                .Subscribe(target =>
                {
                    var hit = target.gameObject.GetComponent<IPushable>();
                    hit?.Push(default);
                }).AddTo(this);
        }

        private void OnStateChanged(InGameEnum.State state)
        {
            switch (state)
            {
                case InGameEnum.State.Stop:
                    _moveSpeed = new Vector3(_rigidbody.velocity.x, Physics.gravity.y, _rigidbody.velocity.z);
                    Debug.Log(Physics.gravity.y);
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