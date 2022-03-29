using UnityEngine;

namespace KID
{
    ///<summary>
    ///�Z���t��
    ///1.�x�s���a�֦����Z�����
    ///2.�ھڪZ����ƥͦ��Z��
    ///3.�ᤩ�Z���������
    ///</summary>
    
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("�Z�����")]
        private DataWeapon dataWeapon;

        ///<snmmary>
        ///�p�ɾ�
        ///</snmmary>

        private float timer;


        /// <summary>
        /// ø�s�ϥ�
        /// �@��:�b�s�边��ø�s�ϧλ��U�}�o
        /// ���|�b�����ɤ��X�{
        /// </summary>
        private void OnDrawGizmos()
        {
            //�ϥ��C��
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //ø�s�ϥ�
            //transform.position + dataWeapon.v2SpawnPoint[0] ����y��+�ͦ���m
            //�ت�:�ͦ���m�ھڨ����m������

            //for�j��
            //(��l��;����;�C�@���j�鵲������϶�)
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
        ///�ͦ��Z��
        ///�C�j�Z�����j�ɶ��N�b�ͦ���m�W�ͦ��Z��
        ///</summary>

        private void SpawnWeapon()
        {
            
            print("�g�L�ɶ�:" + timer);

            //�p�G�p�ɾ��j�󵥩󶡹j�ɶ�
            if (timer >= dataWeapon.interval)
            {
                //�ͦ�����
                Instantiate(dataWeapon.goWeapon);
                //�p�ɾ��k�s
                timer = 0;

            }
            else //�_�h
            {
                //�p�ɾ��֥[�@�Ӽv�檺�ɶ�
                timer += Time.deltaTime;
            }

        }

    }
}
