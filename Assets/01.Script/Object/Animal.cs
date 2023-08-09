using UnityEngine;
using System.Collections.Generic; 

//by.J:230725 ����
namespace JinnyAnimal
{
    //by.J:230725 ����ü ����
    [System.Serializable]
    public struct AnimalDataInfo
    {
        public string animalName;   //�̸�
        public int animalCost;     //����
        public Sprite animalImage; //�����̹���
    }

    //by.J:230725 IItem �������̽� ����
    public class Animal : MonoBehaviour, IItem
    {
        [SerializeField] public List<AnimalDataInfo> animalDataInfoList = new List<AnimalDataInfo>();

        public string[] ItemName
        {
            get
            {
                string[] names = new string[animalDataInfoList.Count];
                for (int i = 0; i < animalDataInfoList.Count; i++)
                {
                    names[i] = animalDataInfoList[i].animalName;
                }
                return names;
            }

        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[animalDataInfoList.Count];
                for (int i = 0; i < animalDataInfoList.Count; i++)
                {
                    costs[i] = animalDataInfoList[i].animalCost;
                }
                return costs;
            }

        }

        public Sprite[] ItemImage
        {
            get
            {
                Sprite[] images = new Sprite[animalDataInfoList.Count];
                for (int i = 0; i < animalDataInfoList.Count; i++)
                {
                    images[i] = animalDataInfoList[i].animalImage;
                }
                return images;
            }
        }

        //by.J:230725 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeCropItems();
            Debug.Log("���� ����Ʈ ũ�� : " + animalDataInfoList.Count);
        }

        //by.J:230725 �ʱ�ȭ ���
        private void InitializeCropItems()
        {
            //��
            animalDataInfoList.Add(new AnimalDataInfo()
            {
                animalName = "��",
                animalCost = 10
                //AnimalImage = buid_1_1
            });

            //��
            animalDataInfoList.Add(new AnimalDataInfo()
            {
                animalName = "��",
                animalCost = 10
                //AnimalImage = buid_1_1
            });

            //����
            animalDataInfoList.Add(new AnimalDataInfo()
            {
                animalName = "����",
                animalCost = 10
                //AnimalImage = buid_1_1
            });


        }
    }
}

