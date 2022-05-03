using UnityEngine;

namespace KID
{
    ///<summary>
    ///武器資料
    ///1.飛行速度
    ///2.攻擊力
    ///3.數量
    ///4.數量上限
    ///5.生成位置
    ///6.攻擊間隔
    ///<summary>
    [CreateAssetMenu(menuName ="KID/DataWeapon",fileName ="Data Weappon")]
    public class DataWeapon:ScriptableObject
    {
        [Header("飛行速度"), Range(0, 3500)]
        public float speedFly = 500;
        [Header("攻擊力"), Range(0,1000)]
        public float attack = 10;
        [Header("起始數量"), Range(1, 5)]
        public int countStart = 1;
        [Header("數量上限"), Range(1, 50)]
        public int countMax = 20;
        [Header("攻擊間隔"), Range(0, 5)]
        public float interval=3.5f;

        [Header("生成位置")]
        public Vector3[] v2SpawnPoint;
        [Header("武器物件")]
        public GameObject goWeapon;
        [Header("飛行方向")]
        public Vector3 v3Direction;
    }

}