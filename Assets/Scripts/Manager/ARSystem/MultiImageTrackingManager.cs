using System;
using UniRx;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// イメージトラキングを管理する
/// </summary>
public class MultiImageTrackingManager : MonoBehaviour
{
    /// <summary>
    /// イメージトラッキングをしたら呼ばれる
    /// </summary>
    public IObservable<ARTrackedImagesChangedEventArgs> OnImageTracking => _imageTrackingSubject;
    private Subject<ARTrackedImagesChangedEventArgs> _imageTrackingSubject = new Subject<ARTrackedImagesChangedEventArgs>();

    /// <summary>
    /// ARTrackedImageManager
    /// </summary>
    [SerializeField] private ARTrackedImageManager _imageManager;
    
    private void Start()
    {
        //イメージトラッキングしたらフラグを立てる
        Observable.FromEvent<ARTrackedImagesChangedEventArgs>(
            handler => _imageManager.trackedImagesChanged += handler,
            handler => _imageManager.trackedImagesChanged -= handler
        ).Subscribe(_imageTrackingSubject.OnNext).AddTo(this.gameObject);
    }
}