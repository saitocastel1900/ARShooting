using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// エフェクトを管理する
/// </summary>
public class GroundEffect : MonoBehaviour
{
    /// <summary>
    /// 地面
    /// </summary>
    [SerializeField] private GroundCore _core;
    
    /// <summary>
    /// 地面エフェクトの生成を管理する
    /// </summary>
    [Inject] private GroundHitEffectGenerator _effect;
    
    private void Start()
    {
        //地面に弾が当たったら、エフェクトを再生する
        _core
            .OnHitPos
            .SkipLatestValueOnSubscribe()
            .Subscribe(_effect.GenerateEffect)
            .AddTo(this);
    }
}
