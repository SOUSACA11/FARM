using UnityEngine;

//by.J:230720 ����ǰ ������Ʈ ��ũ���ͺ� / ����ǰ ���� ����
namespace JinnyItemData
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item")]

    public class ItemData : ScriptableObject
    {
        public string itemName;     //�̸�
        public int itemCost;        //����

    }
}
