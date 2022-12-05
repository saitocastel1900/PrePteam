using Commons.Enum;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Player
{
    //TODO:コメントを書こう
    //TODO:移動を単純な物ではなく、浮力や水力、波の影響を受けたリアルな移動方法に
    //変更する
    public class PlayerPresenter : MonoBehaviour
    {
        [Inject]
        private PlayerModel _model;
        [SerializeField] private PlayerView _view;
        
        public Vector3 MoveSpeed;
        public Rigidbody Rigidbody;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _view.Initialized();

            TryGetComponent(out Rigidbody);
            MoveSpeed = Vector3.zero;
        }

        /// <summary>
        /// ViewとModelを結び付ける
        /// </summary>
        public void Bind()
        {
            //アニメーションの切り替え
            _model.Running
                .Subscribe(value => _view.UpdateView(value)).AddTo(this);
        }

        public void ManualFixedUpdate()
        {
            Rigidbody.velocity = MoveSpeed;

            if (MoveSpeed!=new Vector3(Rigidbody.velocity.x, Physics.gravity.y, Rigidbody.velocity.z))
            {
                var rotationSpeed = 8.0f * Time.deltaTime;
                Quaternion targetRotation =
                    Quaternion.LookRotation(new Vector3(MoveSpeed.x, 0, MoveSpeed.z).normalized, Vector3.up);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotationSpeed);
            }
        }

        /// <summary>
        /// 衝突判定
        /// </summary>
        public void OnCollisionEnter()
        {
            this.gameObject.OnCollisionEnterAsObservable().DistinctUntilChanged()
                .Where(target => target.gameObject.TryGetComponent<IPushable>(out var t))
                .Subscribe(target =>
                {
                    var hit = target.gameObject.GetComponent<IPushable>();
                    hit?.Push(()=>  _model.UpdateHp(_model.Hp + 1));
                }).AddTo(this);
        }

        public void UpdateBool(bool isWalk)
        {
            _model.UpdateBool(isWalk);
        }
    }
}