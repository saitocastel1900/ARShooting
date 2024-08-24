using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// 弾の生成を管理する
/// </summary>
public class GroundHitEffectGenerator : MonoBehaviour
{
    /// <summary>
    /// エフェクト
    /// </summary>
    [SerializeField] private GroundHitEffect _effectPrefab;

    /// <summary>
    /// 生成元
    /// </summary>
    [SerializeField] private Transform _hierarchyTransform;
    
    /// <summary>
    /// プール
    /// </summary>
    private GroundHitEffectPool _pool;

    private void Start()
    {
        _pool = new GroundHitEffectPool(_effectPrefab,_hierarchyTransform);
        
        //オブジェクトが破壊されたら、poolを解除
        this.OnDestroyAsObservable()
            .Subscribe(_ => _pool.Dispose());
    }

    /// <summary>
    /// エフェクトを生成する
    /// </summary>
    /// <param name="position">生成場所</param>
    public void GenerateEffect(Vector3 position)
    {
        var effect = _pool.Rent();
        
        effect.transform.position = position;
        
        //エフェクトを再生して、再生し終わったらpoolに返す
        effect
            .PlayEffect()
            .Subscribe(x=>_pool.Return(effect))
            .AddTo(this.gameObject);
    }
}