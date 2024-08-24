using System;
using UniRx;
using UnityEngine;

/// <summary>
/// 時間を管理する
/// </summary>
public class TimerManager : MonoBehaviour
{
    /// <summary>
    /// 経過時間
    /// </summary>
    public IReactiveProperty<int> CurrentTime => _currentTimeProp;
    private IntReactiveProperty _currentTimeProp = new IntReactiveProperty(0);

    /// <summary>
    /// IDisposable
    /// </summary>
    private IDisposable _disposable;
    
    /// <summary>
    /// 時間を数え始める
    /// </summary>
    public void StartTimer()
    {
        _disposable = Observable
            .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
            .Select(x => (int)x)
            .Subscribe(x => _currentTimeProp.Value = x);
    }

    /// <summary>
    /// 時間を止める
    /// </summary>
    public void StopTimer()
    {
        _disposable.Dispose();
    }
}