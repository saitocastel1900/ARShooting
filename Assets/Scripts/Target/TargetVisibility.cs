using UniRx;
using UnityEngine;

/// <summary>
/// 的の表示・非表示を管理する
/// </summary>
public class TargetVisibility : MonoBehaviour
{
    /// <summary>
    /// 的
    /// </summary>
    [SerializeField] private TargetCore _core;
  
    void Start()
    {
        //的に弾が当たったら、非表示にする
        _core
            .OnHit 
            .SkipLatestValueOnSubscribe()
            .Select(_=>false)
            .Subscribe(this.gameObject.SetActive)
            .AddTo(this.gameObject);
    }
}
