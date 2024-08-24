using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// 配置するオブジェクトを供給する
/// </summary>
public class PlacedObjectProvider : MonoBehaviour
{
    /// <summary>
    /// 設置するオブジェクトのリスト
    /// </summary>
    public IReadOnlyDictionary<string, GameObject> MakerNamePlacedObjectMap => _makerNamePlacedObjectMap;
    private Dictionary<string, GameObject> _makerNamePlacedObjectMap = new Dictionary<string, GameObject>();

    /// <summary>
    /// マーカー用オブジェクトのプレハブ
    /// </summary>
    [SerializeField] private GameObject[] _placedObject;

    /// <summary>
    /// XRReferenceImageLibrary
    /// </summary>
    [SerializeField] private XRReferenceImageLibrary _referenceImageLibrary;
    
    private void Start()
    {
        //
        for (var i = 0; i < _placedObject.Length; i++)
        {
            var placeObject = Instantiate(_placedObject[i]);
            _makerNamePlacedObjectMap.Add(_referenceImageLibrary[i].name, placeObject);
            placeObject.SetActive(false);
        }
    }
}