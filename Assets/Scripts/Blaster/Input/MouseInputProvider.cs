using System;
using UnityEngine.UI;
using UniRx;
using Zenject;

/// <summary>
/// マウス入力を管理する
/// </summary>
public class MouseInputProvider : IInputEventProvider, IInitializable, IDisposable
{
    /// <summary>
    /// 発射ボタンが押されたか
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsShotButtonPush => _isShotButtonPush;
    private BoolReactiveProperty _isShotButtonPush = new BoolReactiveProperty(false);
    
    /// <summary>
    /// 発射ボタン
    /// </summary>
    private Button _shotButton;
    
    /// <summary>
    /// CompositeDisposable
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="shotButton">発射ボタン</param>
    public MouseInputProvider(Button shotButton)
    {
        _shotButton = shotButton;
    }   
    
    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        //発射ボタンの入力に応じて、フラグを立てる
        _shotButton
            .OnClickAsObservable()
            .Select(_ =>true)
            .Subscribe(_isShotButtonPush.SetValueAndForceNotify)
            .AddTo(_compositeDisposable);
    }

    /// <summary>
    /// リソースを開放する
    /// </summary>
    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}