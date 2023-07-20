using UnityEngine;

//by.J:230720 ����ǰ (�۹�/����) ������Ʈ 
namespace JinnyCropItem
{
    //by.J:230720 ����ü ����
    [System.Serializable]
    public struct CropItemDataInfo
    {
        public string itemName;   
        public int itemCost;
    }

    //by.J:230720 IItem �������̽� ����
    public class CropItem : MonoBehaviour, IItem
    {
        [SerializeField] private JinnyItemData.ItemData[] itemDataArray;

        public string[] ItemName
        {
            get
            {
                string[] names = new string[itemDataArray.Length];
                for (int i = 0; i < itemDataArray.Length; i++)
                {
                    names[i] = itemDataArray[i].itemName;
                }
                return names;
            }
            private set
            {
                for (int i = 0; i < itemDataArray.Length && i < value.Length; i++)
                {
                    itemDataArray[i].itemName = value[i];
                }
            }
        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[itemDataArray.Length];
                for (int i = 0; i < itemDataArray.Length; i++)
                {
                    costs[i] = itemDataArray[i].itemCost;
                }
                return costs;
            }
            private set
            {
                for (int i = 0; i < itemDataArray.Length && i < value.Length; i++)
                {
                    itemDataArray[i].itemCost = value[i];
                }
            }
        }


        ////by.J:230720 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeBuildings();
        }

        //by.J:230720 �ʱ�ȭ ���
        private void InitializeBuildings()
        {
            // ��
            itemDataArray[0].itemName = "��";
            itemDataArray[0].itemCost = 10;

            // ������
            itemDataArray[0].itemName = "������";
            itemDataArray[0].itemCost = 10;

            // ��
            itemDataArray[0].itemName = "��";
            itemDataArray[0].itemCost = 10;

            // �丶��
            itemDataArray[0].itemName = "�丶��";
            itemDataArray[0].itemCost = 10;

            // ���
            itemDataArray[0].itemName = "���";
            itemDataArray[0].itemCost = 10;

        }
    }
}
