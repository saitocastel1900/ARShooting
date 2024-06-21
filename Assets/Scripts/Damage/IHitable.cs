using UnityEngine;

public interface IHitable
{
    /// <summary>
    /// 当てる
    /// </summary>
    public void Hit(Vector3 position);
}