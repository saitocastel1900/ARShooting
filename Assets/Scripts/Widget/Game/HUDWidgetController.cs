using System;
using UnityEngine;
using UniRx;

/// <summary>
/// HUDを管理する
/// </summary>
public class HUDWidgetController : MonoBehaviour
{
    /// <summary>
    /// 目標ガイドを表示するか
    /// </summary>
    public IObservable<Unit> OnShowGoalGuideGuideAsObservable => _goalGuideGuideSubject;
    private Subject<Unit> _goalGuideGuideSubject = new Subject<Unit>();
    
    /// <summary>
    /// ゲームプレイ中のステータスを表示するか
    /// </summary>
    public IObservable<GamePlayStatus> OnShowGamePlayStatusAsObservable => _gamePlayStatusSubject;
    private Subject<GamePlayStatus> _gamePlayStatusSubject = new Subject<GamePlayStatus>();
   
    /// <summary>
    /// ゲーム目標のガイドを始める
    /// </summary>
    public void StartGoalGuide() => _goalGuideGuideSubject.OnNext(Unit.Default);
    
    /// <summary>
    /// ゲームプレイ中のステータス更新する
    /// </summary>
    public void UpdateGamePlayStatus(GamePlayStatus status) =>  _gamePlayStatusSubject.OnNext(status);
    
    /// <summary>
    /// Canvas
    /// </summary>
    [SerializeField] private Canvas _canvas;
   
    private void Start()
    {
        _goalGuideGuideSubject
            .Subscribe(_=>_canvas.enabled = true)
            .AddTo(this.gameObject);
    }
}