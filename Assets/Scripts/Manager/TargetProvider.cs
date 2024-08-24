using UniRx;
using UnityEngine;

/// <summary>
/// 的を供給する
/// </summary>
public class TargetProvider : MonoBehaviour
{
    /// <summary>
    /// 的のリスト
    /// </summary>
    public IReactiveCollection<TargetCore> Targets => _targetsProp;
    private ReactiveCollection<TargetCore> _targetsProp = new ReactiveCollection<TargetCore>();
    
    /// <summary>
    /// 的を追加する
    /// </summary>
    /// <param name="target">的</param>
    public void AddTarget(TargetCore target)
    {
        _targetsProp.Add(target);
    }

    /// <summary>
    /// 的を削除する
    /// </summary>
    /// <param name="target">的</param>
    public void RemoveTarget(TargetCore target)
    {
        _targetsProp.Remove(target);
    }
}
