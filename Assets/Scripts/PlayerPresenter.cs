using Commons;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Player
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerModel _model;
        [SerializeField] private PlayerView _view;

        private InGameEnum.State _state;
        private Vector3 _moveSpeed;
        private Rigidbody _rigidbody;
       
        void Start()
        {
            Initialized();
            Bind();
        }

        private Vector3 latestPos;  //前回のPosition
        private void Update()
        {
            _state = _view.InputMove();
        }

        private void FixedUpdate()
        {
            OnStateChanged();
            _rigidbody.velocity = _moveSpeed;
            Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
            latestPos = transform.position;  //前回のPositionの更新

            //ベクトルの大きさが0.01以上の時に向きを変える処理をする
            if (diff.magnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
            }
            
            Debug.Log(transform.forward);
        }

        private void Initialized()
        {
            _rigidbody = this.GetComponent<Rigidbody>();
            _state = InGameEnum.State.Stop;
            _moveSpeed = Vector3.one;
        }

        private void Bind()
        {
            this.gameObject.OnCollisionEnterAsObservable()
                .Subscribe(_ => Debug.Log("衝突してますよ")).AddTo(this);
        }

        private void OnStateChanged()
        {
            switch (_state)
            {
                case InGameEnum.State.Stop:
                    _moveSpeed = new Vector3(0,_rigidbody.velocity.y,0);
                    break;
                case InGameEnum.State.Ahead:
                    _moveSpeed = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, InGameConst.MoveSpeed * 1);
                    break;
                case InGameEnum.State.Back:
                    _moveSpeed = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, InGameConst.MoveSpeed * -1);
                    break;
                case InGameEnum.State.Left:
                    _moveSpeed = new Vector3(InGameConst.MoveSpeed * -1, _rigidbody.velocity.y, _rigidbody.velocity.z);
                    break;
                case InGameEnum.State.Right:
                    _moveSpeed = new Vector3(InGameConst.MoveSpeed * 1, _rigidbody.velocity.y, _rigidbody.velocity.z);
                    break;
            }
        }
    }
}