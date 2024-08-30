using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
///弾のプロパティを管理する
/// </summary>
public class FoamBulletCore : MonoBehaviour
{
    /// <summary>
    /// 初期化したか
    /// </summary>
    public IReactiveProperty<bool> IsInitialized => _isInitialized;
    private readonly BoolReactiveProperty _isInitialized = new BoolReactiveProperty(false);

    /// <summary>
    /// 的に当たったか
    /// </summary>
    public IReactiveProperty<bool> IsHit => _isHit;
    private BoolReactiveProperty _isHit = new BoolReactiveProperty(false);

    /// <summary>
    /// 進行方向
    /// </summary>
    public Vector3 Direction => _direction;
    private Vector3 _direction;

    /// <summary>
    /// 速度
    /// </summary>
    public float Velocity => _velocity;
    private float _velocity;

    private void Start()
    {
        //的に当たったら、フラグを立てて相手のHit()を呼び出す
        this.gameObject
            .OnTriggerEnterAsObservable()
            .Subscribe(hit =>
            {
                var hitable = hit.gameObject.GetComponent<IHitable>();
                if (hitable != null)
                {
                    hitable.Hit(hit.ClosestPointOnBounds(this.transform.position));
                    _isHit.Value= true;
                }
            })
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="direction">進行方向</param>
    /// <param name="velocity">速度</param>
    /// <returns>弾が非表示になった or 的にあった時のストリーム</returns>
    public IObservable<Unit> InitializeFoamBullet(Vector3 direction, float velocity)
    {
        _direction = direction;
        _velocity = velocity;
        _isInitialized.Value = true;
        _isInitialized.AddTo(this.gameObject);

        //弾が非表示になった or 的にあった時、プールに返す
        return Observable.Merge(
                this.gameObject.OnBecameInvisibleAsObservable(),
                _isHit.Where(isHit=>isHit==true).AsUnitObservable()
                )
            .FirstOrDefault()
            .Do(_ =>
            {
                _isInitialized.Value = false;
                _isHit.Value= false;
            });
    }
}