using UnityEngine;
using System.Collections.Generic; //by.J:230721 List ����ȭ

//by.J:230720 ����ǰ (����ǰ) ������Ʈ 
namespace JinnyProcessItem
{
    //by.J:230720 ����ü ����
    [System.Serializable]
    public struct ProcessItemDataInfo
    {
        public string processItemName; //�̸�
        public int processItemCost;    //����
        public Sprite processItemImage;//����ǰ �̹���
    }

    //by.J:230720 IItem �������̽� ����
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

        ////by.J:230720 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeProcessItems();
            Debug.Log("���� ����ǰ ����Ʈ ũ�� : " + processitemDataInfoList.Count);
        }

        //by.J:230720 �ʱ�ȭ ���
        private void InitializeProcessItems()
        {
            //by.J:230728 �̹��� �߰� �۾�
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
                processItemImage = bread
            });

            //�ٰ�Ʈ
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�ٰ�Ʈ",
                processItemCost = 10,
                processItemImage = bagutte
            });

            //ũ��ͻ�
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "ũ��ͻ�",
                processItemCost = 10,
                processItemImage = croissant
            });

            //�а���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�а���",
                processItemCost = 10,
                processItemImage = flour
            });

            //�� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�� ���",
                processItemCost = 10,
                processItemImage = chickenfeed
            });

            //���� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "���� ���",
                processItemCost = 10,
                processItemImage = pigfeed
            });

            //�� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�� ���",
                processItemCost = 10,
                processItemImage = cowfeed
            });

            //����Ķ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�Զ��Ķ���",
                processItemCost = 10,
                processItemImage = eggflower
            });

            //������
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "������",
                processItemCost = 10,
                processItemImage = bacon
            });

            //�丶�� �꽺
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�丶�� �꽺",
                processItemCost = 10,
                processItemImage = tomatojuice
            });

            //��� �꽺
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "��� �꽺",
                processItemCost = 10,
                processItemImage = carrotjuice
            });

            //����
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "����",
                processItemCost = 10,
                processItemImage = butter
            });

            //ġ��
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "ġ��",
                processItemCost = 10,
                processItemImage = cheese
            });
        }
    }
}

