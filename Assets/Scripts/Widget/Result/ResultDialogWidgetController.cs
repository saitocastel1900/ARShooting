using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// ダイアログを管理する
/// </summary>
public class ResultDialogWidgetController : MonoBehaviour
{
    /// <summary>
    /// Canvas
    /// </summary>
    [SerializeField] private Canvas _dailogCanvas;
    
    /// <summary>
    /// ResultManager
    /// </summary>
    [Inject] private ResultManager _resultManager;
    
    private void Start()
    {
        //的をすべて当てたら、リザルトダイアログを表示する
        _resultManager
            .IsShowResultDialog
            .Where(x=>x==true)
            .Subscribe(x=>_dailogCanvas.enabled = x)
            .AddTo(this.gameObject);
    }
}
