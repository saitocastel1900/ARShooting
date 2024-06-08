using System;
using UniRx;
using UnityEngine;
using Zenject;

public class MouseInputProvider : IInputEventProvider, IInitializable, IDisposable
{
    public IReadOnlyReactiveProperty<bool> InputTapRelease => _inputTapRelease;
    private BoolReactiveProperty _inputTapRelease=new BoolReactiveProperty();

    public IReadOnlyReactiveProperty<bool> InputTapPush => _inputTapPush;
    private BoolReactiveProperty _inputTapPush=new BoolReactiveProperty();
    
    public IReadOnlyReactiveProperty<Vector3> InputTapPosition => _inputTapPosition;
    private Vector3ReactiveProperty _inputTapPosition=new Vector3ReactiveProperty();
    
    /// <summary>
    /// 
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
    
    public void Initialize()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonUp(0))
            .Select(_ =>true)
            .Subscribe(_inputTapRelease.SetValueAndForceNotify).AddTo(_compositeDisposable);
        
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => true)
            .Subscribe(_inputTapPush.SetValueAndForceNotify).AddTo(_compositeDisposable);
        
        _inputTapPush
            .Select(_ =>Input.mousePosition)
            .Subscribe(_inputTapPosition.SetValueAndForceNotify).AddTo(_compositeDisposable);
    }

    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}