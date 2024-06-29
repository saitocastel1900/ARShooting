using UniRx;
using UnityEngine;
using Zenject;

public class GroundAudio : MonoBehaviour
{
    [SerializeField] private GroundCore _core;
    [Inject] AudioManager _audioManager;

    private void Start()
    {
        _core.IsHit
            .SkipLatestValueOnSubscribe()
            .Subscribe(isHit => _audioManager.PlaySoundEffect(SoundEffect.Hit2))
            .AddTo(this);
    }
}
