using UnityEngine;

namespace KID
{
    ///<summary>
    ///武器系統
    ///1.儲存玩家擁有的武器資料
    ///2.根據武器資料生成武器
    ///3.賦予武器相關資料
    ///</summary>
    
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("武器資料")]
        private DataWeapon dataWeapon;
        [SerializeField, Header("武器刪除時間"),Range(0,5)]
        private float weaponDestoryTime = 3.5f;

        ///<snmmary>
        ///計時器
        ///</snmmary>

        private float timer;


        /// <summary>
        /// 繪製圖示
        /// 作用:在編輯器內繪製圖形輔助開發
        /// 不會在執行檔內出現
        /// </summary>
        private void OnDrawGizmos()
        {
            //圖示顏色
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //繪製圖示
            //transform.position + dataWeapon.v2SpawnPoint[0] 角色座標+生成位置
            //目的:生成位置根據角色位置做移動

            //for迴圈
            //(初始值;條件;每一次迴圈結束執行區塊)
            for (int i = 0; i < dataWeapon.v2SpawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dataWeapon.v2SpawnPoint[i], 0.1f);
            }
            

        }

        private void Start()
        {
            Physics2D.IgnoreLayerCollision(3, 6); //玩家與武器不碰撞
            Physics2D.IgnoreLayerCollision(6, 6); //武器與武器不碰撞
            Physics2D.IgnoreLayerCollision(6, 7); //武器與空氣牆不碰撞
        }

        private void Update()
        {
            SpawnWeapon();
        }

        ///<summary>
        ///生成武器
        ///每隔武器間隔時間就在生成位置上生成武器
        ///</summary>

        private void SpawnWeapon()
        {
            
            //print("經過時間:" + timer);

            //如果計時器大於等於間隔時間
            if (timer >= dataWeapon.interval)
            {
                //隨機值=隨機.範圍(最小值,最大值) 整數不包含最大值
                int random = Random.Range(0, dataWeapon.v2SpawnPoint.Length);
                //座標
                Vector3 pos = transform.position + dataWeapon.v2SpawnPoint[random];
                
                
                //生成物件
                GameObject temp = Instantiate(dataWeapon.goWeapon,pos,Quaternion.identity);
                //暫存武器.取得元件<鋼體>().添加推力(方向*速度)
                temp.GetComponent<Rigidbody2D>().AddForce(dataWeapon.v3Direction * dataWeapon.speedFly);
                //計時器歸零
                timer = 0;
                //刪除物件(遊戲物件 延遲時間)
                Destroy(temp, weaponDestoryTime);
            }
            else //否則
            {
                //計時器累加一個影格的時間
                timer += Time.deltaTime;
            }



        }

    }
}
