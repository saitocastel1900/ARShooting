using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// ゲームの進行を管理する
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 現在のゲームの状態
    /// </summary>
    public IReactiveProperty<GameEnum.State> CurrentStateProp => _currentState;
    private ReactiveProperty<GameEnum.State> _currentState = new ReactiveProperty<GameEnum.State>
        (GameEnum.State.None);
    
    /// <summary>
    /// TimerManager
    /// </summary>
    [SerializeField] private TimerManager _timerManager;
    
    /// <summary>
    /// ResultManager
    /// </summary>
    [SerializeField] private ResultManager _resultManager;
    
    /// <summary>
    /// TargetProvider
    /// </summary>
    [Inject] private TargetProvider _targetProvider;
    
    private void Start()
    {
        _currentState.Value = GameEnum.State.Play;
        
        _currentState
            .DistinctUntilChanged()
            .Subscribe(OnStateChanged)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <returns></returns>
    private IEnumerator InitializeCoroutine()
    {
        yield return null;
    }
    
    /// <summary>
    /// ゲームプレイ中
    /// </summary>
    private void Play()
    {
        _timerManager.StartTimer();
        
        //的の数が0になったらリザルトを表示する
        _targetProvider
            .Targets
            .ObserveCountChanged()
            .Where(x=>x==0)
            .Subscribe(_=>
            {
                _timerManager.StopTimer();
                _currentState.Value = GameEnum.State.Result;
            });
    }

    /// <summary>
    /// リザルトを表示する
    /// </summary>
    private void Result()
    {
        _resultManager.StartResult();  
    }

    /// <summary>
    /// 状態が変化した
    /// </summary>
    /// <param name="currentState">現在の状態</param>
    private void OnStateChanged(GameEnum.State currentState)
    {
        switch (currentState)
        {
            case GameEnum.State.Initializing:
                StartCoroutine(InitializeCoroutine());
                break;
            case GameEnum.State.Play:
                Play();
                break;
            case GameEnum.State.Result:
                Result();
                break;
            default:
                break;
        }
    }
}
