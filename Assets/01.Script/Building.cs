using UnityEngine;
using System.Collections.Generic; //by.J:230720 List 변경화 

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
        [SerializeField] private List<BuildingDataInfo> buildingDataList = new List<BuildingDataInfo>();

        public string[] BuildingName
        {
            get
            {
                string[] names = new string[buildingDataList.Count];
                for (int i = 0; i < buildingDataList.Count; i++)
                {
                    names[i] = buildingDataList[i].buildingName;
                }
                return names;
            }
            //set
            //{
            //    for (int i = 0; i < buildingDataList.Count && i < value.Length; i++)
            //    {
            //        buildingDataList[i].buildingName = value[i];
            //    }
            //}
        }

        public int[] Buildingcost
        {
            get
            {
                int[] costs = new int[buildingDataList.Count];
                for (int i = 0; i < buildingDataList.Count; i++)
                {
                    costs[i] = buildingDataList[i].buildingCost;
                }
                return costs;
            }
            //set
            //{
            //    for (int i = 0; i < buildingDataList.Count && i < value.Length; i++)
            //    {
            //        buildingDataList[i].buildingCost = value[i];
            //    }
            //}
        }

        public float[] BuildingBuildTime
        {
            get
            {
                float[] buildTimes = new float[buildingDataList.Count];
                for (int i = 0; i < buildingDataList.Count; i++)
                {
                    buildTimes[i] = buildingDataList[i].buildingBuildTime;
                }
                return buildTimes;
            }
          //set
          //  {
          //      for (int i = 0; i < buildingDataList.Count && i < value.Length; i++)
          //      {
          //          buildingDataList[i].buildingBuildTime = value[i];
          //      }
          //  }
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
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "빵집",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

            // 정미소
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "정미소",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

            // 철판가게
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "철판 가게",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

            //유제품 가공소
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "유제품 가공소",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

            //쥬스가게
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "쥬스 가게",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

        }
    }
}
