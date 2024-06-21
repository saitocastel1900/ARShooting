using UnityEngine;

public class Target : MonoBehaviour, IHitable
{
    [SerializeField] private ParticleSystem _particle;

    public void Hit(Vector3 position)
    {
       var effect = Instantiate(_particle, position, Quaternion.identity);
       effect.Play();
       this.gameObject.SetActive(false);
    }
}