using System.Linq;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// 的が壊れるエフェクトを管理する
/// </summary>
public class BrokeTargetEffect : MonoBehaviour
{
    /// <summary>
    /// Transform
    /// </summary>
   [SerializeField] private Transform _brokeEffect;
    
    /// <summary>
    /// 吹っ飛ぶ強さ
    /// </summary>
   [SerializeField] private Vector2 _forceRange = new Vector2(-1f, 1f);
   
    /// <summary>
    /// 破片が小さくなっていく時間
    /// </summary>
    [SerializeField] private float _reductionDuration;

    /// <summary>
    /// エフェクトを再生する
    /// </summary>
   public void PlayEffect()
    {
        //破片を小さくする
        var childTransforms = 
            _brokeEffect.GetComponentsInChildren<Transform>().ToList();
        childTransforms.ForEach(t => t.DOScale(Vector3.zero, _reductionDuration));
        
        var childRigidbodies = 
            _brokeEffect.GetComponentsInChildren<Rigidbody>().ToList();
        
        //破片を吹っ飛ばす
        childRigidbodies.ForEach(rb =>
        {
            rb.isKinematic = false;
            
            var force = new Vector3(
                UnityEngine.Random.Range(_forceRange.x, _forceRange.y),
                UnityEngine.Random.Range(0, _forceRange.y),
                UnityEngine.Random.Range(_forceRange.x, _forceRange.y)
            );
            rb.AddForce(force, ForceMode.Impulse);
            rb.AddTorque(force, ForceMode.Impulse);
        });
    }
}
