using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class FoamBulletCore : MonoBehaviour
{
    /// <summary>
    /// 初期化したか
    /// </summary>
    public IObservable<Unit> OnInitializeAsync => _onInitializeAsyncSubject;

    private readonly AsyncSubject<Unit> _onInitializeAsyncSubject = new AsyncSubject<Unit>();

    /// <summary>
    /// 
    /// </summary>
    public IObservable<Unit> OnCallBack => this.gameObject.OnBecameInvisibleAsObservable();

    /// <summary>
    /// 
    /// </summary>
    public Vector3 Direction => _direction;

    private Vector3 _direction;

    /// <summary>
    /// 
    /// </summary>
    public float Speed => _speed;

    private float _speed;

    private void Start()
    {
        this.gameObject
            .OnCollisionEnterAsObservable()
            .Subscribe(hit =>
            {
                var breakable = hit.gameObject.GetComponent<IBreakable>();
                if (breakable != null)
                {
                    breakable.Break();
                }
            })
            .AddTo(this.gameObject);
    }

    public void InitializeFoamBullet(Vector3 direction, float speed)
    {
        _direction = direction;
        _speed = speed;
        _onInitializeAsyncSubject.OnNext(Unit.Default);
        _onInitializeAsyncSubject.OnCompleted();
    }
}