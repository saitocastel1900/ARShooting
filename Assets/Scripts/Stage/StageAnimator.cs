using DG.Tweening;
using UniRx;
using UnityEngine;

/// <summary>
/// ステージのアニメーションを管理する
/// </summary>
public class StageAnimator : MonoBehaviour
{
    /// <summary>
    /// ステージ
    /// </summary>
    [SerializeField] private StageCore _core;
    
    /// <summary>
    /// ステージをマスクする板のTransform
    /// </summary>
    [SerializeField] private Transform _maskPlaneTransform;
    
    /// <summary>
    /// ステージをマスクする板のMeshRenderer
    /// </summary>
    [SerializeField] private MeshRenderer _maskPlaneMeshRenderer;
    
    /// <summary>
    /// ステージを表示するY座標
    /// </summary>
    [SerializeField] private float _displayPositionY = 0f;
    
    /// <summary>
    /// アニメーションの時間
    /// </summary>
    [SerializeField] private float _duration = 2f;
    
    /// <summary>
    /// 初期地点
    /// </summary>
    private Vector2 _defaultPosition;
    
    /// <summary>
    /// Tween
    /// </summary>
    private Tween _tweener = null;
    
    // Start is called before the first frame update
    private void Start()
    {
        _defaultPosition = _maskPlaneTransform.transform.position;
        
        _core
            .IsView
            .Where(x=>x==true)
            .Subscribe(_=>DisplayStageAnimation())
            .AddTo(this.gameObject);
    }
    
    /// <summary>
    /// ステージを見せるアニメーション
    /// </summary>
    private void DisplayStageAnimation()
    {
        if (_tweener != null && _tweener.IsActive())
        {
            _tweener.Kill();
            _tweener = null;
        }
        
        _tweener = DOTween.Sequence()
            .OnStart(()=>
            {
                _maskPlaneTransform.position = _defaultPosition;
                _maskPlaneMeshRenderer.enabled = true;
            })
            .Append(_maskPlaneTransform.DOMoveY(_displayPositionY, _duration))
            .SetEase(Ease.OutCubic)
            .OnComplete(()=>_maskPlaneMeshRenderer.enabled = false);

        _tweener.Play();
    }
}
