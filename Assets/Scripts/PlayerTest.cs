using Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.OnCollisionEnterAsObservable()
            .Subscribe(target =>
            {
                var hit = target.gameObject.GetComponent<IPushable>();
                hit?.Push(default);
            }).AddTo(this);
    }
}
