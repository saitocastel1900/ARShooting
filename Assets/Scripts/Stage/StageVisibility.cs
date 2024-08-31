using UniRx;
using UnityEngine;

public class StageVisibility : MonoBehaviour
{
    [SerializeField] private StageCore _core;
    [SerializeField] private GameObject _stage;

    private void Start()
    {
        _core
            .IsView
            .Subscribe(x=>
            {
                _stage.SetActive(x);
                Debug.Log(x+"こんにちわ");
            })
            .AddTo(this.gameObject);
    }
}