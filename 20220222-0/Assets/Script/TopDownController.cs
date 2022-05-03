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
        private float h;
        private float v;

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
            Move();
            Rotate();
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
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            //print("�����b�V��:" + h);
        }

        private void Move()
        {
            //�ϥΫD�R�A��� non-static
            //�y�k�G���W��.�D�R�A�ݩʦW��
            rig.velocity = new Vector2(h, v) * speed; //����.�[�t��=�G���V�q*�t��
            //����������0 �Ϊ� �����]������0
            ani.SetBool(parameterRun, h != 0 || v !=0); //�ʵe���.�]�w���L��(�Ѽ�.���L��)=h������0�A������b�V������s�A�NĲ�o�]�B�ʵe

        }


        private void Rotate()
        {
            //���k���� Y=0
            //�������� Y=180
            //�T���B��l
            //�y�k�G���L�� ? ���L�Ȭ�true�G���L�Ȭ�false
            // h>0 ? 0:180=�Y������ �j�󵥩� �s �Ȭ�0�A�_�h �Ȭ�180
            transform.eulerAngles = new Vector3(0, h >= 0 ? 0:180,0);
        }

        #endregion
    }
}

