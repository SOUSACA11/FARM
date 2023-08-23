using UnityEngine;
using System.Collections.Generic;

//by.J:230720 생산품 (가공품 / 동물) 오브젝트 
//by.J:230721 List 변경화
//by.J:230728 이미지 추가 작업
//by.J:230814 IItem 수정에 따른 작업
//by.J:230818 싱글톤 추가 (완성품 이미지 접근 위해)
namespace JinnyProcessItem
{
    //구조체 정의
    [System.Serializable]
    public struct ProcessItemDataInfo : IItem
    {
        public string processItemName; //이름
        public int processItemCost;    //가격
        public Sprite processItemImage;//생산품 이미지
        public string processItemId;   //아이템 고유 ID

        public string ItemName => processItemName;
        public int ItemCost => processItemCost;
        public Sprite ItemImage => processItemImage;
        public string ItemId => processItemId;
    }

    //IItem 인터페이스 정의
    public class ProcessItem : MonoBehaviour //, IItem
    {
        public static ProcessItem Instance; //싱글톤

        [SerializeField] public List<ProcessItemDataInfo> processItemDataInfoList = new List<ProcessItemDataInfo>();

        //public string[] ItemName
        //{
        //    get
        //    {
        //        string[] names = new string[processitemDataInfoList.Count];
        //        for (int i = 0; i < processitemDataInfoList.Count; i++)
        //        {
        //            names[i] = processitemDataInfoList[i].processItemName;
        //        }
        //        return names;
        //    }
        //}

        //public int[] ItemCost
        //{
        //    get
        //    {
        //        int[] costs = new int[processitemDataInfoList.Count];
        //        for (int i = 0; i < processitemDataInfoList.Count; i++)
        //        {
        //            costs[i] = processitemDataInfoList[i].processItemCost;
        //        }
        //        return costs;
        //    }
        //}

        //public Sprite[] ItemImage
        //{
        //    get
        //    {
        //        Sprite[] images = new Sprite[processitemDataInfoList.Count];
        //        for (int i = 0; i < processitemDataInfoList.Count; i++)
        //        {
        //            images[i] = processitemDataInfoList[i].processItemImage;
        //        }
        //        return images;
        //    }
        //}

        //public string[] ItemId
        //{
        //    get
        //    {
        //        string[] names = new string[processitemDataInfoList.Count];
        //        for (int i = 0; i < processitemDataInfoList.Count; i++)
        //        {
        //            names[i] = processitemDataInfoList[i].processItemId;
        //        }
        //        return names;
        //    }
        //}


        //시작시 초기화 기능 시작
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

            InitializeProcessItems();
            Debug.Log("가공 생산품 리스트 크기 : " + processItemDataInfoList.Count);
        }

        //초기화 기능
        private void InitializeProcessItems()
        {
            //이미지 추가
            Sprite[] sprites = Resources.LoadAll<Sprite>("Item");
            Sprite milk = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_0"));
            Sprite egg = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_1"));
            Sprite pork = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_2"));
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

            //우유
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "우유",
                processItemCost = 10,
                processItemImage = milk,
                processItemId = "animal_01"
            });

            //달걀
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "달걀",
                processItemCost = 10,
                processItemImage = egg,
                processItemId = "animal_02"
            });

            //돼지고기
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "돼지고기",
                processItemCost = 10,
                processItemImage = pork,
                processItemId = "animal_03"
            });


            //식빵
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "식빵",
                processItemCost = 10,
                processItemImage = bread,
                processItemId = "bread_01"
            });

            //바게트
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "바게트",
                processItemCost = 10,
                processItemImage = bagutte,
                processItemId = "bread_02"
            });

            //크루와상
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "크루와상",
                processItemCost = 10,
                processItemImage = croissant,
                processItemId = "bread_03"
            });

            //밀가루
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "밀가루",
                processItemCost = 10,
                processItemImage = flour,
                processItemId = "windmill_01"
            });

            //닭 사료
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "닭 사료",
                processItemCost = 10,
                processItemImage = chickenfeed,
                processItemId = "windmill_02"
            });

            //돼지 사료
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "돼지 사료",
                processItemCost = 10,
                processItemImage = pigfeed,
                processItemId = "windmill_03"
            });

            //소 사료
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "소 사료",
                processItemCost = 10,
                processItemImage = cowfeed,
                processItemId = "windmill_04"
            });

            //계란후라이
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "계란후라이",
                processItemCost = 10,
                processItemImage = eggflower,
                processItemId = "grill_01"
            });

            //베이컨
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "베이컨",
                processItemCost = 10,
                processItemImage = bacon,
                processItemId = "grill_02"
            });

            //토마토 쥬스
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "토마토 쥬스",
                processItemCost = 10,
                processItemImage = tomatojuice,
                processItemId = "juice_01"
            });

            //당근 쥬스
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "당근 쥬스",
                processItemCost = 10,
                processItemImage = carrotjuice,
                processItemId = "juice_02"
            });

            //버터
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "버터",
                processItemCost = 10,
                processItemImage = butter,
                processItemId = "dairy_01"
            });

            //치즈
            processItemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "치즈",
                processItemCost = 10,
                processItemImage = cheese,
                processItemId = "dairy_02"
            });
        }
    }
}

