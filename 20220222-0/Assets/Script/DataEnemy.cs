using UnityEngine;

namespace KID
{

    ///<summary>
    ///�ĤH���
    ///1.���ʳt��
    ///2.�����O
    ///3.�����N�o
    ///4.��q
    ///5.�����g��Ⱦ��v
    ///6.�����g��Ȥj�p-�p���j(�ź��)
    ///<summary>
    [CreateAssetMenu(menuName = "KID/Data Enemy", fileName = "Data Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("���ʳt��"), Range(0, 3500)]
        public float speed = 30;
        [Header("�����O"), Range(0, 500)]
        public float attack = 10;
        [Header("�����N�o"), Range(0, 5)]
        public float cd = 3.5f;
        [Header("��q"), Range(0, 5000)]
        public float hp = 100;
        [Header("�����g��Ⱦ��v"), Range(0, 1)]
        public float expDroprobability = 100;
        [Header("�����g�������")]
        public TypeExp typeExp;
    }

    ///�g�������
    public enum TypeExp
    {
        small, middle, big
    }

}


