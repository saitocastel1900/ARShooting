using TMPro;
using UnityEngine;

public class RemainingTargetCounterTextView : MonoBehaviour
{
    /// <summary>
    /// Text
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
    /// 
    /// </summary>
    public void SetText(int remainingTargetCount)
    {
        _text.text = $"あと{remainingTargetCount}こ";
    }
}
