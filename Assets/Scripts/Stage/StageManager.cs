using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public IReadOnlyDictionary<int, StageCore> Stages => _stages;
    private Dictionary<int,StageCore> _stages = new Dictionary<int,StageCore>();
    
    public bool IsLastStage =>  _currentStageNumber == _stages.Count;

    [SerializeField] private int _currentStageNumber = 1;
    
    public void AddStage(int stageNumber,StageCore stage)
    {
        _stages.Add(stageNumber,stage);
    }
    
    public void ShowStage()
    {
        _stages[_currentStageNumber].SetView(true);
    }
    
    public void NextStage()
    {
        _stages[_currentStageNumber].SetView(false);
        _currentStageNumber++;
        _stages[_currentStageNumber].SetView(true);
    }
}
