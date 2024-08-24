using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// 弾のRigidbodyを管理する
/// </summary>
public class FoamBulletCharacterController : BaseFoamBullet
{
    /// <summary>
    /// 弾
    /// </summary>
    [SerializeField] private FoamBulletCore _core;

    /// <summary>
    /// Rigidbody
    /// </summary>
    [SerializeField] private Rigidbody _rigidbody;

    protected override void OnInitialize()
    {
        //弾がpoolに戻ったら、弾の移動を停止する
        this.OnDisableAsObservable()
            .Subscribe(_ => _rigidbody.velocity = Vector3.zero)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 移動する
    /// </summary>
    public void Move()
    {
        _rigidbody.AddForce(_foamBulletCore.Direction * _foamBulletCore.Velocity, ForceMode.Impulse);
    }
}