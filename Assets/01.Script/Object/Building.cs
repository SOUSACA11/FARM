using UnityEngine;
using System.Collections.Generic; //by.J:230720 List ����ȭ 

//by.J:230719 �ǹ� ������Ʈ 
namespace JinnyBuilding
{
    //by.J:230719 ����ü ����
    [System.Serializable]
    public struct BuildingDataInfo
    {
        public string buildingName;     //�̸�
        public int buildingCost;        //����
        public float buildingBuildTime; //���� �ð�
        public Sprite buildingImage;    //�ǹ� �̹���

        public GameObject buildingPrefab;    //�ǹ� ������

    }

    //by.J:230719 IBuilding �������̽� ����
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

        ////by.J:230719 ���۽� �ʱ�ȭ ��� ����
        private void Start()  //�����ϰ��� �ѹ� ����
        {
            InitializeBuildings();
            Debug.Log("���� ����Ʈ ũ�� : " + buildingDataList.Count);

        }

        //by.J:230719 �ʱ�ȭ ���
        private void InitializeBuildings()
        {
            //by.J:230724 �̹��� �߰� �۾�
            Sprite[] sprites = Resources.LoadAll<Sprite>("Buid_1");
            Sprite buid_1_1 = System.Array.Find(sprites, sprite => sprite.name.Equals("Buid_1_1"));
            Sprite buid_1_2 = System.Array.Find(sprites, sprite => sprite.name.Equals("Buid_1_2"));
            Sprite buid_1_3 = System.Array.Find(sprites, sprite => sprite.name.Equals("Buid_1_3"));

            // ����
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "����",
                buildingCost = 10,
                buildingBuildTime = 5.0f,
                buildingImage = buid_1_1
            });

            // ���
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "���",
                buildingCost = 10,
                buildingBuildTime = 5.0f,
                buildingImage = buid_1_2
            });

            //// ���̼�
            //buildingDataList.Add(new BuildingDataInfo()
            //{
            //    buildingName = "���̼�",
            //    buildingCost = 10,
            //    buildingBuildTime = 5.0f
            //});

            // ö�ǰ���
            buildingDataList.Add(new BuildingDataInfo()
            {
                buildingName = "ö�� ����",
                buildingCost = 10,
                buildingBuildTime = 5.0f,
                buildingImage = buid_1_3
            });

            ////����ǰ ������
            //buildingDataList.Add(new BuildingDataInfo()
            //{
            //    buildingName = "����ǰ ������",
            //    buildingCost = 10,
            //    buildingBuildTime = 5.0f
            //});

            ////�꽺����
            //buildingDataList.Add(new BuildingDataInfo()
            //{
            //    buildingName = "�꽺 ����",
            //    buildingCost = 10,
            //    buildingBuildTime = 5.0f
            //});

            
        }

        private void Update()
        {
            //Debug.Log("���� ����Ʈ ũ�� : " + buildingDataList.Count);


                //foreach (var building in buildingDataList)
                //{
                //    if (building.buildingName == "����")
                //    {
                //        Debug.Log("���� �ǹ��� �̹��� �̸� : " + building.buildingImage.name);
                //    }
                //}
            
        }
    }
}
