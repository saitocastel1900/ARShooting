using UniRx;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// 設置するオブジェクトを管理する
/// </summary>
public class PlacedObjectManager : MonoBehaviour
{
    /// <summary>
    ///MultiImageTrackingManager
    /// </summary>
    [SerializeField] private MultiImageTrackingManager _imageTrackingManager;

    /// <summary>
    ///PlacedObjectProvider
    /// </summary>
    [SerializeField] private PlacedObjectProvider _placedObjectProvider;
    
    void Start()
    {
        //マーカーを読み取ったら、オブジェクトを配置する
        _imageTrackingManager
            .OnImageTracking
            .Subscribe(OnTrackedImagesChanged)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// マーカーを読み取った
    /// </summary>
    /// <param name="eventArgs">検出したマーカー</param>
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            SetActiveObject(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            SetActiveObject(trackedImage);
        }
    }

    /// <summary>
    /// オブジェクトを表示する
    /// </summary>
    /// <param name="trackedImage">検出したマーカー</param>
    private void SetActiveObject(ARTrackedImage trackedImage)
    {
        //マーカーに応じたオブジェクトを取得
        var arObject = _placedObjectProvider.MakerNamePlacedObjectMap[trackedImage.referenceImage.name];
        var imageMarkerTransform = trackedImage.transform;
        
        var markerFrontRotation = imageMarkerTransform.rotation * Quaternion.identity;
        arObject.transform.SetPositionAndRotation(imageMarkerTransform.transform.position, markerFrontRotation);
        arObject.transform.SetParent(imageMarkerTransform);
        
        //マーカーが検出されたら、オブジェクトを表示する
        arObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
    }
}