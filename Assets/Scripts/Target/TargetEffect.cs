using UniRx;
using UnityEngine;

public class TargetEffect : MonoBehaviour, IHitable
{
    [SerializeField] private TargetCore _core;
    [SerializeField] private ParticleSystem _particle;
    
    public void Hit(Vector3 position)
    {
        var effect = Instantiate(_particle, position, Quaternion.identity);
        effect.Play();
    }

    private void Start()
    {
        _core.IsHit
            .SkipLatestValueOnSubscribe()
            .Subscribe(position =>
            {
                var effect = Instantiate(_particle, position, Quaternion.identity);
                effect.Play();
            })
            .AddTo(this);
    }
}
