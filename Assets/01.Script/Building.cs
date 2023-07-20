using UnityEngine;
using System.Collections.Generic; //by.J:230720 List ����ȭ 

//by.J:230719 �ǹ� ������Ʈ 
namespace JinnyBuilding
{
    //by.J:230719 ����ü ����
    [System.Serializable]
    public struct BuildingDataInfo
    {
        public string buildingName;
        public int buildingCost;
        public float buildingBuildTime;
    }

    //by.J:230719 IBuilding �������̽� ����
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

        ////by.J:230719 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeBuildings();
        }

        //by.J:230719 �ʱ�ȭ ���
        private void InitializeBuildings()
        {
            // ����
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "����",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

            // ���̼�
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "���̼�",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

            // ö�ǰ���
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "ö�� ����",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

            //����ǰ ������
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "����ǰ ������",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

            //�꽺����
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "�꽺 ����",
                buildingCost = 10,
                buildingBuildTime = 5.0f
            });

        }
    }
}
