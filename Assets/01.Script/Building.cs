using UnityEngine;

//by.J:230719 건물 오브젝트 
namespace JinnyBuilding
{
    //by.J:230719 구조체 정의
    [System.Serializable]
    public struct BuildingDataInfo
    {
        public string buildingName;
        public int buildingCost;
        public float buildingBuildTime;
    }

    //by.J:230719 IBuilding 인터페이스 정의
    public class Building : MonoBehaviour, IBuilding
    {
        [SerializeField] private JinnyBuildingData.BuildingData[] buildingDataArray;

        public string[] BuildingName
        {
            get
            {
                string[] names = new string[buildingDataArray.Length];
                for (int i = 0; i < buildingDataArray.Length; i++)
                {
                    names[i] = buildingDataArray[i].buildingName;
                }
                return names;
            }
            private set
            {
                for (int i = 0; i < buildingDataArray.Length && i < value.Length; i++)
                {
                    buildingDataArray[i].buildingName = value[i];
                }
            }
        }

        public int[] Buildingcost
        {
            get
            {
                int[] costs = new int[buildingDataArray.Length];
                for (int i = 0; i < buildingDataArray.Length; i++)
                {
                    costs[i] = buildingDataArray[i].buildingCost;
                }
                return costs;
            }
            private set
            {
                for (int i = 0; i < buildingDataArray.Length && i < value.Length; i++)
                {
                    buildingDataArray[i].buildingCost = value[i];
                }
            }
        }

        public float[] BuildingBuildTime
        {
            get
            {
                float[] buildTimes = new float[buildingDataArray.Length];
                for (int i = 0; i < buildingDataArray.Length; i++)
                {
                    buildTimes[i] = buildingDataArray[i].buildingBuildTime;
                }
                return buildTimes;
            }
            private set
            {
                for (int i = 0; i < buildingDataArray.Length && i < value.Length; i++)
                {
                    buildingDataArray[i].buildingBuildTime = value[i];
                }
            }
        }

        ////by.J:230719 시작시 초기화 기능 시작
        private void Start()
        {
            InitializeBuildings();
        }

        //by.J:230719 초기화 기능
        private void InitializeBuildings()
        {
            // 빵집
            buildingDataArray[0].buildingName = "빵집";
            buildingDataArray[0].buildingCost = 10;
            buildingDataArray[0].buildingBuildTime = 5.0f;

            // 정미소 
            buildingDataArray[1].buildingName = "정미소";
            buildingDataArray[1].buildingCost = 10;
            buildingDataArray[1].buildingBuildTime = 5.0f;

            // 철판가게 
            buildingDataArray[2].buildingName = "철판 가게";
            buildingDataArray[2].buildingCost = 10;
            buildingDataArray[2].buildingBuildTime = 5.0f;

            //유제품 가공소
            buildingDataArray[3].buildingName = "유제품 가공소";
            buildingDataArray[3].buildingCost = 10;
            buildingDataArray[3].buildingBuildTime = 5.0f;

            //쥬스가게
            buildingDataArray[4].buildingName = "쥬스 가게";
            buildingDataArray[4].buildingCost = 10;
            buildingDataArray[4].buildingBuildTime = 5.0f;


        }
    }
}
