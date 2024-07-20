using UniRx;
using UnityEngine;

public class RemainingTargetCounterTextPresenter : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private int _remainingTargetCount = 10;
    
    /// <summary>
    /// Model
    /// </summary>
    private IRemainingTargetCounterTextModel _model;

    /// <summary>
    /// View
    /// </summary>
    [SerializeField] private RemainingTargetCounterTextView _view;

    
    //ここは改善する必要がある
    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        _model = new RemainingTargetCounterTextModel(_remainingTargetCount);
        _view.Initialize();
        
        Bind();
    }

    /// <summary>
    /// Bind
    /// </summary>
    private void Bind()
    {
        _model.RemainingTargetCountProp
            .Subscribe(_view.SetText)
            .AddTo(this.gameObject);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Decrement()
    {
        _model.Decrement();
    }
}