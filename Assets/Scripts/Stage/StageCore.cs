using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// ステージのプロパティを管理する
/// </summary>
public class StageCore : MonoBehaviour
{
    /// <summary>
    /// 的に弾が当たったら呼ばれる
    /// </summary>
    public IReactiveProperty<bool> IsView => _isView;
    private BoolReactiveProperty _isView = new BoolReactiveProperty(false);

    /// <summary>
    /// ステージ番号
    /// </summary>
    [SerializeField] private int stageNumber;
    
    /// <summary>
    /// StageManager
    /// </summary>
    [Inject] private StageManager _stageManager;
    
    private void Start()
    {
        _stageManager
            .AddStage(stageNumber,this);
    }

    /// <summary>
    /// 表示・非表示を設定する
    /// </summary>
    /// <param name="isActive"></param>
    public void SetView(bool isActive)
    {
        _isView.Value = isActive;
    }
}