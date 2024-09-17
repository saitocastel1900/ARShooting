using UniRx;
using DG.Tweening;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 発射ボタンのアニメーションを管理する
/// </summary>
public class ShotButtonAnimator : MonoBehaviour
{
    /// <summary>
    /// 発射ボタン
    /// </summary>
    [SerializeField] private Button _button;
    
    /// <summary>
    /// Tweener
    /// </summary>
    private Tweener tweener = null;

    private void Start()
    {
        // ボタンが押されたら、アニメーションを再生する
        _button
            .OnPointerDownAsObservable()
            .Subscribe(_=>PressAnimation())
            .AddTo(this.gameObject);
        
        // ボタンを離したら、アニメーションを再生する
        _button
            .OnPointerUpAsObservable()
            .Subscribe(_=>ReleaseAnimation())
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// ボタンが押されたアニメーション
    /// </summary>
    private void PressAnimation()
    {
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
            transform.localScale = Vector3.one;
        }

        tweener = transform.DOScale(
                endValue: new Vector3(0.9f, 0.9f, 0.9f),
                duration: 0.2f
            )
            .SetEase(Ease.OutExpo);
    }

    /// <summary>
    /// ボタンが話されたアニメーション
    /// </summary>
    private void ReleaseAnimation()
    {
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
            transform.localScale = Vector3.one;
        }

        tweener = transform.DOPunchScale(
            punch: Vector3.one * 0.1f,
            duration: 0.2f,
            vibrato: 1
        ).SetEase(Ease.OutExpo);
    }
}
