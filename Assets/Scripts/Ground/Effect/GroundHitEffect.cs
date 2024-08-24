using System;
using UniRx;
using UnityEngine;

/// <summary>
/// エフェクトを管理する
/// </summary>
public class GroundHitEffect : MonoBehaviour
{
    /// <summary>
    /// エフェクト
    /// </summary>
    [SerializeField] private ParticleSystem _particle;
    
    /// <summary>
    /// 実行
    /// </summary>
    public IObservable<Unit> PlayEffect()
    {
        _particle.Play();

        //エフェクトが再生し終わったら、poolに返す
        return Observable.Timer(TimeSpan.FromSeconds(_particle.main.startLifetimeMultiplier))
            .ForEachAsync(_ => _particle.Stop());
    }
}