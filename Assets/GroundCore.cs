using UniRx;
using UnityEngine;

public class GroundCore : MonoBehaviour , IHitable
{
    public IReactiveProperty<Vector3> IsHit => _isHit;
    private Vector3ReactiveProperty _isHit = new Vector3ReactiveProperty(Vector3.zero);

    public void Hit(Vector3 position)
    {
        _isHit.Value = position;
    }
}
