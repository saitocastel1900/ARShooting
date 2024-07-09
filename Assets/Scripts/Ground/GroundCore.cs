using UniRx;
using UnityEngine;

public class GroundCore : MonoBehaviour , IHitable
{
    /// <summary>
    /// 
    /// </summary>
    public IReactiveProperty<Vector3> HitPosProp => _hitPosProp;
    private Vector3ReactiveProperty _hitPosProp = new Vector3ReactiveProperty(Vector3.zero);

    public void Hit(Vector3 position)
    {
        _hitPosProp.Value = position;
    }
}
