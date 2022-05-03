using UnityEngine;

namespace KID
{
    //類別(腳本)明成必須與左上角檔名完全相同，包含大小寫，不能有空格或特殊字元
    //<summary>
    //上下類型角色控制器
    //控制移動，動畫更新
    //</summary>
    public class TopDownController : MonoBehaviour
    {
        #region 資料:保存系統需要的資料，如移動速度，動畫參數名稱等
        //欄位:修飾詞 資料類型 欄位名稱(指定 預設值);
        //[]屬性 Attrltube
        //SerializeField 序列化欄位-欄位可視化
        //Header 標題
        //Range 範圍 僅適用於數值型資料
        [SerializeField,Header("移動速度"),Range(0,500)]
        private float speed = 1.5f;
        private string parameterRun = "開關-跑步";
        private string parameterDead = "開關-死亡";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;

        #endregion

        #region 事件:程式的入口(Unity)
        //喚醒事件:播放遊戲時會執行一次，處理初始值
        private void Awake()
        {
            //GetComponnent<泛型>-泛型:指任何類型
            //欄位 指定 取得元件<元件名稱>()-取得指定元件存放於欄位
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }

        //更新事件:約60fps
        //取得輸入資料可在此事件處理
        private void Update()
        {
            GetIuput();
            Move();
            Rotate();
        }

        #endregion

        #region 方法:較複雜的行為，如移動功能，更新動畫

        //方法語法:修飾詞 傳回資料類型 方法名稱(參數)(程式內容)
        private void GetIuput()
        {
            //使用靜態資料
            //語法:類別名稱,靜態方法名稱(對應引擎)
            //Horizontal 水平軸向
            //左:方向左鍵與A-傳回-1
            //右:方向右鍵與D-傳回+1
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            //print("水平軸向值:" + h);
        }

        private void Move()
        {
            //使用非靜態資料 non-static
            //語法：欄位名稱.非靜態屬性名稱
            rig.velocity = new Vector2(h, v) * speed; //鋼體.加速度=二維向量*速度
            //水平不等於0 或者 垂直也不等於0
            ani.SetBool(parameterRun, h != 0 || v !=0); //動畫控制器.設定布林值(參數.布林值)=h不等於0，當水平軸向不等於零，就觸發跑步動畫

        }


        private void Rotate()
        {
            //往右移動 Y=0
            //往左移動 Y=180
            //三源運算子
            //語法：布林值 ? 布林值為true：布林值為false
            // h>0 ? 0:180=若水平值 大於等於 零 值為0，否則 值為180
            transform.eulerAngles = new Vector3(0, h >= 0 ? 0:180,0);
        }

        #endregion
    }
}

