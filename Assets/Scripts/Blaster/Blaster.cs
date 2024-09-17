using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// 銃（弾の発射を管理する）
/// </summary>
public class Blaster : MonoBehaviour
{
    /// <summary>
    /// 弾の生成を管理する
    /// </summary>
    [SerializeField] private FoamBulletGenerator _bullet;

    /// <summary>
    /// 発射速度
    /// </summary>
    [SerializeField] private float _shotPower = 20;

    /// <summary>
    /// IInputEventProvider
    /// </summary>
    [Inject] private IInputEventProvider _inputEventProvider;

    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] private AudioManager _audioManager;
    
    private void Start()
    {
        //発射ボタンが押されたら、弾を発射する
        _inputEventProvider.IsShotButtonPush
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ =>
            {
                Vector3 screenPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                _bullet.GenerateBullet(Camera.main.ScreenToWorldPoint(screenPosition),
                    Camera.main.ScreenPointToRay(screenPosition).direction, _shotPower);
                
                _audioManager.PlaySoundEffect(SoundEffect.Shot1);
            })
            .AddTo(this);
    }
}