using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// マーカー読み取りガイドを管理する
/// </summary>
public class ReadMakerGuideWidget : MonoBehaviour
{
    /// <summary>
    /// ReadMakerGuideWidgetController
    /// </summary>
    [SerializeField] ReadMakerGuideWidgetController _readMakerGuideWidgetController;
    
    /// <summary>
    /// Image
    /// </summary>
    [SerializeField] private Image _readMakerGuideImage;
    
    /// <summary>
    /// マーカーを読み取ったスプライト
    /// </summary>
    [SerializeField] private Sprite _loadedMakerSprite;
    
    /// <summary>
    /// ガイドを表示するY座標
    /// </summary>
    [SerializeField] private float _displayPositionY =  -140.63f;
    
    /// <summary>
    /// アニメーションの間隔
    /// </summary>
    [SerializeField] private float _animationInterval = 2.0f;
    
    /// <summary>
    /// 初期地点
    /// </summary>
    private Vector2 _defaultPosition;
    
    /// <summary>
    /// Tween
    /// </summary>
    private Tween _tweener = null;
    
    private void Start()
    {
        _defaultPosition = _readMakerGuideImage.rectTransform.anchoredPosition;

        _readMakerGuideWidgetController
            .OnSearchingMaker
            .Subscribe(async _=> await DisplayGuideAnimation())
            .AddTo(this.gameObject);
        
        _readMakerGuideWidgetController
            .OnLoadedMaker
            .Subscribe(async _ =>
            {
                _readMakerGuideImage.sprite = _loadedMakerSprite;
                await DisplayGuideAnimation();
                _readMakerGuideWidgetController.FinishMakerGuideAnimation();
            })
            .AddTo(this.gameObject);
    }
    
    /// <summary>
    /// ガイドを表示するアニメーション
    /// </summary>
    private async UniTask DisplayGuideAnimation()
    {
        if (_tweener != null && _tweener.IsActive())
        {
            _tweener.Kill();
            _tweener = null;
        }
        
        _tweener = DOTween.Sequence()
            .OnStart(() => _readMakerGuideImage.rectTransform.anchoredPosition = _defaultPosition)
            .Append(AnimationUtility.MoveImageY(_readMakerGuideImage, _displayPositionY))
            .AppendInterval(_animationInterval)
            .Append(AnimationUtility.MoveImageY(_readMakerGuideImage, _defaultPosition.y));

        await _tweener.Play().AsyncWaitForCompletion();
    }
}