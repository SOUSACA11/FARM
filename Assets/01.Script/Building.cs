using UnityEngine;
using System.Collections.Generic; //by.J:230720 List 변경화 

//by.J:230719 건물 오브젝트 
namespace JinnyBuilding
{
    //by.J:230719 구조체 정의
    [System.Serializable]
    public struct BuildingDataInfo
    {
        public string buildingName;     //이름
        public int buildingCost;        //가격
        public float buildingBuildTime; //건축 시간
        public Sprite buildingImage;    //건물 이미지
    }

    //by.J:230719 IBuilding 인터페이스 정의
    public class Building : MonoBehaviour, IBuilding
    {
        [SerializeField] public List<BuildingDataInfo> buildingDataList = new List<BuildingDataInfo>();

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
          
        }

        ////by.J:230719 시작시 초기화 기능 시작
        private void Start()  //시작하고나서 한번 실행
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
                buildingBuildTime = 5.0f,
                buildingImage = Resources.Load<Sprite>("Images/Build_1_1")
        });

            //// 정미소
            //buildingDataList.Add(new BuildingDataInfo()
            //{
            //    buildingName = "정미소",
            //    buildingCost = 10,
            //    buildingBuildTime = 5.0f
            //});

            //// 철판가게
            //buildingDataList.Add(new BuildingDataInfo()
            //{
            //    buildingName = "철판 가게",
            //    buildingCost = 10,
            //    buildingBuildTime = 5.0f
            //});

            ////유제품 가공소
            //buildingDataList.Add(new BuildingDataInfo()
            //{
            //    buildingName = "유제품 가공소",
            //    buildingCost = 10,
            //    buildingBuildTime = 5.0f
            //});

            ////쥬스가게
            //buildingDataList.Add(new BuildingDataInfo()
            //{
            //    buildingName = "쥬스 가게",
            //    buildingCost = 10,
            //    buildingBuildTime = 5.0f
            //});


        }

        private void Update()
        {
            Debug.Log(buildingDataList.Count);
        }
    }
}
