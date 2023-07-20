using UnityEngine;

//by.J:230720 생산품 (가공품) 오브젝트 
namespace JinnyProcessItem
{
    //by.J:230720 구조체 정의
    [System.Serializable]
    public struct ProcessItemDataInfo
    {
        public string itemName;
        public int itemCost;
    }

    //by.J:230720 IItem 인터페이스 정의
    public class ProcessItem : MonoBehaviour, IItem
    {
        [SerializeField] private JinnyItemData.ItemData[] itemDataArray;

        public string[] ItemName
        {
            get
            {
                string[] names = new string[itemDataArray.Length];
                for (int i = 0; i < itemDataArray.Length; i++)
                {
                    names[i] = itemDataArray[i].itemName;
                }
                return names;
            }
            private set
            {
                for (int i = 0; i < itemDataArray.Length && i < value.Length; i++)
                {
                    itemDataArray[i].itemName = value[i];
                }
            }
        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[itemDataArray.Length];
                for (int i = 0; i < itemDataArray.Length; i++)
                {
                    costs[i] = itemDataArray[i].itemCost;
                }
                return costs;
            }
            private set
            {
                for (int i = 0; i < itemDataArray.Length && i < value.Length; i++)
                {
                    itemDataArray[i].itemCost = value[i];
                }
            }
        }


        ////by.J:230720 시작시 초기화 기능 시작
        private void Start()
        {
            InitializeBuildings();
        }

        //by.J:230720 초기화 기능
        private void InitializeBuildings()
        {
            // 식빵
            itemDataArray[0].itemName = "밀";
            itemDataArray[0].itemCost = 10;

            ////////

        }
    }
}

