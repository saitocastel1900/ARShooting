using UnityEngine;
using Zenject;

public class GroundEffect : MonoBehaviour , IHitable
{
    [Inject] private GroundHitEffectGenerator _effect;
    
    public void Hit(Vector3 position)
    {
        _effect.GenerateEffect(position);
    }
}
