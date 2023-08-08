using UnityEngine;
using System.Collections.Generic; //by.J:230721 List 변경화

//by.J:230720 생산품 (가공품) 오브젝트 
namespace JinnyProcessItem
{
    //by.J:230720 구조체 정의
    [System.Serializable]
    public struct ProcessItemDataInfo
    {
        public string processItemName; //이름
        public int processItemCost;    //가격
        public Sprite processItemImage;//생산품 이미지
    }

    //by.J:230720 IItem 인터페이스 정의
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

        ////by.J:230720 시작시 초기화 기능 시작
        private void Start()
        {
            InitializeProcessItems();
            Debug.Log("가공 생산품 리스트 크기 : " + processitemDataInfoList.Count);
        }

        //by.J:230720 초기화 기능
        private void InitializeProcessItems()
        {
            //by.J:230728 이미지 추가 작업
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

            //식빵
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "식빵",
                processItemCost = 10,
                processItemImage = bread
            });

            //바게트
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "바게트",
                processItemCost = 10,
                processItemImage = bagutte
            });

            //크루와상
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "크루와상",
                processItemCost = 10,
                processItemImage = croissant
            });

            //밀가루
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "밀가루",
                processItemCost = 10,
                processItemImage = flour
            });

            //닭 사료
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "닭 사료",
                processItemCost = 10,
                processItemImage = chickenfeed
            });

            //돼지 사료
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "돼지 사료",
                processItemCost = 10,
                processItemImage = pigfeed
            });

            //소 사료
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "소 사료",
                processItemCost = 10,
                processItemImage = cowfeed
            });

            //계란후라이
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "게란후라이",
                processItemCost = 10,
                processItemImage = eggflower
            });

            //베이컨
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "베이컨",
                processItemCost = 10,
                processItemImage = bacon
            });

            //토마토 쥬스
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "토마토 쥬스",
                processItemCost = 10,
                processItemImage = tomatojuice
            });

            //당근 쥬스
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "당근 쥬스",
                processItemCost = 10,
                processItemImage = carrotjuice
            });

            //버터
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "버터",
                processItemCost = 10,
                processItemImage = butter
            });

            //치즈
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "치즈",
                processItemCost = 10,
                processItemImage = cheese
            });
        }
    }
}

