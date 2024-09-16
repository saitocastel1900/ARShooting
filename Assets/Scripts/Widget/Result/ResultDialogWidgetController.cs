using UniRx;
using UnityEngine;

/// <summary>
/// リザルトを管理する
/// </summary>
public class ResultDialogWidgetController : MonoBehaviour
{
   /// <summary>
   /// ダイアログを表示するか
   /// </summary>
   public IReactiveProperty<bool> IsShowResultDialog => _isShowResultDialog;
   private BoolReactiveProperty _isShowResultDialog = new BoolReactiveProperty(false);

   /// <summary>
   /// リザルト表示を開始する
   /// </summary>
   public void StartResult() => _isShowResultDialog.Value = true;
}
