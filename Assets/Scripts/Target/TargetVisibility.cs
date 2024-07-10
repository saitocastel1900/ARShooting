using UniRx;
using UnityEngine;

public class TargetVisibility : MonoBehaviour
{
    [SerializeField] private TargetCore _core;
  
    void Start()
    {
        _core
            .HitPosProp 
            .SkipLatestValueOnSubscribe()
            .Select(_=>false)
            .Subscribe(this.gameObject.SetActive)
            .AddTo(this.gameObject);
    }
}
