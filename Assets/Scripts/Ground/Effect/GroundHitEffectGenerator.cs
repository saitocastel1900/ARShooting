using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class GroundHitEffectGenerator : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GroundHitEffect _effectPrefab;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Transform _hierarchyTransform;
    
    /// <summary>
    /// 
    /// </summary>
    private GroundHitEffectPool _pool;

    private void Start()
    {
        _pool = new GroundHitEffectPool(_effectPrefab,_hierarchyTransform);
        this.OnDestroyAsObservable().Subscribe(_ => _pool.Dispose());
    }

    /// <summary>
    /// 
    /// </summary>
    public void GenerateEffect(Vector3 position)
    {
        var effect = _pool.Rent();
        effect.transform.position = position;
        
        effect
            .PlayEffect()
            .Subscribe(x=>_pool.Return(effect))
            .AddTo(this.gameObject);
    }
}