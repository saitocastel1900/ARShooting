using UniRx;
using UnityEngine;
using Zenject;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    
    [SerializeField] private float _bulletSpeed = 20;
    
    [Inject] private IInputEventProvider _inputEventProvider;
    
    private void Start()
    {
        _inputEventProvider.InputTapPush
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ =>
            {
                Vector3 screenPosition = Input.mousePosition;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                GameObject bulletObject = Instantiate(_bulletPrefab,worldPosition,Quaternion.identity);
                ShotBullet(bulletObject);
            })
            .AddTo(this);
    }
    
    private void ShotBullet(GameObject bulletObject)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldDir = ray.direction;
                
        bulletObject.GetComponent<Rigidbody>().AddForce(worldDir* _bulletSpeed,ForceMode.Impulse);
    }
}
