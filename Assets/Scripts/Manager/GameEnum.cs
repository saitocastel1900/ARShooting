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
        /// 準備中
        /// </summary>
        Ready,
        
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