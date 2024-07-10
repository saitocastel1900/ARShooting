using UniRx;
using UnityEngine;
using Zenject;

public class Blaster : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private FoamBulletGenerator _bullet;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float _shotPower = 20;

    /// <summary>
    /// 
    /// </summary>
    [Inject] private IInputEventProvider _inputEventProvider;

    /// <summary>
    /// 
    /// </summary>
    [Inject] private AudioManager _audioManager;
    
    private void Start()
    {
        _inputEventProvider.IsShotButtonPush
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ =>
            {
                Vector3 screenPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                _bullet.GenerateBullet(Camera.main.ScreenToWorldPoint(screenPosition),
                    Camera.main.ScreenPointToRay(screenPosition).direction, _shotPower);
                
                _audioManager.PlaySoundEffect(SoundEffect.Shot);
            })
            .AddTo(this);
    }
}