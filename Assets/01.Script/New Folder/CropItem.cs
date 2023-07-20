using UnityEngine;

//by.J:230720 생산품 (작물/동물) 오브젝트 
namespace JinnyCropItem
{
    //by.J:230720 구조체 정의
    [System.Serializable]
    public struct CropItemDataInfo
    {
        public string itemName;   
        public int itemCost;
    }

    //by.J:230720 IItem 인터페이스 정의
    public class CropItem : MonoBehaviour, IItem
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
            // 밀
            itemDataArray[0].itemName = "밀";
            itemDataArray[0].itemCost = 10;

            // 옥수수
            itemDataArray[0].itemName = "옥수수";
            itemDataArray[0].itemCost = 10;

            // 콩
            itemDataArray[0].itemName = "콩";
            itemDataArray[0].itemCost = 10;

            // 토마토
            itemDataArray[0].itemName = "토마토";
            itemDataArray[0].itemCost = 10;

            // 당근
            itemDataArray[0].itemName = "당근";
            itemDataArray[0].itemCost = 10;

        }
    }
}
