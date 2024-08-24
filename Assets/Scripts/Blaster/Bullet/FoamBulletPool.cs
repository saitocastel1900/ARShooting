using UniRx.Toolkit;
using UnityEngine;

/// <summary>
/// 弾のプールを管理する
/// </summary>
public class FoamBulletPool : ObjectPool<FoamBulletCore>
{
    /// <summary>
    /// 弾
    /// </summary>
    private readonly FoamBulletCore _prefab;

    /// <summary>
    /// 生成元
    /// </summary>
    private readonly Transform _parenTransform;
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="prefab">弾</param>
    /// <param name="parenTransform">生成元</param>
    public FoamBulletPool(FoamBulletCore prefab, Transform parenTransform)
    {
        _prefab = prefab;
        _parenTransform = parenTransform;
    }

    /// <summary>
    /// 弾を生成する
    /// </summary>
    /// <returns>弾</returns>
    protected override FoamBulletCore CreateInstance()
    {
        return FoamBulletCore.Instantiate(_prefab, _parenTransform);
    }
}