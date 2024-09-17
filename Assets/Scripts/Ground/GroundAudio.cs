using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// 地面の音を管理する
/// </summary>
public class GroundAudio : MonoBehaviour
{
    /// <summary>
    /// 地面
    /// </summary>
    [SerializeField] private GroundCore _core;
    
    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] AudioManager _audioManager;

    private void Start()
    {
        //地面に弾が当たったら、音を流す
        _core
            .OnHitPos
            .SkipLatestValueOnSubscribe()
            .Subscribe(isHit => _audioManager.PlaySoundEffect(SoundEffect.GroundHit2))
            .AddTo(this);
    }
}
