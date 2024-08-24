using UniRx.Toolkit;
using UnityEngine;

/// <summary>
/// エフェクトのプールを管理する
/// </summary>
public class GroundHitEffectPool : ObjectPool<GroundHitEffect>
{
    /// <summary>
    /// エフェクト
    /// </summary>
    private readonly GroundHitEffect _prefab;

    /// <summary>
    /// 生成元
    /// </summary>
    private readonly Transform _parenTransform;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="prefab">エフェクト</param>
    /// <param name="parenTransform">生成元</param>
    public GroundHitEffectPool(GroundHitEffect prefab, Transform parenTransform)
    {
        _prefab = prefab;
        _parenTransform = parenTransform;
    }

    /// <summary>
    /// エフェクトを生成する
    /// </summary>
    /// <returns></returns>
    protected override GroundHitEffect CreateInstance()
    {
        return GroundHitEffect.Instantiate(_prefab, _parenTransform);
    }
}