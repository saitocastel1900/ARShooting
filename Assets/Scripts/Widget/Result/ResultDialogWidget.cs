using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// ダイアログを管理する
/// </summary>
public class ResultDialogWidget : MonoBehaviour
{
    /// <summary>
    /// Canvas
    /// </summary>
    [SerializeField] private CanvasGroup _canvas;

    /// <summary>
    /// 表示する時間
    /// </summary>
    [SerializeField] private float _fadeInDuration = 1.0f;
    
    /// <summary>
    /// ResultManager
    /// </summary>
    [Inject] private ResultDialogWidgetController _resultDialogWidgetController;
    
    private void Start()
    {
        //的をすべて当てたら、リザルトダイアログを表示する
        _resultDialogWidgetController
            .OnShowDialogWidgetAsObservable
            .Subscribe(_=>AnimationUtility.FadeInCanvasGroupTween(_canvas,_fadeInDuration).SetLink(this.gameObject))
            .AddTo(this.gameObject);
    }
}
