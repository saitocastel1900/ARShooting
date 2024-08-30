using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class BrokeTargetEffect : MonoBehaviour
{
   [SerializeField] private Transform _brokeEffect;
   [SerializeField] private Vector2 _forceRange = new Vector2(-1f, 1f);
   [SerializeField] private float _reductionDuration;

   public void PlayEffect()
    {
        var childTransforms = 
            _brokeEffect.GetComponentsInChildren<Transform>().ToList();
        childTransforms.ForEach(t => t.DOScale(Vector3.zero, _reductionDuration));
        
        var childRigidbodies = 
            _brokeEffect.GetComponentsInChildren<Rigidbody>().ToList();
        childRigidbodies.ForEach(rb =>
        {
            rb.isKinematic = false;
            
            var force = new Vector3(
                UnityEngine.Random.Range(_forceRange.x, _forceRange.y),
                UnityEngine.Random.Range(0, _forceRange.y),
                UnityEngine.Random.Range(_forceRange.x, _forceRange.y)
            );
            rb.AddForce(force, ForceMode.Impulse);
            rb.AddTorque(force, ForceMode.Impulse);
        });
    }
}
