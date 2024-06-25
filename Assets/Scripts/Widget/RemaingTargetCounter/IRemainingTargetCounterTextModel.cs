using UniRx;

public interface IRemainingTargetCounterTextModel
{
    /// <summary>
    /// 
    /// </summary>
    public IReactiveProperty<int> RemainingTargetCountProp { get; }
   
    /// <summary>
    /// 
    /// </summary>
    public void Decrement();
}
