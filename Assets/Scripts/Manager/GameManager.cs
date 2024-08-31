using System.Collections;
using System.Linq;
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

    [SerializeField] private MultiImageTrackingManager _imageTrackingManager;
    
    [SerializeField] private TitleWidgetController _titleWidget;
    
    /// <summary>
    /// TargetProvider
    /// </summary>
    [Inject] private TargetProvider _targetProvider;
    
    [Inject] private StageManager _stageManager;
    
    private void Start()
    {
        _titleWidget.
            OnClickGameStartButton
            .Subscribe(_=> _currentState.Value = GameEnum.State.Initializing)
            .AddTo(this.gameObject);

        _targetProvider
            .Targets
            .ObserveCountChanged().Subscribe(x => Debug.Log(x));
        
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
        _imageTrackingManager
            .OnImageTracking
            .Where(_=>_stageManager.Stages.Count > 0)
            .Subscribe(_=>_currentState.Value = GameEnum.State.Play);
        
        yield return null;
    }
    
    /// <summary>
    /// ゲームプレイ中
    /// </summary>
    private void Play()
    {
        _stageManager.ShowStage();
        
        _timerManager.StartCountTime();
        
        _targetProvider
            .Targets
            .ObserveCountChanged()
            .Where(x => x == 0)
            .Subscribe(_=>
            {
                if (_stageManager.IsLastStage)
                {
                    //ステージをすべてクリアできたらリザルト
                    _timerManager.StopTimer();
                    _currentState.Value = GameEnum.State.Result;
                }
                else
                {
                    //的の数が0になったら次のステージに移動
                    _stageManager.NextStage();
                }
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
