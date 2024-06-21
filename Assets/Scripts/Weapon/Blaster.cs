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

    private void Start()
    {
        _inputEventProvider.InputTapPosition
            .SkipLatestValueOnSubscribe()
            .Subscribe(screenPosition =>
            {
                _bullet.GenerateBullet(Camera.main.ScreenToWorldPoint(screenPosition),
                    Camera.main.ScreenPointToRay(screenPosition).direction, _shotPower);
            })
            .AddTo(this);
    }
}