using UnityEngine;

/// <summary>
/// 弾の移動を管理する
/// </summary>
public class FoamBulletMover : BaseFoamBullet
{
    /// <summary>
    /// 弾のRigidbodyを管理する
    /// </summary>
    [SerializeField] private FoamBulletCharacterController _characterController;

    protected override void OnInitialize()
    {
        //一度だけ移動する
        _characterController.Move();
    }
}