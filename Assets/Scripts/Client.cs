using UniRx;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Client : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private MultiImageTrackingManager _imageTrackingManager;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private PlacedObjectProvider _placedObjectProvider;


    // Start is called before the first frame update
    void Start()
    {
        _imageTrackingManager
            .OnImageTrackingCallBack
            .Subscribe(OnTrackedImagesChanged)
            .AddTo(this.gameObject);
    }

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

    private void SetActiveObject(ARTrackedImage trackedImage)
    {
        //認識した画像マーカーの名前を使って辞書から任意のオブジェクトを引っ張り出す
        var arObject = _placedObjectProvider.MakerNamePlacedObjectMap[trackedImage.referenceImage.name];
        var imageMarkerTransform = trackedImage.transform;

        //位置合わせ
        var markerFrontRotation = imageMarkerTransform.rotation * Quaternion.Euler(0f, 0f, 0f);
        arObject.transform.SetPositionAndRotation(imageMarkerTransform.transform.position, markerFrontRotation);
        arObject.transform.SetParent(imageMarkerTransform);

        //トラッキングの状態に応じてARオブジェクトの表示を切り替え
        arObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
    }
}