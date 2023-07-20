using UnityEngine;

//by.J:230720 ����� ������Ʈ 
namespace JinnyFarm
{
    //by.J:230720 ����ü ����
    [System.Serializable]
    public struct FarmDataInfo
    {
        public string farmName;     
        public int farmCost;        
        public int farmHaverst;       
        public float farmGrowTime; 
    }

    //by.J:230720 IFarm �������̽� ����
    public class Farm : MonoBehaviour, IFarm
    {
        [SerializeField] private JinnyFarmData.FarmData[] farmDataArray;

        public string[] FarmName
        {
            get
            {
                string[] names = new string[farmDataArray.Length];
                for (int i = 0; i < farmDataArray.Length; i++)
                {
                    names[i] = farmDataArray[i].farmName;
                }
                return names;
            }
            private set
            {
                for (int i = 0; i < farmDataArray.Length && i < value.Length; i++)
                {
                    farmDataArray[i].farmName = value[i];
                }
            }
        }

        public int[] FarmCost
        {
            get
            {
                int[] costs = new int[farmDataArray.Length];
                for (int i = 0; i < farmDataArray.Length; i++)
                {
                    costs[i] = farmDataArray[i].farmCost;
                }
                return costs;
            }
            private set
            {
                for (int i = 0; i < farmDataArray.Length && i < value.Length; i++)
                {
                    farmDataArray[i].farmCost = value[i];
                }
            }
        }

        public int[] FarmHaverst
        {
            get
            {
                int[] crops = new int[farmDataArray.Length];
                for (int i = 0; i < farmDataArray.Length; i++)
                {
                    crops[i] = farmDataArray[i].farmHaverst;
                }
                return crops;
            }
            private set
            {
                for (int i = 0; i < farmDataArray.Length && i < value.Length; i++)
                {
                    farmDataArray[i].farmHaverst = value[i];
                }
            }
        }

        public float[] FarmGrowTime
        {
            get
            {
                float[] growTimes = new float[farmDataArray.Length];
                for (int i = 0; i < farmDataArray.Length; i++)
                {
                    growTimes[i] = farmDataArray[i].farmGrowTime;
                }
                return growTimes;
            }
            private set
            {
                for (int i = 0; i < farmDataArray.Length && i < value.Length; i++)
                {
                    farmDataArray[i].farmGrowTime = value[i];
                }
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
            farmDataArray[0].farmName = "�й�";
            farmDataArray[0].farmCost = 10;
            farmDataArray[0].farmHaverst = 5;
            farmDataArray[0].farmGrowTime = 1.0f;

            // ��������
            farmDataArray[1].farmName = "��������";
            farmDataArray[1].farmCost = 10;
            farmDataArray[1].farmHaverst = 5;
            farmDataArray[1].farmGrowTime = 1.0f;

            // ���
            farmDataArray[2].farmName = "���";
            farmDataArray[2].farmCost = 10;
            farmDataArray[2].farmHaverst = 5;
            farmDataArray[2].farmGrowTime = 1.0f;

            // �丶���
            farmDataArray[3].farmName = "�丶���";
            farmDataArray[3].farmCost = 10;
            farmDataArray[3].farmHaverst = 5;
            farmDataArray[3].farmGrowTime = 1.0f;

            // ��ٹ�
            farmDataArray[4].farmName = "��ٹ�";
            farmDataArray[4].farmCost = 10;
            farmDataArray[4].farmHaverst = 5;
            farmDataArray[4].farmGrowTime = 1.0f;

        }
    }
}

