using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class FoamBulletCore : MonoBehaviour
{
    /// <summary>
    /// 初期化したか
    /// </summary>
    public IObservable<Unit> OnInitialized => _initializeSubject;
    private readonly ReplaySubject<Unit> _initializeSubject = new ReplaySubject<Unit>();

    /// <summary>
    /// 
    /// </summary>
    public Vector3 Direction => _direction;
    private Vector3 _direction;

    /// <summary>
    /// 
    /// </summary>
    public float Velocity => _velocity;
    private float _velocity;

    private void Start()
    { 
        this.gameObject
            .OnCollisionEnterAsObservable()
            .Subscribe(hit =>
            {
                var hitable = hit.gameObject.GetComponent<IHitable>();
                if (hitable != null)
                {
                    hitable.Hit(hit.contacts[0].point);
                }
            })
            .AddTo(this.gameObject);
    }

    public IObservable<Unit> InitializeFoamBullet(Vector3 direction, float velocity)
    {
        _direction = direction;
        _velocity = velocity;
        _initializeSubject.OnNext(Unit.Default);
        _initializeSubject.AddTo(this.gameObject);
        
        return this.gameObject.OnBecameInvisibleAsObservable();
   }
}