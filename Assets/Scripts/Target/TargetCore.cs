using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// 的のプロパティを管理する
/// </summary>
public class TargetCore : MonoBehaviour, IHitable
{
    /// <summary>
    /// 的に弾が当たったら呼ばれる
    /// </summary>
    public IReactiveProperty<Vector3> OnHit => _hitPosProp;
    private Vector3ReactiveProperty _hitPosProp = new Vector3ReactiveProperty(Vector3.zero);
    
    /// <summary>
    /// TargetProvider
    /// </summary>
    [Inject] private TargetProvider _provider;
    
    private void Start()
    {
        _provider.AddTarget(this);
    }

    /// <summary>
    /// 当てる
    /// </summary>
    /// <param name="position">当たった場所</param>
    public void Hit(Vector3 position)
    {
        _hitPosProp.Value = position;
        _provider.RemoveTarget(this);
    }
}