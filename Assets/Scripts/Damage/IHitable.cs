using UnityEngine;

/// <summary>
/// 当てることを管理する
/// </summary>
public interface IHitable
{
   /// <summary>
   /// 当てる
   /// </summary>
   /// <param name="position">当たった場所</param>
    public void Hit(Vector3 position);
}