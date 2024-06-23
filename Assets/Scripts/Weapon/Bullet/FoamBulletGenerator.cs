using Commons.Utility;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class FoamBulletGenerator : MonoBehaviour
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
    private FoamBulletPool _pool;

    private void Start()
    {
        _pool = new FoamBulletPool(_bulletPrefab,_hierarchyTransform);
        this.OnDestroyAsObservable().Subscribe(_ => _pool.Dispose());
    }

    /// <summary>
    /// 
    /// </summary>
    public void GenerateBullet(Vector3 position,Vector3 direction, float velocity)
    {
        var bullet = _pool.Rent();
        bullet.transform.position = position;
        
        bullet
            .InitializeFoamBullet(direction,velocity)
            .Subscribe(_ =>
            {
                _pool.Return(bullet);
                DebugUtility.Log("返りました");
            })
            .AddTo(this.gameObject);
    }
}