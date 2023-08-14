using UnityEngine;
using System.Collections.Generic;

//by.J:230725 ����
//by.J:230814 IItem ������ ���� �۾�
namespace JinnyAnimal
{
    //����ü ����
    [System.Serializable]
    public struct AnimalDataInfo
    {
        public string animalName;      //�̸�
        public int animalCost;         //����
        public Sprite animalImage;     //�����̹���
        public GameObject animalPrefab;//���� ������
        public string animalItemId;   //������ ���� ID

    }

    //IItem �������̽� ����
    public class Animal : MonoBehaviour //, IItem
    {
        [SerializeField] public List<AnimalDataInfo> animalDataList = new List<AnimalDataInfo>();

        //public string[] ItemName
        //{
        //    get
        //    {
        //        string[] names = new string[animalDataList.Count];
        //        for (int i = 0; i < animalDataList.Count; i++)
        //        {
        //            names[i] = animalDataList[i].animalName;
        //        }
        //        return names;
        //    }

        //}

        //public int[] ItemCost
        //{
        //    get
        //    {
        //        int[] costs = new int[animalDataList.Count];
        //        for (int i = 0; i < animalDataList.Count; i++)
        //        {
        //            costs[i] = animalDataList[i].animalCost;
        //        }
        //        return costs;
        //    }

        //}

        //public Sprite[] ItemImage
        //{
        //    get
        //    {
        //        Sprite[] images = new Sprite[animalDataList.Count];
        //        for (int i = 0; i < animalDataList.Count; i++)
        //        {
        //            images[i] = animalDataList[i].animalImage;
        //        }
        //        return images;
        //    }
        //}

        //public string[] ItemId
        //{
        //    get
        //    {
        //        string[] names = new string[animalDataList.Count];
        //        for (int i = 0; i < animalDataList.Count; i++)
        //        {
        //            names[i] = animalDataList[i].animalItemId;
        //        }
        //        return names;
        //    }
        //}

        //���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeCropItems();
            Debug.Log("���� ����Ʈ ũ�� : " + animalDataList.Count);
        }

        //�ʱ�ȭ ���
        private void InitializeCropItems()
        {
            //��
            animalDataList.Add(new AnimalDataInfo()
            {
                animalName = "��",
                animalCost = 10
                //AnimalImage = buid_1_1
            });

            //��
            animalDataList.Add(new AnimalDataInfo()
            {
                animalName = "��",
                animalCost = 10
                //AnimalImage = buid_1_1
            });

            //����
            animalDataList.Add(new AnimalDataInfo()
            {
                animalName = "����",
                animalCost = 10
                //AnimalImage = buid_1_1
            });


        }
    }
}

