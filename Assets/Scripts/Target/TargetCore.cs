using System;
using UniRx;
using UnityEngine;
using Zenject;

public class TargetCore : MonoBehaviour, IHitable
{
    public IReactiveProperty<Vector3> IsHit => _isHit;
    private Vector3ReactiveProperty _isHit = new Vector3ReactiveProperty(Vector3.zero);

    [Inject] private RemainingTargetCounterTextPresenter _remainingTargetCounter;

    private void Start()
    {
        _isHit
            .SkipLatestValueOnSubscribe()
            .Subscribe(position => _remainingTargetCounter.Decrement())
            .AddTo(this);
    }

    public void Hit(Vector3 position)
    {
        _isHit.Value = position;
    }
}