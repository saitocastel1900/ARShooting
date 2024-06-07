using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        this.gameObject
            .OnCollisionEnterAsObservable()
            .Subscribe(hit =>
            {
                var breakable = hit.gameObject.GetComponent<IBreakable>();
                if (breakable != null)
                {
                    breakable.Break();
                }
            })
            .AddTo(this.gameObject);
    }
}