using UniRx;

/// <summary>
/// クリア時間のデータを管理する
/// </summary>
public class ClearTimeModel
{
    /// <summary>
    /// クリア時間
    /// </summary>
    public IReactiveProperty<int> ClearTimeProp => _clearTimeProperty;
    private IntReactiveProperty _clearTimeProperty;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ClearTimeModel()
    {
        _clearTimeProperty = new IntReactiveProperty(0);
    }

    /// <summary>
    /// クリア時間を設定する
    /// </summary>
    public void SetClearTime(int time)
    {
        _clearTimeProperty.Value = time;
    }
}
