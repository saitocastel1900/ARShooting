using UniRx;
using UnityEngine;

/// <summary>
/// 地面のプロパティを管理する
/// </summary>
public class GroundCore : MonoBehaviour , IHitable
{
    /// <summary>
    /// 弾が地面に当たった時に呼ばれる
    /// </summary>
    public IReactiveProperty<Vector3> OnHitPos => _hitPosProp;
    private Vector3ReactiveProperty _hitPosProp = new Vector3ReactiveProperty(Vector3.zero);

    /// <summary>
    /// 当てる
    /// </summary>
    /// <param name="position">当たった場所</param>
    public void Hit(Vector3 position)
    {
        _hitPosProp.Value = position;
    }
}
