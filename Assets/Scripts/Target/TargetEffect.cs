using UniRx;
using UnityEngine;

/// <summary>
/// 的のエフェクトを管理する
/// </summary>
public class TargetEffect : MonoBehaviour
{ 
    /// <summary>
    /// 的
    /// </summary>
    [SerializeField] private TargetCore _core;
   
    /// <summary>
    /// エフェクト
    /// </summary>
    [SerializeField] private BrokeTargetEffect _effectPrefab;

   private void Start()
   {
       //的に弾が当たったら、エフェクトを再生する
       _core
           .OnHit
           .SkipLatestValueOnSubscribe()
           .Subscribe(position =>
           {
               var effect = Instantiate(_effectPrefab, transform.position, Quaternion.identity);
               effect.PlayEffect();
           })
           .AddTo(this);
   }
}
