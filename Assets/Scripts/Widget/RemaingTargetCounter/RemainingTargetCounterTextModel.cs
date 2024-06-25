using UniRx;

public class RemainingTargetCounterTextModel : IRemainingTargetCounterTextModel
{
    /// <summary>
    /// 
    /// </summary>
    public IReactiveProperty<int> RemainingTargetCountProp => _remainingTargetCountProp;

    private IntReactiveProperty _remainingTargetCountProp;
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public RemainingTargetCounterTextModel(int remainingTargetCount)
    {
        _remainingTargetCountProp = new IntReactiveProperty(remainingTargetCount);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Decrement()
    {
        _remainingTargetCountProp.Value--;
    }
}