using UnityEngine;
using System.Collections.Generic; //by.J:230721 List ����ȭ


//by.J:230720 ����ǰ ������Ʈ ��ũ���ͺ� / ����ǰ ���� ����
namespace JinnyItemData
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item")]

    public class ItemData : ScriptableObject
    {
        public List<ItemInfo> items;

        [System.Serializable]

        public struct ItemInfo
        {
            public string itemName;     //�̸�
            public int itemCost;        //����

        }
    }
}