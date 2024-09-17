using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージを管理する
/// </summary>
public class StageManager : MonoBehaviour
{
    /// <summary>
    /// ステージ
    /// </summary>
    public IReadOnlyDictionary<int, StageCore> Stages => _stages;
    private Dictionary<int,StageCore> _stages = new Dictionary<int,StageCore>();
    
    /// <summary>
    /// 最後のステージか
    /// </summary>
    public bool IsLastStage =>  _currentStageNumber == _stages.Count;

    /// <summary>
    /// 現在のステージ番号
    /// </summary>
    [SerializeField] private int _currentStageNumber = 1;
    
    /// <summary>
    /// ステージを追加
    /// </summary>
    /// <param name="stageNumber">ステージの番号</param>
    /// <param name="stage">ステージ</param>
    public void AddStage(int stageNumber,StageCore stage)
    {
        _stages.Add(stageNumber,stage);
    }
    
    /// <summary>
    /// ステージを表示
    /// </summary>
    public void ShowStage()
    {
        _stages[_currentStageNumber].SetView(true);
    }
    
    /// <summary>
    /// 次のステージへ
    /// </summary>
    public void NextStage()
    {
        _stages[_currentStageNumber].SetView(false);
        _currentStageNumber++;
        _stages[_currentStageNumber].SetView(true);
    }
}
