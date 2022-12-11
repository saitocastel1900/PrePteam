using Commons.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player
{
    //TODO:コメントを書こう
    //TODO:移動を単純な物ではなく、浮力や水力、波の影響を受けたリアルな移動方法に
    //変更する
    public class PlayerPresenter : MonoBehaviour,IDamagable
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

        public void UpdateBool(bool isWalk)
        {
            _model.UpdateBool(isWalk);
        }

        public void Damage()
        {
            _model.UpdateHp();
        }
    }
}