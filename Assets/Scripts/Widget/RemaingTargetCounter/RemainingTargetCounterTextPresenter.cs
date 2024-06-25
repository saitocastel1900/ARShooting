using System;
using UniRx;
using Zenject;

public class RemainingTargetCounterTextPresenter : IDisposable, IInitializable
{
    /// <summary>
    /// Model
    /// </summary>
    private IRemainingTargetCounterTextModel _model;

    /// <summary>
    /// View
    /// </summary>
    private RemainingTargetCounterTextView _view;

    /// <summary>
    /// Disposable
    /// </summary>
    private CompositeDisposable _compositeDisposable;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public RemainingTargetCounterTextPresenter(IRemainingTargetCounterTextModel model, RemainingTargetCounterTextView view)
    {
        _model = model;
        _view = view;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        _compositeDisposable = new CompositeDisposable();
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
            .AddTo(_compositeDisposable);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Decrement()
    {
        _model.Decrement();
    }
    
    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}