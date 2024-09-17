using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// ゲーム目標のガイドを管理する
/// </summary>
public class GoalGuideWidget : MonoBehaviour
{
    /// <summary>
    /// HUDWidgetController
    /// </summary>
    [SerializeField] private HUDWidgetController _hudWidgetController;
    
    /// <summary>
    /// Image
    /// </summary>
    [SerializeField] private Image _golarGuideImage;
    
    /// <summary>
    /// ガイドを表示するY座標
    /// </summary>
    [SerializeField] private float _displayPositionY =  -140.62f;
    
    /// <summary>
    /// アニメーションの間隔
    /// </summary>
    [SerializeField] private float _animationInterval = 2.0f;
    
    /// <summary>
    /// 初期地点
    /// </summary>
    private Vector2 _defaultPosition;
    
    private void Start()
    {
        _defaultPosition = _golarGuideImage.rectTransform.anchoredPosition;
        
        _hudWidgetController
            .OnShowGoalGuideGuideAsObservable
            .Subscribe(_=>DisplayGuideAnimation())
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// ガイドを表示するアニメーション
    /// </summary>
    private void DisplayGuideAnimation()
    {
        var sequence = DOTween.Sequence()
            .OnStart(() => _golarGuideImage.rectTransform.anchoredPosition = _defaultPosition)
            .Append(AnimationUtility.MoveImageY(_golarGuideImage, _displayPositionY))
            .AppendInterval(_animationInterval)
            .Append(AnimationUtility.MoveImageY(_golarGuideImage, _defaultPosition.y));

        sequence.Play();
    }
}
