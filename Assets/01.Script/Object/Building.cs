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

        public GameObject buildingPrefab;    //건물 프리팹

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
            Debug.Log("빌딩 리스트 크기 : " + buildingDataList.Count);

        }

        //by.J:230719 초기화 기능
        private void InitializeBuildings()
        {
            //by.J:230724 이미지 추가 작업
            Sprite[] sprites = Resources.LoadAll<Sprite>("Buid_1");
            Sprite buid_1_1 = System.Array.Find(sprites, sprite => sprite.name.Equals("Buid_1_1"));
            Sprite buid_1_2 = System.Array.Find(sprites, sprite => sprite.name.Equals("Buid_1_2"));
            Sprite buid_1_3 = System.Array.Find(sprites, sprite => sprite.name.Equals("Buid_1_3"));

            // 빵집
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "빵집",
                buildingCost = 10,
                buildingBuildTime = 5.0f,
                buildingImage = buid_1_1
            });

            // 축사
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "축사",
                buildingCost = 10,
                buildingBuildTime = 5.0f,
                buildingImage = buid_1_2
            });

            //// 정미소
            //buildingDataList.Add(new BuildingDataInfo()
            //{
            //    buildingName = "정미소",
            //    buildingCost = 10,
            //    buildingBuildTime = 5.0f
            //});

            // 철판가게
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "철판 가게",
                buildingCost = 10,
                buildingBuildTime = 5.0f,
                buildingImage = buid_1_3
            });

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
            //Debug.Log("빌딩 리스트 크기 : " + buildingDataList.Count);


                //foreach (var building in buildingDataList)
                //{
                //    if (building.buildingName == "빵집")
                //    {
                //        Debug.Log("빵집 건물의 이미지 이름 : " + building.buildingImage.name);
                //    }
                //}
            
        }
    }
}
