using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タップでゲームを始めるを管理する
/// </summary>
public class TapGameStartWidget : MonoBehaviour
{
    /// <summary>
    /// Image
    /// </summary>
    [SerializeField] private Image _TapGameStartImage;

    private void Start()
    {
        //点滅アニメーションをする
        AnimationUtility
            .FadeImageLoopTween(_TapGameStartImage)
            .SetLink(this.gameObject);
    }
}