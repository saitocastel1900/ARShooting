using UniRx.Toolkit;
using UnityEngine;

public class FoamBulletPool : ObjectPool<FoamBulletCore>
{
    /// <summary>
    /// 
    /// </summary>
    private readonly FoamBulletCore _prefab;

    /// <summary>
    /// 
    /// </summary>
    private readonly Transform _parenTransform;
    
    /// <summary>
    /// 
    /// </summary>
    public FoamBulletPool(FoamBulletCore prefab, Transform parenTransform)
    {
        _prefab = prefab;
        _parenTransform = parenTransform;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override FoamBulletCore CreateInstance()
    {
        return FoamBulletCore.Instantiate(_prefab, _parenTransform);
    }
}