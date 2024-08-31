using UniRx;

/// <summary>
/// 的の残段数を管理する
/// </summary>
public interface IRemainingTargetCounterTextModel
{
    /// <summary>
    /// 的の残段数
    /// </summary>
    public IReactiveProperty<int> RemainingTargetCount { get; }
   
    /// <summary>
    /// 的の残存を減らす
    /// </summary>
    public void SetRemainingTargetCount(int currentRemainingTargetCount);
}
