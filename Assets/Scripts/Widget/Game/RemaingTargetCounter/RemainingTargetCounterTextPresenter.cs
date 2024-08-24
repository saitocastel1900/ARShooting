using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// 的の残存数のデータと見た目の橋渡しをする
/// </summary>
public class RemainingTargetCounterTextPresenter : MonoBehaviour
{
    /// <summary>
    /// Model
    /// </summary>
    private IRemainingTargetCounterTextModel _model;

    /// <summary>
    /// View
    /// </summary>
    [SerializeField] private RemainingTargetCounterTextView _view;

    /// <summary>
    /// TargetProvider
    /// </summary>
    [Inject] private TargetProvider _targetProvider;
    
    /// <summary>
    /// 初期化
    /// </summary>
    public void Start()
    {
        _model = new RemainingTargetCounterTextModel(_targetProvider.Targets.Count);
        _view.Initialize();
        
        Bind();
    }

    /// <summary>
    /// Bind
    /// </summary>
    private void Bind()
    {
        //的の残存数が減ったら、データを変更する
        _targetProvider
            .Targets
            .ObserveRemove()
            .Subscribe(_=>_model.Decrement());
        
        //的の残存数が変更された表示も変更
        _model.RemainingTargetCount
            .Subscribe(_view.SetText)
            .AddTo(this.gameObject);
    }
}