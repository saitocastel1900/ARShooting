using UnityEngine;

public class Target : MonoBehaviour , IBreakable
{
    public void Break()
    {
        Destroy(gameObject);
    }
}
