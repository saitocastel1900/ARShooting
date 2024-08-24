using TMPro;
using UnityEngine;

/// <summary>
/// クリア時間の見た目を管理する
/// </summary>
public class ClearTimeView : MonoBehaviour
{
    /// <summary>
    /// TextMeshProUGUI
    /// </summary>
    [SerializeField] private TextMeshProUGUI _scoreText;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        _scoreText.text = "";
    }

    /// <summary>
    /// スコアを設定する
    /// </summary>
    /// <param name="time">スコア</param>
    public void SetText(int time)
    {
        _scoreText.text = time.ToString();
    }
}
