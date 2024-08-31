using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームの開始ボタンを管理する
/// </summary>
public class GameStartButtonWidget : MonoBehaviour
{
    /// <summary>
    /// Button
    /// </summary>
    [SerializeField] private Button _gameStartButton;
    
    /// <summary>
    /// クリックされた時に呼ばれる
    /// </summary>
    public IObservable<Unit> OnClickAsObservable => _gameStartButton.OnClickAsObservable();
}
