using UnityEngine;
using System.Collections.Generic;

//by.J:230720 ����ǰ (����ǰ) ������Ʈ 
//by.J:230721 List ����ȭ
//by.J:230728 �̹��� �߰� �۾�
namespace JinnyProcessItem
{
    //����ü ����
    [System.Serializable]
    public struct ProcessItemDataInfo
    {
        public string processItemName; //�̸�
        public int processItemCost;    //����
        public Sprite processItemImage;//����ǰ �̹���
        public string processItemId;              //������ ���� ID


        public string ItemId => processItemId;
        public Sprite ItemImage => processItemImage;
        public int ItemCost => processItemCost;
    }

    //IItem �������̽� ����
    public class ProcessItem : MonoBehaviour, IItem
    {
        [SerializeField] public List<ProcessItemDataInfo> processitemDataInfoList = new List<ProcessItemDataInfo>();

        public string[] ItemName
        {
            get
            {
                string[] names = new string[processitemDataInfoList.Count];
                for (int i = 0; i < processitemDataInfoList.Count; i++)
                {
                    names[i] = processitemDataInfoList[i].processItemName;
                }
                return names;
            }
        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[processitemDataInfoList.Count];
                for (int i = 0; i < processitemDataInfoList.Count; i++)
                {
                    costs[i] = processitemDataInfoList[i].processItemCost;
                }
                return costs;
            }
        }

        public Sprite[] ItemImage
        {
            get
            {
                Sprite[] images = new Sprite[processitemDataInfoList.Count];
                for (int i = 0; i < processitemDataInfoList.Count; i++)
                {
                    images[i] = processitemDataInfoList[i].processItemImage;
                }
                return images;
            }
        }

        public string[] ItemId
        {
            get
            {
                string[] names = new string[processitemDataInfoList.Count];
                for (int i = 0; i < processitemDataInfoList.Count; i++)
                {
                    names[i] = processitemDataInfoList[i].processItemId;
                }
                return names;
            }
        }


        //���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeProcessItems();
            Debug.Log("���� ����ǰ ����Ʈ ũ�� : " + processitemDataInfoList.Count);
        }

        //�ʱ�ȭ ���
        private void InitializeProcessItems()
        {
            //�̹��� �߰�
            Sprite[] sprites = Resources.LoadAll<Sprite>("Item");
            Sprite bread = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_8"));
            Sprite bagutte = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_9"));
            Sprite croissant = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_10"));
            Sprite flour = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_11"));
            Sprite chickenfeed = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_12"));
            Sprite pigfeed = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_13"));
            Sprite cowfeed = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_14"));
            Sprite eggflower = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_15"));
            Sprite bacon = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_16"));
            Sprite tomatojuice = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_17"));
            Sprite carrotjuice = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_18"));
            Sprite butter = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_19"));
            Sprite cheese = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_20"));

            //�Ļ�
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�Ļ�",
                processItemCost = 10,
                processItemImage = bread,
                processItemId = "bread_01"
            });

            //�ٰ�Ʈ
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�ٰ�Ʈ",
                processItemCost = 10,
                processItemImage = bagutte,
                processItemId = "bread_02"
            });

            //ũ��ͻ�
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "ũ��ͻ�",
                processItemCost = 10,
                processItemImage = croissant,
                processItemId = "bread_03"
            });

            //�а���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�а���",
                processItemCost = 10,
                processItemImage = flour,
                processItemId = "windmill_01"
            });

            //�� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�� ���",
                processItemCost = 10,
                processItemImage = chickenfeed,
                processItemId = "windmill_02"
            });

            //���� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "���� ���",
                processItemCost = 10,
                processItemImage = pigfeed,
                processItemId = "windmill_03"
            });

            //�� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�� ���",
                processItemCost = 10,
                processItemImage = cowfeed,
                processItemId = "windmill_04"
            });

            //����Ķ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�Զ��Ķ���",
                processItemCost = 10,
                processItemImage = eggflower,
                processItemId = "grill_01"
            });

            //������
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "������",
                processItemCost = 10,
                processItemImage = bacon,
                processItemId = "grill_02"
            });

            //�丶�� �꽺
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�丶�� �꽺",
                processItemCost = 10,
                processItemImage = tomatojuice,
                processItemId = "juice_01"
            });

            //��� �꽺
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "��� �꽺",
                processItemCost = 10,
                processItemImage = carrotjuice,
                processItemId = "juice_02"
            });

            //����
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "����",
                processItemCost = 10,
                processItemImage = butter,
                processItemId = "dairy_01"
            });

            //ġ��
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "ġ��",
                processItemCost = 10,
                processItemImage = cheese,
                processItemId = "dairy_02"
            });
        }
    }
}

