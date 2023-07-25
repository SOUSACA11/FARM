using UnityEngine;
using System.Collections.Generic; 

//by.J:230725 ����
namespace JinnyAnimal
{
    //by.J:230725 ����ü ����
    [System.Serializable]
    public struct AnimalDataInfo
    {
        public string AnimalName;   //�̸�
        public int AnimalCost;     //����
        public Sprite AnimalImage; //����ǰ �̹���
    }

    //by.J:230725 IItem �������̽� ����
    public class Animal : MonoBehaviour, IItem
    {
        [SerializeField] public List<AnimalDataInfo> AnimalDataInfoList = new List<AnimalDataInfo>();

        public string[] ItemName
        {
            get
            {
                string[] names = new string[AnimalDataInfoList.Count];
                for (int i = 0; i < AnimalDataInfoList.Count; i++)
                {
                    names[i] = AnimalDataInfoList[i].AnimalName;
                }
                return names;
            }

        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[AnimalDataInfoList.Count];
                for (int i = 0; i < AnimalDataInfoList.Count; i++)
                {
                    costs[i] = AnimalDataInfoList[i].AnimalCost;
                }
                return costs;
            }

        }

        ////by.J:230725 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeCropItems();
            Debug.Log("���� ����Ʈ ũ�� : " + AnimalDataInfoList.Count);
        }

        //by.J:230725 �ʱ�ȭ ���
        private void InitializeCropItems()
        {
            //��
            AnimalDataInfoList.Add(new AnimalDataInfo()
            {
                AnimalName = "��",
                AnimalCost = 10
                //AnimalImage = buid_1_1
            });

            //��
            AnimalDataInfoList.Add(new AnimalDataInfo()
            {
                AnimalName = "��",
                AnimalCost = 10
                //AnimalImage = buid_1_1
            });

            //����
            AnimalDataInfoList.Add(new AnimalDataInfo()
            {
                AnimalName = "����",
                AnimalCost = 10
                //AnimalImage = buid_1_1
            });


        }
    }
}

