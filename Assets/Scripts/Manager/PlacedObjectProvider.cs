using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using Zenject;

public class PlacedObjectProvider : MonoBehaviour
{
    /// <summary>
    /// マーカー用オブジェクトのプレハブ
    /// </summary>
    [SerializeField] private GameObject[] _placedObject;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private XRReferenceImageLibrary _referenceImageLibrary;
    
    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyDictionary<string,GameObject> MakerNamePlacedObjectMap => _makerNamePlacedObjectMap;
    private Dictionary<string, GameObject>  _makerNamePlacedObjectMap = new Dictionary<string, GameObject>();

    private void Start()
    {
        for (var i = 0; i < _placedObject.Length; i++)
        {
            var placeObject = Instantiate(_placedObject[i]);
            _makerNamePlacedObjectMap.Add(_referenceImageLibrary[i].name, placeObject);
            placeObject.SetActive(false);
        }
    }
}