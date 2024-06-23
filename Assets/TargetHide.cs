using UniRx;
using UnityEngine;

public class TargetHide : MonoBehaviour
{
    [SerializeField] private TargetCore _core;
  
    void Start()
    {
        _core.IsHit 
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ => this.gameObject.SetActive(false))
            .AddTo(this.gameObject);
    }
}
