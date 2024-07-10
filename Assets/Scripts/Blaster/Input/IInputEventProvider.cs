using UniRx;
using UnityEngine;

public interface IInputEventProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyReactiveProperty<bool> IsShotButtonPush { get; }
}
