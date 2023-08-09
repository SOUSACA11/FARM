using UnityEngine;
using System.Collections.Generic; 

//by.J:230725 동물
namespace JinnyAnimal
{
    //by.J:230725 구조체 정의
    [System.Serializable]
    public struct AnimalDataInfo
    {
        public string animalName;   //이름
        public int animalCost;     //가격
        public Sprite animalImage; //동물이미지
    }

    //by.J:230725 IItem 인터페이스 정의
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

        //by.J:230725 시작시 초기화 기능 시작
        private void Start()
        {
            InitializeCropItems();
            Debug.Log("동물 리스트 크기 : " + animalDataInfoList.Count);
        }

        //by.J:230725 초기화 기능
        private void InitializeCropItems()
        {
            //닭
            animalDataInfoList.Add(new AnimalDataInfo()
            {
                animalName = "닭",
                animalCost = 10
                //AnimalImage = buid_1_1
            });

            //소
            animalDataInfoList.Add(new AnimalDataInfo()
            {
                animalName = "소",
                animalCost = 10
                //AnimalImage = buid_1_1
            });

            //돼지
            animalDataInfoList.Add(new AnimalDataInfo()
            {
                animalName = "돼지",
                animalCost = 10
                //AnimalImage = buid_1_1
            });


        }
    }
}

