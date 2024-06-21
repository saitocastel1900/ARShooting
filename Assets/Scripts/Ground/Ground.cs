using UnityEngine;

public class Ground : MonoBehaviour , IHitable
{
    [SerializeField] private GroundHitEffectGenerator _effect;
    
    public void Hit(Vector3 position)
    {
        _effect.GenerateEffect(position);
    }
}
