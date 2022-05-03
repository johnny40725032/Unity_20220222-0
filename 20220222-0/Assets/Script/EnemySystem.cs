using UnityEngine;

namespace KID
{
    ///<summary>
    ///1.�l�ܪ��a
    ///2.����
    ///<summary>

    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("���a����W��")]
        private string namePlayer = "�M�h";

        private Transform traPlayer;

        private void Awake()
        {
            //���a�����ܧ� = �C������.�M��(���a����W��).�ܧ�
            traPlayer = GameObject.Find(namePlayer).transform;

            /** //�{�Ѵ��� Lerp
            float result = Mathf.Lerp(0, 10, 0.5f);
            float result7 = Mathf.Lerp(0, 10, 0.7f);
            print("0�P10��0.5����" + result);
            print("0�P10��0.7����" + result7);
            */
        }

        private void Update()
        {
            MoveToPlayer();
        }

        ///<summary>
        ///���ؼЪ��a���󲾰�
        ///<summary>
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;
            Vector3 posPlayer = traPlayer.position;

            transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * data.speed * Time.deltaTime);

            //y �ھڼĤH�P���a x �y�нվ�
            //�ĤH x �j�󪱮a�AY 180 �_�h 0
            float y = transform.position.x > traPlayer.position.x ? 180 : 0;
            transform.eulerAngles = new Vector3(0, y, 0);
        }
    }

}


