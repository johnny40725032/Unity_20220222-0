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
            
            print("經過時間:" + timer);

            //如果計時器大於等於間隔時間
            if (timer >= dataWeapon.interval)
            {
                //生成物件
                Instantiate(dataWeapon.goWeapon);
                //計時器歸零
                timer = 0;

            }
            else //否則
            {
                //計時器累加一個影格的時間
                timer += Time.deltaTime;
            }

        }

    }
}
