using UniRx;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacedObjectManager : MonoBehaviour
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
            .OnImageTracking
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
        var arObject = _placedObjectProvider.MakerNamePlacedObjectMap[trackedImage.referenceImage.name];
        var imageMarkerTransform = trackedImage.transform;
        
        var markerFrontRotation = imageMarkerTransform.rotation * Quaternion.identity;
        arObject.transform.SetPositionAndRotation(imageMarkerTransform.transform.position, markerFrontRotation);
        arObject.transform.SetParent(imageMarkerTransform);
        
        arObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
    }
}