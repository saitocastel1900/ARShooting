using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CriWare;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var random = new System.Random();
            var min = -3;
            var max = 3;
            gameObject.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r => {
                r.isKinematic = false;
                r.transform.SetParent(null);
                var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
                r.AddForce(vect/10, ForceMode.Impulse);
                r.AddTorque(vect/10, ForceMode.Impulse);
            });
        }
    }
}


























