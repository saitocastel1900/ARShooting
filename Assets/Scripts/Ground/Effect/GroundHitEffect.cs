using System;
using UniRx;
using UnityEngine;

public class GroundHitEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    
    /// <summary>
    /// 実行
    /// </summary>
    public IObservable<Unit> PlayEffect()
    {
        _particle.Play();

        return Observable.Timer(TimeSpan.FromSeconds(_particle.main.startLifetimeMultiplier))
            .ForEachAsync(_ => _particle.Stop());
    }
}