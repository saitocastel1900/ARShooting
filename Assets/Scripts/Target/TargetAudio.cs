using UniRx;
using UnityEngine;
using Zenject;

public class TargetAudio : MonoBehaviour
{
    [SerializeField] private TargetCore _core;
    [Inject] AudioManager _audioManager;

    private void Start()
    {
        _core
            .HitPosProp
            .SkipLatestValueOnSubscribe()
            .Subscribe(isHit => _audioManager.PlaySoundEffect(SoundEffect.Hit1))
            .AddTo(this);
    }
}