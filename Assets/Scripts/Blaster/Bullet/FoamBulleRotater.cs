using UnityEngine;

/// <summary>
/// 弾の回転を管理する
/// </summary>
public class FoamBulleRotater : BaseFoamBullet
{
    /// <summary>
    /// Transform
    /// </summary>
    [SerializeField] private Transform _transform;
    
    /// <summary>
    /// 傾かせる角度
    /// </summary>
    [SerializeField] private Vector3 _angleOffset;
    
    protected override void OnInitialize()
    {
        //（カメラの向き＋指定した傾き）で目標の方向に弾を向かせる
        _transform.rotation = Camera.main.transform.rotation * Quaternion.Euler(_angleOffset);
    }
}