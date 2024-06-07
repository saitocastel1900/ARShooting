using UniRx;

public interface IInputEventProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyReactiveProperty<bool> InputTapRelease { get; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyReactiveProperty<bool> InputTapPush{ get; }
}
