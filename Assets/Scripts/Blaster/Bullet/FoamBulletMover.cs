using UniRx;
using UnityEngine;

public class FoamBulletMover : BaseFoamBullet
{
    [SerializeField] private FoamBulletCharacterController _characterController;

    protected override void OnInitialize()
    {
        Observable.EveryFixedUpdate()
            .FirstOrDefault()
            .Subscribe(_ => _characterController.Move())
            .AddTo(this.gameObject);
    }
}