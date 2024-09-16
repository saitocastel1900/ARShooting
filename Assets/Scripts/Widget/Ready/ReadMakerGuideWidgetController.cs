using System;
using UnityEngine;
using UniRx;

/// <summary>
/// ガイドを管理する
/// </summary>
public class ReadMakerGuideWidgetController : MonoBehaviour
{
    /// <summary>
    /// マーカーを探しているか
    /// </summary>
    public IObservable<Unit> OnSearchingMaker => _searchingMakerSubject;
    private Subject<Unit> _searchingMakerSubject = new Subject<Unit>();
    
    /// <summary>
    /// マーカーが読み取れたか
    /// </summary>
    public IObservable<Unit> OnLoadedMaker => _LoadedMakerSubject;
    private Subject<Unit> _LoadedMakerSubject = new Subject<Unit>();
    
    /// <summary>
    /// マーカー読み取りのガイドが終了したか
    /// </summary>
    public IObservable<Unit> OnFinishMakerGuide => _finishMakerGuideSubject;
    private Subject<Unit> _finishMakerGuideSubject = new Subject<Unit>();
    
    /// <summary>
    /// マーカー読み取りのガイドを始める
    /// </summary>
    public void StartMakerGuide() => _searchingMakerSubject.OnNext(Unit.Default);
    
    /// <summary>
    /// ガイドを終了する
    /// </summary>
    public void FinishMakerGuide() =>  _LoadedMakerSubject.OnNext(Unit.Default);
    
    /// <summary>
    /// ガイドのアニメーションが終了した
    /// </summary>
    public void FinishMakerGuideAnimation() => _finishMakerGuideSubject.OnNext(Unit.Default);
}
