using UniRx.Toolkit;
using UnityEngine;

public class FoamBulletPool : ObjectPool<FoamBulletCore>
{
    /// <summary>
    /// 
    /// </summary>
    private readonly Transform _parenTransform;
    
    /// <summary>
    /// 
    /// </summary>
    private readonly FoamBulletCore _prefab;

    /// <summary>
    /// 
    /// </summary>
    public FoamBulletPool(Transform parenTransform, FoamBulletCore prefab)
    {
        _parenTransform = parenTransform;
        _prefab = prefab;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override FoamBulletCore CreateInstance()
    {
        return  FoamBulletCore.Instantiate(_prefab,_parenTransform);
    }
}
