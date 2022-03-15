using UnityEngine;

namespace KID
{
    //���O(�}��)���������P���W���ɦW�����ۦP�A�]�t�j�p�g�A���঳�Ů�ίS��r��
    //<summary>
    //�W�U�������ⱱ�
    //����ʡA�ʵe��s
    //</summary>
    public class TopDownController : MonoBehaviour
    {
        #region ���:�O�s�t�λݭn����ơA�p���ʳt�סA�ʵe�ѼƦW�ٵ�
        //���:�׹��� ������� ���W��(���w �w�]��);
        //[]�ݩ� Attrltube
        //SerializeField �ǦC�����-���i����
        //Header ���D
        //Range �d�� �ȾA�Ω�ƭȫ����
        [SerializeField,Header("���ʳt��"),Range(0,500)]
        private float speed = 1.5f;
        private string parameterRun = "�}��-�]�B";
        private string parameterDead = "�}��-���`";
        private Animator ani;
        private Rigidbody2D rig;

        #endregion

        #region �ƥ�:�{�����J�f(Unity)
        //����ƥ�:����C���ɷ|����@���A�B�z��l��
        private void Awake()
        {
            //GetComponnent<�x��>-�x��:����������
            //��� ���w ���o����<����W��>()-���o���w����s������
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }

        //��s�ƥ�:��60fps
        //���o��J��ƥi�b���ƥ�B�z
        private void Update()
        {
            GetIuput();
        }

        #endregion

        #region ��k:���������欰�A�p���ʥ\��A��s�ʵe

        //��k�y�k:�׹��� �Ǧ^������� ��k�W��(�Ѽ�)(�{�����e)
        private void GetIuput()
        {
            //�ϥ��R�A���
            //�y�k:���O�W��,�R�A��k�W��(��������)
            //Horizontal �����b�V
            //��:��V����PA-�Ǧ^-1
            //�k:��V�k��PD-�Ǧ^+1
            float h = Input.GetAxis("Horizontal");
            print("�����b�V��:" + h);
        }
        #endregion
    }
}

