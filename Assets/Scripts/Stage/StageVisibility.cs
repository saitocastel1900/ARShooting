using UniRx;
using UnityEngine;

/// <summary>
/// ステージの表示・非表示を管理する
/// </summary>
public class StageVisibility : MonoBehaviour
{
    /// <summary>
    /// ステージ
    /// </summary>
    [SerializeField] private StageCore _core;

    /// <summary>
    /// ステージのオブジェクト
    /// </summary>
    [SerializeField] private GameObject _stageObject;
    
    private void Start()
    {
        _core
            .IsView
            .Subscribe(_stageObject.SetActive)
            .AddTo(this.gameObject);
    }
}