using UnityEngine;
using System.Collections.Generic; //by.J:230721 List ����ȭ

//by.J:230720 ����ǰ (�۹�/����) ������Ʈ 
namespace JinnyCropItem
{
    //by.J:230720 ����ü ����
    [System.Serializable]
    public struct CropItemDataInfo
    {
        public string cropItemName;   //�̸�
        public int cropItemCost;     //����
        public Sprite cropItemImage; //����ǰ �̹���
    }

    //by.J:230720 IItem �������̽� ����
    public class CropItem : MonoBehaviour, IItem
    {
        [SerializeField] public List<CropItemDataInfo> cropItemDataInfoList = new List<CropItemDataInfo>();

        public string[] ItemName
        {
            get
            {
                string[] names = new string[cropItemDataInfoList.Count];
                for (int i = 0; i < cropItemDataInfoList.Count; i++)
                {
                    names[i] = cropItemDataInfoList[i].cropItemName;
                }
                return names;
            }
            
        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[cropItemDataInfoList.Count];
                for (int i = 0; i < cropItemDataInfoList.Count; i++)
                {
                    costs[i] = cropItemDataInfoList[i].cropItemCost;
                }
                return costs;
            }
            
        }

        ////by.J:230720 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeCropItems();
            Debug.Log("���� ����ǰ ����Ʈ ũ�� : " + cropItemDataInfoList.Count);
        }

        //by.J:230720 �ʱ�ȭ ���
        private void InitializeCropItems()
        {
            //by.J:230728 �̹��� �߰� �۾�
            Sprite[] sprites = Resources.LoadAll<Sprite>("Item");
            Sprite milk = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_0"));
            Sprite egg = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_1"));
            Sprite pork = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_2"));
            Sprite wheat = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_3"));
            Sprite corn = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_4"));
            Sprite bean = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_5"));
            Sprite tomato = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_6"));
            Sprite carrot = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_7"));

            //����
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "����",
                cropItemCost = 10,
                cropItemImage = milk
            });

            //�ް�
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "�ް�",
                cropItemCost = 10,
                cropItemImage = egg
            });

            //�������
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "�������",
                cropItemCost = 10,
                cropItemImage = pork
            });


            //��
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "��",
                cropItemCost = 10,
                cropItemImage = wheat
            });

            //������
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "������",
                cropItemCost = 10,
                cropItemImage = corn
            });

            //��
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "��",
                cropItemCost = 10,
                cropItemImage = bean
            });

            //�丶��
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "�丶��",
                cropItemCost = 10,
                cropItemImage = tomato
            });

            //���
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "���",
                cropItemCost = 10,
                cropItemImage = carrot
            });
            
        }
    }
}
