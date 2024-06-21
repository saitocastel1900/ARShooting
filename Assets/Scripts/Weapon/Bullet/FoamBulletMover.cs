using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class FoamBulletMover : BaseFoamBullet
{
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void OnInitialize()
    {
        this.OnDisableAsObservable().Subscribe(_ => _rigidbody.velocity = Vector3.zero).AddTo(this.gameObject);

        Observable.EveryFixedUpdate().FirstOrDefault()
            .Subscribe(_ => _rigidbody.AddForce(_foamBulletCore.Direction * _foamBulletCore.Velocity, ForceMode.Impulse))
            .AddTo(this.gameObject);
    }
}