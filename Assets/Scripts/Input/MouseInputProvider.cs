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
    /// ゲームを開始させるボタンが押されたか
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsGameStartPanelButtonPush => _isGameStartPanelButtonPush;
    private BoolReactiveProperty _isGameStartPanelButtonPush = new BoolReactiveProperty(false);
    
    /// <summary>
    /// 発射ボタン
    /// </summary>
    private Button _shotButton;

    /// <summary>
    /// ゲームを開始させるボタン
    /// </summary>
    private Button _gameStartPanelButton;
    
    /// <summary>
    /// CompositeDisposable
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="shotButton">発射ボタン</param>
    public MouseInputProvider(Button shotButton, Button gameStartPanelButton)
    {
        _shotButton = shotButton;
        _gameStartPanelButton = gameStartPanelButton;
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
        
        //発射ボタンの入力に応じて、フラグを立てる
        _gameStartPanelButton
            .OnClickAsObservable()
            .Select(_ =>true)
            .Subscribe(_isGameStartPanelButtonPush.SetValueAndForceNotify)
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