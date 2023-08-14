using UnityEngine;
using System.Collections.Generic;

//by.J:230720 ����ǰ (�۹�/����) ������Ʈ
//by.J:230721 List ����ȭ
//by.J:230728 �̹��� �߰� �۾�
//by.J:230814 IItem ������ ���� �۾�
namespace JinnyCropItem
{
    //����ü ����
    [System.Serializable]
    public struct CropItemDataInfo
    {
        public string cropItemName;   //�̸�
        public int cropItemCost;      //����
        public Sprite cropItemImage;  //����ǰ �̹���
        public string cropItemId;             //������ ���� ID
    }

    //IItem �������̽� ����
    public class CropItem : MonoBehaviour //, IItem
    {
        [SerializeField] public List<CropItemDataInfo> cropItemDataInfoList = new List<CropItemDataInfo>();

        //public string[] ItemName
        //{
        //    get
        //    {
        //        string[] names = new string[cropItemDataInfoList.Count];
        //        for (int i = 0; i < cropItemDataInfoList.Count; i++)
        //        {
        //            names[i] = cropItemDataInfoList[i].cropItemName;
        //        }
        //        return names;
        //    }
            
        //}

        //public int[] ItemCost
        //{
        //    get
        //    {
        //        int[] costs = new int[cropItemDataInfoList.Count];
        //        for (int i = 0; i < cropItemDataInfoList.Count; i++)
        //        {
        //            costs[i] = cropItemDataInfoList[i].cropItemCost;
        //        }
        //        return costs;
        //    }
            
        //}

        //public Sprite[] ItemImage
        //{
        //    get
        //    {
        //        Sprite[] images = new Sprite[cropItemDataInfoList.Count];
        //        for (int i = 0; i < cropItemDataInfoList.Count; i++)
        //        {
        //            images[i] = cropItemDataInfoList[i].cropItemImage;
        //        }
        //        return images;
        //    }
        //}

        //public string[] ItemId
        //{
        //    get
        //    {
        //        string[] names = new string[cropItemDataInfoList.Count];
        //        for (int i = 0; i < cropItemDataInfoList.Count; i++)
        //        {
        //            names[i] = cropItemDataInfoList[i].cropItemId;
        //        }
        //        return names;
        //    }

        //}

        //���۽� �ʱ�ȭ ��� ����
        private void Awake()
        {
            InitializeCropItems();
            Debug.Log("���� ����ǰ ����Ʈ ũ�� : " + cropItemDataInfoList.Count);
        }

        //�ʱ�ȭ ���
        private void InitializeCropItems()
        {
            //�̹��� �߰�
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
                cropItemImage = milk,
                cropItemId = "animal_01"
            });

            //�ް�
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "�ް�",
                cropItemCost = 10,
                cropItemImage = egg,
                cropItemId = "animal_02"
            });

            //�������
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "�������",
                cropItemCost = 10,
                cropItemImage = pork,
                cropItemId = "animal_03"
            });


            //��
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "��",
                cropItemCost = 10,
                cropItemImage = wheat,
                cropItemId = "crop_01"
            });

            //������
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "������",
                cropItemCost = 10,
                cropItemImage = corn,
                cropItemId = "crop_02"
            });

            //��
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "��",
                cropItemCost = 10,
                cropItemImage = bean,
                cropItemId = "crop_03"
            });

            //�丶��
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "�丶��",
                cropItemCost = 10,
                cropItemImage = tomato,
                cropItemId = "crop_04"
            });

            //���
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "���",
                cropItemCost = 10,
                cropItemImage = carrot,
                cropItemId = "crop_05"
            });
            
        }
    }
}
