using System;
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
   public IObservable<Unit> OnShowDialogWidgetAsObservable => _dialogWidgetSubject;
   private Subject<Unit> _dialogWidgetSubject = new Subject<Unit>();
   
   /// <summary>
   /// リザルト表示を開始する
   /// </summary>
   public void StartResult() => _dialogWidgetSubject.OnNext(Unit.Default);
}
