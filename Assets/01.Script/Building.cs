using UnityEngine;

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

        ////by.J:230719 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeBuildings();
        }

        //by.J:230719 �ʱ�ȭ ���
        private void InitializeBuildings()
        {
            // ����
            buildingDataArray[0].buildingName = "����";
            buildingDataArray[0].buildingCost = 10;
            buildingDataArray[0].buildingBuildTime = 5.0f;

            // ���̼� 
            buildingDataArray[1].buildingName = "���̼�";
            buildingDataArray[1].buildingCost = 10;
            buildingDataArray[1].buildingBuildTime = 5.0f;

            // ö�ǰ��� 
            buildingDataArray[2].buildingName = "ö�� ����";
            buildingDataArray[2].buildingCost = 10;
            buildingDataArray[2].buildingBuildTime = 5.0f;

            //����ǰ ������
            buildingDataArray[3].buildingName = "����ǰ ������";
            buildingDataArray[3].buildingCost = 10;
            buildingDataArray[3].buildingBuildTime = 5.0f;

            //�꽺����
            buildingDataArray[4].buildingName = "�꽺 ����";
            buildingDataArray[4].buildingCost = 10;
            buildingDataArray[4].buildingBuildTime = 5.0f;


        }
    }
}
