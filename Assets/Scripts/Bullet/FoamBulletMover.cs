using UniRx;
using UnityEngine;

public class FoamBulletMover : BaseFoamBullet
{
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void OnInitialize()
    {
        Observable.EveryFixedUpdate().FirstOrDefault()
            .Subscribe(_ => _rigidbody.AddForce(_foamBulletCore.Direction * _foamBulletCore.Speed, ForceMode.Impulse))
            .AddTo(this.gameObject);
    }
}