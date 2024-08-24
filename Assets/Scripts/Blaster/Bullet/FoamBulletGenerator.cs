using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// 弾の生成を管理する
/// </summary>
public class FoamBulletGenerator : MonoBehaviour
{
    /// <summary>
    /// 弾
    /// </summary>
    [SerializeField] private FoamBulletCore _bulletPrefab;

    /// <summary>
    /// 生成元
    /// </summary>
    [SerializeField] private Transform _parenTransform;
    
    /// <summary>
    /// プール
    /// </summary>
    private FoamBulletPool _pool;

    private void Start()
    {
        _pool = new FoamBulletPool(_bulletPrefab,_parenTransform);
        
        //オブジェクトが破壊されたら、poolを解除
        this.gameObject
            .OnDestroyAsObservable()
            .Subscribe(_ => _pool.Dispose());
    }

    /// <summary>
    /// 弾を生成する
    /// </summary>
    /// <param name="position">生成場所</param>
    /// <param name="direction">進行方向</param>
    /// <param name="velocity">速度</param>
    public void GenerateBullet(Vector3 position,Vector3 direction, float velocity)
    {
        var bullet = _pool.Rent();
        
        bullet.transform.position = position;
        
        //弾を初期化して、弾が非表示になった or 的にあったら、弾をpoolに返す
        bullet
            .InitializeFoamBullet(direction,velocity)
            .Subscribe(_ => _pool.Return(bullet))
            .AddTo(this.gameObject);
    }
}