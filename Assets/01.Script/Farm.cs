using UnityEngine;
using System.Collections.Generic; //by.J:230721 List ����ȭ 

//by.J:230720 ����� ������Ʈ 
namespace JinnyFarm
{
    //by.J:230720 ����ü ����
    [System.Serializable]
    public struct FarmDataInfo
    {
        public string farmName;     //�̸�
        public int farmCost;        //����
        public int farmHaverst;     //�۹� ��Ȯ�� 
        public float farmGrowTime;  //�۹� ���� �ð�
    }

    //by.J:230720 IFarm �������̽� ����
    public class Farm : MonoBehaviour, IFarm
    {
        [SerializeField] public List<FarmDataInfo> farmDataList = new List<FarmDataInfo>();

        public string[] FarmName
        {
            get
            {
                string[] names = new string[farmDataList.Count];
                for (int i = 0; i < farmDataList.Count; i++)
                {
                    names[i] = farmDataList[i].farmName;
                }
                return names;
            }
            
        }

        public int[] FarmCost
        {
            get
            {
                int[] costs = new int[farmDataList.Count];
                for (int i = 0; i < farmDataList.Count; i++)
                {
                    costs[i] = farmDataList[i].farmCost;
                }
                return costs;
            }
        }

        public int[] FarmHaverst
        {
            get
            {
                int[] haversts = new int[farmDataList.Count];
                for (int i = 0; i <farmDataList.Count; i++)
                {
                    haversts[i] = farmDataList[i].farmHaverst;
                }
                return haversts;
            }
        }

        public float[] FarmGrowTime
        {
            get
            {
                float[] growTimes = new float[farmDataList.Count];
                for (int i = 0; i < farmDataList.Count; i++)
                {
                    growTimes[i] = farmDataList[i].farmGrowTime;
                }
                return growTimes;
            }
      
        }

        ////by.J:230720 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeBuildings();
        }

        //by.J:230720 �ʱ�ȭ ���
        private void InitializeBuildings()
        {
            // �й�
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "�й�",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

            // ��������
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "������",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

            // ���
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "���",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

            // �丶���
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "�丶���",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

            // ��ٹ�
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "��ٹ�",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

        }
    }
}

