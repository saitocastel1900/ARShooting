using UniRx;
using UnityEngine;
using Zenject;

public class GroundEffect : MonoBehaviour
{
    [SerializeField] private GroundCore _core;
    [Inject] private GroundHitEffectGenerator _effect;
    
    private void Start()
    {
        _core.IsHit
            .SkipLatestValueOnSubscribe()
            .Subscribe(_effect.GenerateEffect)
            .AddTo(this);
    }
}
