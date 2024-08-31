using System;
using UnityEngine;
using UniRx;
using Zenject;

/// <summary>
/// タイトルを管理する
/// </summary>
public class TitleWidgetController : MonoBehaviour
{
    /// <summary>
    /// クリックされたときに呼ばれる
    /// </summary>
    public IObservable<Unit> OnClickGameStartButton => _gameStartButton.OnClickAsObservable;
    
    /// <summary>
    /// Canvas
    /// </summary>
    [SerializeField] private Canvas _titleWidget;
    
    /// <summary>
    /// GameStartButtonWidget
    /// </summary>
    [SerializeField] private GameStartButtonWidget _gameStartButton;
    
    private void Start()
    {
        //ゲームスタートボタンがクリックされたら、音を流す
        _gameStartButton
            .OnClickAsObservable
            .Subscribe(_=>
            {
                Hide();
            })
            .AddTo(this.gameObject);
    }
    
    /// <summary>
    /// 表示
    /// </summary>
    public void Show()
    {
        _titleWidget.enabled = true;
    }

    /// <summary>
    /// 非表示
    /// </summary>
    public void Hide()
    {
        _titleWidget.enabled = false;
    }
}
