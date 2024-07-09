using System;
using UniRx;
using UnityEngine.UI;
using Zenject;

public class TouchInputProvider : IInputEventProvider,IInitializable,IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsShotButtonPush => _isShotButtonPush;
    private BoolReactiveProperty _isShotButtonPush = new BoolReactiveProperty(false);
    
    /// <summary>
    /// 
    /// </summary>
    private Button _shotButton;
    
    /// <summary>
    /// 
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shotButton"></param>
    public TouchInputProvider(Button shotButton)
    {
        _shotButton = shotButton;
    }   
    
    public void Initialize()
    {
        _shotButton
            .OnClickAsObservable()
            .Select(_ =>true)
            .Subscribe(_isShotButtonPush.SetValueAndForceNotify)
            .AddTo(_compositeDisposable);
    }

    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}
