using UniRx;
using UnityEngine;
using Zenject;

public class StageCore : MonoBehaviour
{
    /// <summary>
    /// 的に弾が当たったら呼ばれる
    /// </summary>
    public IReactiveProperty<bool> IsView => _isView;
    private BoolReactiveProperty _isView = new BoolReactiveProperty(false);

    [SerializeField] private int stageNumber;
    
    [Inject] private StageManager _stageManager;
    
    private void Start()
    {
        _stageManager.AddStage(stageNumber,this);
    }

    public void SetView(bool isActive)
    {
        _isView.Value = isActive;
    }
}