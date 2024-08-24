using TMPro;
using UnityEngine;

/// <summary>
/// 的の残存数の見た目を管理する
/// </summary>
public class RemainingTargetCounterTextView : MonoBehaviour
{
    /// <summary>
    /// TextMeshProUGUI
    /// </summary>
    [SerializeField] private TextMeshProUGUI _text;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        SetText(0);
    }
        
    /// <summary>
    /// 残存数を設定する
    /// </summary>
    /// <param name="remainingTargetCount">残存数</param>
    public void SetText(int remainingTargetCount)
    {
        _text.text = $"あと{remainingTargetCount}こ";
    }
}
