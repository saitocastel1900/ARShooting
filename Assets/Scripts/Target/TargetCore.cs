using UniRx;
using UnityEngine;

public class TargetCore : MonoBehaviour, IHitable
{
    /// <summary>
    /// 
    /// </summary>
    public IReactiveProperty<Vector3> HitPosProp => _hitPosProp;
    private Vector3ReactiveProperty _hitPosProp = new Vector3ReactiveProperty(Vector3.zero);

    [SerializeField]
    private RemainingTargetCounterTextPresenter _remainingTargetCounter;

    private void Start()
    {
        _hitPosProp
            .SkipLatestValueOnSubscribe()
            .Subscribe(position => _remainingTargetCounter.Decrement())
            .AddTo(this);
    }

    public void Hit(Vector3 position)
    {
        _hitPosProp.Value = position;
    }
}