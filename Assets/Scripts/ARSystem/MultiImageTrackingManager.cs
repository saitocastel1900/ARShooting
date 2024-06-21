using System;
using UniRx;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultiImageTrackingManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public IObservable<ARTrackedImagesChangedEventArgs> OnImageTracking => _imageTrackingSubject;
    private Subject<ARTrackedImagesChangedEventArgs> _imageTrackingSubject = new Subject<ARTrackedImagesChangedEventArgs>();

    /// <summary>
    /// ARTrackedImageManager
    /// </summary>
    [SerializeField] private ARTrackedImageManager _imageManager;
    
    private void Start()
    {
        var s = Observable.FromEvent<ARTrackedImagesChangedEventArgs>(
            handler => _imageManager.trackedImagesChanged += handler,
            handler => _imageManager.trackedImagesChanged -= handler
        ).Subscribe(_imageTrackingSubject.OnNext).AddTo(this.gameObject);
    }
}