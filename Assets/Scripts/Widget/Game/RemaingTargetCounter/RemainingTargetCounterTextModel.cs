using UniRx;

/// <summary>
/// 的の残存のデータを管理する
/// </summary>
public class RemainingTargetCounterTextModel : IRemainingTargetCounterTextModel
{
    /// <summary>
    /// 的の残存
    /// </summary>
    public IReactiveProperty<int> RemainingTargetCount => _remainingTargetCountProp;
    private IntReactiveProperty _remainingTargetCountProp;
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public RemainingTargetCounterTextModel(int targetCount=0)
    {
        _remainingTargetCountProp = new IntReactiveProperty(targetCount);
    }

    /// <summary>
    /// 的の残存を減らす
    /// </summary>
    public void SetRemainingTargetCount(int currentRemainingTargetCount)
    {
        _remainingTargetCountProp.Value = currentRemainingTargetCount;
    }
}