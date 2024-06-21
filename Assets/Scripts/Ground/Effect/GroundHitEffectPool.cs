using UniRx.Toolkit;
using UnityEngine;

public class GroundHitEffectPool : ObjectPool<GroundHitEffect>
{
    /// <summary>
    /// 
    /// </summary>
    private readonly GroundHitEffect _prefab;

    /// <summary>
    /// 
    /// </summary>
    private readonly Transform _parenTransform;

    /// <summary>
    /// 
    /// </summary>
    public GroundHitEffectPool(GroundHitEffect prefab, Transform parenTransform)
    {
        _prefab = prefab;

        _parenTransform = parenTransform;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override GroundHitEffect CreateInstance()
    {
        return GroundHitEffect.Instantiate(_prefab, _parenTransform);
    }
}