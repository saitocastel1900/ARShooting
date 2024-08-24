/// <summary>
/// ゲームの状態を管理する
/// </summary>
public static class GameEnum
{
    /// <summary>
    /// 状態
    /// </summary>
    public enum State
    {
        None,
        
        /// <summary>
        /// 初期化
        /// </summary>
        Initializing,
        
        /// <summary>
        /// ゲームプレイ
        /// </summary>
        Play,
        
        /// <summary>
        /// リザルト表示
        /// </summary>
        Result,
    }
}