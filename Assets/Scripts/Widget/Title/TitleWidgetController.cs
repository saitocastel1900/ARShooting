using UnityEngine;
using UniRx;
using Zenject;

/// <summary>
/// タイトルを管理する
/// </summary>
public class TitleWidgetController : MonoBehaviour
{
    /// <summary>
    /// Canvas
    /// </summary>
    [SerializeField] private Canvas _canvas;
    
    /// <summary>
    /// IInputEventProvider
    /// </summary>
    [Inject] private IInputEventProvider _input;
    
    private void Start()
    {
        //ゲームスタートボタンがクリックされたら、非表示にする
        _input
            .IsGameStartPanelButtonPush
            .SkipLatestValueOnSubscribe()
            .Subscribe(_=>_canvas.enabled = false)
            .AddTo(this.gameObject);
    }
}
