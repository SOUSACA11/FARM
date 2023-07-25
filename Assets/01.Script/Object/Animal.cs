using UnityEngine;
using System.Collections.Generic; 

//by.J:230725 동물
namespace JinnyAnimal
{
    //by.J:230725 구조체 정의
    [System.Serializable]
    public struct AnimalDataInfo
    {
        public string AnimalName;   //이름
        public int AnimalCost;     //가격
        public Sprite AnimalImage; //생산품 이미지
    }

    //by.J:230725 IItem 인터페이스 정의
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

        ////by.J:230725 시작시 초기화 기능 시작
        private void Start()
        {
            InitializeCropItems();
            Debug.Log("동물 리스트 크기 : " + AnimalDataInfoList.Count);
        }

        //by.J:230725 초기화 기능
        private void InitializeCropItems()
        {
            //닭
            AnimalDataInfoList.Add(new AnimalDataInfo()
            {
                AnimalName = "닭",
                AnimalCost = 10
                //AnimalImage = buid_1_1
            });

            //소
            AnimalDataInfoList.Add(new AnimalDataInfo()
            {
                AnimalName = "소",
                AnimalCost = 10
                //AnimalImage = buid_1_1
            });

            //돼지
            AnimalDataInfoList.Add(new AnimalDataInfo()
            {
                AnimalName = "돼지",
                AnimalCost = 10
                //AnimalImage = buid_1_1
            });


        }
    }
}

