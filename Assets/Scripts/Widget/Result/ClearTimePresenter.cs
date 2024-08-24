using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// クリア時間のデータと見た目の橋渡しをする
/// </summary>
public class ClearTimePresenter : MonoBehaviour
{
    /// <summary>
    /// Model
    /// </summary>
    private ClearTimeModel _model;

    /// <summary>
    /// View
    /// </summary>
    [SerializeField] private ClearTimeView _view;

    /// <summary>
    /// TimerManager
    /// </summary>
    [Inject] private TimerManager _timerManager;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Start()
    {
        _model = new ClearTimeModel();
        _view.Initialize();

        Bind();
    }

    /// <summary>
    /// Bind
    /// </summary>
    private void Bind()
    {
        //時間が経過すると、クリア時間も変更する
        _timerManager
            .CurrentTime
            .Subscribe(x=> _model.SetClearTime(x))
            .AddTo(this.gameObject);
        
        //クリア時間が変更された表示も変更
        _model
            .ClearTimeProp
            .Subscribe(_view.SetText)
            .AddTo(this.gameObject);
    }
}
