using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class FoamBulletCharacterController : BaseFoamBullet
{
    [SerializeField] private FoamBulletCore _core;
    [SerializeField] private Rigidbody _rigidbody;
    
    protected override void OnInitialize()
    {
        this.OnDisableAsObservable()
            .Subscribe(_ => _rigidbody.velocity = Vector3.zero)
            .AddTo(this.gameObject);
    }

  public void Move()
  {
      _rigidbody.AddForce(_foamBulletCore.Direction * _foamBulletCore.Velocity, ForceMode.Impulse);
  }
}
