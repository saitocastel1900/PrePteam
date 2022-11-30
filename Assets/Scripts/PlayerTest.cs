using Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.OnTriggerStayAsObservable()
            .Subscribe(target =>
            {
                var hit = target.gameObject.GetComponent<IPushable>();
                hit?.Push(this.gameObject);
            }).AddTo(this);
    }
}
