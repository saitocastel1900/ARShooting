using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

/// <summary>
/// ゲームプレイ中のステータスを管理する
/// </summary>
public class GamePlayStatusWidget : MonoBehaviour
{
    /// <summary>
    /// HUDWidgetController
    /// </summary>
    [SerializeField] private HUDWidgetController _hudWidgetController;
    
    /// <summary>
    /// Image
    /// </summary>
    [SerializeField] private Image _gameStatusImage;
    
    /// <summary>
    /// ステージクリアのスプライト
    /// </summary>
    [SerializeField] private Sprite _clearStatusSprite;
    
    /// <summary>
    /// 次のステージのスプライト
    /// </summary>
    [SerializeField] private Sprite _nextStatusSprite;
    
    /// <summary>
    /// ゲームクリアのスプライト
    /// </summary>
    [SerializeField] private Sprite _congratulationsStatusSprite;
    
    /// <summary>
    /// ステータスを表示するY座標
    /// </summary>
    [SerializeField] private float _displayPositionY = -140.62f;
    
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
        _defaultPosition = _gameStatusImage.rectTransform.anchoredPosition;

        //ステータスに応じて表示する
        _hudWidgetController
            .OnShowGamePlayStatusAsObservable
            .Subscribe(async phase =>
            {
                switch (phase)
                {
                    case GamePlayStatus.Continue:
                        _gameStatusImage.sprite = _clearStatusSprite;
                        await DisplayGuideAnimation();
                        _gameStatusImage.sprite = _nextStatusSprite;
                        await DisplayGuideAnimation();
                        break;

                    case GamePlayStatus.Congratulation:
                        _gameStatusImage.sprite = _congratulationsStatusSprite;
                        await DisplayGuideAnimation();
                        break;
                }
            });
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
            .OnStart(() => _gameStatusImage.rectTransform.anchoredPosition = _defaultPosition)
            .Append(AnimationUtility.MoveImageY(_gameStatusImage, _displayPositionY))
            .AppendInterval(_animationInterval)
            .Append(AnimationUtility.MoveImageY(_gameStatusImage, _defaultPosition.y));

        await _tweener.Play().AsyncWaitForCompletion();
    }
}