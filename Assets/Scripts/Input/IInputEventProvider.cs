using UniRx;

/// <summary>
/// 入力を管理する
/// </summary>
public interface IInputEventProvider
{
    /// <summary>
    /// 発射ボタンが押されたか
    /// </summary>
    IReadOnlyReactiveProperty<bool> IsShotButtonPush { get; }
    
    /// <summary>
    /// ゲームを開始させるボタンが押されたか
    /// </summary>
    IReadOnlyReactiveProperty<bool> IsGameStartPanelButtonPush { get; }
}
