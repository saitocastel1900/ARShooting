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
    /// MultiImageTrackingManager
    /// </summary>
    [SerializeField] private MultiImageTrackingManager _imageTrackingManager;
    
    /// <summary>
    /// ReadMakerGuideWidgetController
    /// </summary>
    [SerializeField] private ReadMakerGuideWidgetController _readMakerGuideWidgetController;
    
    /// <summary>
    /// HUDWidgetController
    /// </summary>
    [SerializeField] private HUDWidgetController _hudWidgetController;
    
    /// <summary>
    /// ResultDialogWidgetControllr
    /// </summary>
    [SerializeField] private ResultDialogWidgetController _resultManager;
    
    /// <summary>
    /// TargetProvider
    /// </summary>
    [Inject] private TargetProvider _targetProvider;
    
    /// <summary>
    /// StageManager
    /// </summary>
    [Inject] private StageManager _stageManager;
    
    /// <summary>
    /// IInputEventProvider
    /// </summary>
    [Inject] private IInputEventProvider _input;
    
    private void Start()
    {
        //画面がタップされたら、ゲームをはじめる
        _input
            .IsGameStartPanelButtonPush
            .SkipLatestValueOnSubscribe()
            .Subscribe(_=> _currentState.Value = GameEnum.State.Ready)
            .AddTo(this.gameObject);
        
        _currentState
            .DistinctUntilChanged()
            .Subscribe(OnStateChanged)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 準備中
    /// </summary>
    private void Ready()
    {
        _readMakerGuideWidgetController
            .StartMakerGuide();
        
        //マーカーを読み取れたら、ゲームを開始する
        _imageTrackingManager
            .OnImageTracking
            .Where(_=>_stageManager.Stages.Count > 0)
            .FirstOrDefault()
            .Subscribe(_=> _readMakerGuideWidgetController.FinishMakerGuide()); 
        
        _readMakerGuideWidgetController
            .OnFinishMakerGuide
            .Subscribe(_=>_currentState.Value = GameEnum.State.Play);
    }
    
    /// <summary>
    /// ゲームプレイ中
    /// </summary>
    private void Play()
    {
        _stageManager.ShowStage();
        
        _hudWidgetController.StartGoalGuide();
        
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
                    //まだクリアしていなかったステージがあったら、次のステージへ
                    _hudWidgetController.UpdateGamePlayStatus(GamePlayStatus.Continue);
                    _stageManager.NextStage();
                }
            });
    }

    /// <summary>
    /// リザルトを表示する
    /// </summary>
    private void Result()
    {
        _hudWidgetController.UpdateGamePlayStatus(GamePlayStatus.Congratulation);
        _resultManager.StartResult();  
    }

    /// <summary>
    /// 状態が変化した
    /// </summary>
    /// <param name="currentState">現在の状態</param>
    private void OnStateChanged(GameEnum.State currentState)
    {
        Debug.Log(currentState);
        
        switch (currentState)
        {
            case GameEnum.State.Ready:
                Ready();
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
