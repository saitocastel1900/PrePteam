using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private Animator _animator;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        { 
            this.TryGetComponent<Animator>(out _animator);
        }

        /// <summary>
        /// アニメーションを切り替えます
        /// </summary>
        /// <param name="isWalk"></param>
        public void UpdateView(bool isWalk)
        {
            _animator.SetBool("running",isWalk);
        }
    }
}