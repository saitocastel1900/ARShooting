using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// 的の音を管理する
/// </summary>
public class TargetAudio : MonoBehaviour
{
    /// <summary>
    /// 的
    /// </summary>
    [SerializeField] private TargetCore _core;
    
    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] AudioManager _audioManager;

    private void Start()
    {
        //的に弾が当たったら、音を流す
        _core
            .OnHit
            .SkipLatestValueOnSubscribe()
            .Subscribe(isHit => _audioManager.PlaySoundEffect(SoundEffect.Hit1))
            .AddTo(this);
    }
}