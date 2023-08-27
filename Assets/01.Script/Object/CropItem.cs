using UnityEngine;
using System.Collections.Generic;

//by.J:230720 ����ǰ (�۹�) ������Ʈ
//by.J:230721 List ����ȭ
//by.J:230728 �̹��� �߰� �۾�
//by.J:230814 IItem ������ ���� �۾�
//by.J:230818 �̱��� �߰� (�ϼ�ǰ �̹��� ���� ����)
namespace JinnyCropItem
{
    //����ü ����
    [System.Serializable]
    public struct CropItemDataInfo : IItem
    {
        public string cropItemName;   //�̸�
        public int cropItemCost;      //����
        public Sprite cropItemImage;  //����ǰ �̹���
        public string cropItemId;     //������ ���� ID

        public string ItemName => cropItemName;
        public int ItemCost => cropItemCost;
        public Sprite ItemImage => cropItemImage;
        public string ItemId => cropItemId;

    }

    //IItem �������̽� ����
    public class CropItem : MonoBehaviour //, IItem
    {
        public static CropItem Instance; //�̱���

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
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            InitializeCropItems();

            Debug.Log("���� ����ǰ ����Ʈ ũ�� : " + cropItemDataInfoList.Count);



            foreach (var item in cropItemDataInfoList)
            {
                //Debug.Log("Item Name: " + item.cropItemName + ", Image: " + item.cropItemImage);
                //Debug.Log("Item ID: " + item.cropItemId);
            }

            Sprite[] sprites = Resources.LoadAll<Sprite>("Item");
            Debug.Log("Loaded " + sprites.Length + " sprites from 'Item' folder.");
            foreach (Sprite sprite in sprites)
            {
                //Debug.Log("Loaded sprite name: " + sprite.name);
            }
        }

        //�ʱ�ȭ ���
        private void InitializeCropItems()
        {
            //�̹��� �߰�
            Sprite[] sprites = Resources.LoadAll<Sprite>("Item");
            Sprite wheat = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_3"));
            Sprite corn = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_4"));
            Sprite bean = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_5"));
            Sprite tomato = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_6"));
            Sprite carrot = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_7"));


            
            if (wheat != null)
            {
                Debug.Log("Found the 'Item_3' sprite.");
            }
            else
            {
                Debug.LogError("Failed to find the 'Item_3' sprite.");
            }

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
