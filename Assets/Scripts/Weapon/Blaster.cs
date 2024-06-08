using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class Blaster : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private FoamBulletCore _bulletPrefab;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Transform _hierarchyTransform;
    
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
    private FoamBulletPool _pool;

    private void Start()
    {
        _pool = new FoamBulletPool(_hierarchyTransform, _bulletPrefab);

        this.OnDestroyAsObservable().Subscribe(_ => _pool.Dispose());
        
        _inputEventProvider.InputTapPosition
            .SkipLatestValueOnSubscribe()
            .Subscribe(screenPosition =>
            {
                var bullet = _pool.Rent();
                bullet.transform.position = Camera.main.ScreenToWorldPoint(screenPosition);

                Ray ray = Camera.main.ScreenPointToRay(screenPosition);
                bullet.InitializeFoamBullet(ray.direction, _shotPower);
                bullet.OnCallBack.Subscribe(_ => _pool.Return(bullet));
            })
            .AddTo(this);
    }
}