using UnityEngine;
using System.Collections.Generic;

//by.J:230725 동물 축사
//by.J:230814 IItem 수정에 따른 작업
namespace JinnyAnimal
{
    //구조체 정의
    [System.Serializable]
    public struct AnimalDataInfo
    {
        public string animalName;      //이름
        public int animalCost;         //가격
        public Sprite animalImage;     //동물이미지
        public GameObject animalPrefab;//동물 프리팹
        public string animalItemId;   //아이템 고유 ID

    }

    //IItem 인터페이스 정의
    public class Animal : MonoBehaviour //, IItem
    {
        [SerializeField] public List<AnimalDataInfo> animalDataList = new List<AnimalDataInfo>();

        public string[] ItemName
        {
            get
            {
                string[] names = new string[animalDataList.Count];
                for (int i = 0; i < animalDataList.Count; i++)
                {
                    names[i] = animalDataList[i].animalName;
                }
                return names;
            }

        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[animalDataList.Count];
                for (int i = 0; i < animalDataList.Count; i++)
                {
                    costs[i] = animalDataList[i].animalCost;
                }
                return costs;
            }

        }

        public Sprite[] ItemImage
        {
            get
            {
                Sprite[] images = new Sprite[animalDataList.Count];
                for (int i = 0; i < animalDataList.Count; i++)
                {
                    images[i] = animalDataList[i].animalImage;
                }
                return images;
            }
        }

        public string[] ItemId
        {
            get
            {
                string[] names = new string[animalDataList.Count];
                for (int i = 0; i < animalDataList.Count; i++)
                {
                    names[i] = animalDataList[i].animalItemId;
                }
                return names;
            }
        }

        //시작시 초기화 기능 시작
        private void Start()
        {
            InitializeCropItems();
            Debug.Log("동물 리스트 크기 : " + animalDataList.Count);
        }

        //초기화 기능
        private void InitializeCropItems()
        {
            //이미지 추가
            Sprite[] sprites = Resources.LoadAll<Sprite>("Cage");
            Sprite ChickenCage = System.Array.Find(sprites, sprite => sprite.name.Equals("Cage_0"));
            Sprite CowCage = System.Array.Find(sprites, sprite => sprite.name.Equals("Cage_1"));
            Sprite PigCage = System.Array.Find(sprites, sprite => sprite.name.Equals("Cage_2"));


            //닭
            animalDataList.Add(new AnimalDataInfo()
            {
                animalName = "닭장",
                animalCost = 10,
                animalImage = ChickenCage
            });

            //소
            animalDataList.Add(new AnimalDataInfo()
            {
                animalName = "젖소 축사",
                animalCost = 10,
                animalImage = CowCage
            });

            //돼지
            animalDataList.Add(new AnimalDataInfo()
            {
                animalName = "돼지 축사",
                animalCost = 10,
                animalImage = PigCage
            });


        }
    }
}

