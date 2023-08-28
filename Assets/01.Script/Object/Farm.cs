using UnityEngine;
using System.Collections.Generic;

//by.J:230720 ����� ������Ʈ 
//by.J:230721 List ����ȭ a
namespace JinnyFarm
{
    //Ÿ�� ����
    public enum FarmType
    {
        None,
        Farm
    }

    //����� ���� Ÿ�� ����
    public enum GrowthFarmType
    {
        Plant,  //����
        Growth, //�ڶ�
        Born    //ź��
    }

    //����ü ����
    [System.Serializable]
    public struct FarmDataInfo
    {
        public string farmName;     //�̸�
        public int farmCost;        //����
        public int farmHaverst;     //�۹� ��Ȯ�� 
        public float farmGrowTime;  //�۹� ���� �ð�
        public Sprite[] farmImage;  //����� �̹���
        public FarmType farmType;   //���� Ÿ��

        public GameObject farmPrefab;//����� ������
    }

    //IFarm �������̽� ����
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

        //���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeFarms();
            Debug.Log("����� ����Ʈ ũ�� : " + farmDataList.Count);
        }


        //�ʱ�ȭ ���
        private void InitializeFarms()
        {
            //�̹��� �߰�
            Sprite[] sprites = Resources.LoadAll<Sprite>("FarmCrop");

            Sprite[] wheat =
            {
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_3")), //��1
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_1")), //��2
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_2")), //��3
            };
            Sprite[] carrot =
            {
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_4")), //���1
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_5")), //���2
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_6")), //���3
            };
            Sprite[] bean =
            {
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_7")), //��1
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_8")), //��2
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_9")), //��3
            };
            Sprite[] tomato =
            {
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_14")), //�丶��1
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_11")), //�丶��2
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_12")), //�丶��3
            };
            Sprite[] corn =
            {
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_15")), //������1
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_16")), //������2
                System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_17")), //������3
            };

            //�й�
            farmDataList.Add(new FarmDataInfo()
            {
                farmType = FarmType.Farm,
                farmName = "�й�",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 5.0f,
                farmImage = wheat,
            });

            //��������
            farmDataList.Add(new FarmDataInfo()
            {
                farmType = FarmType.Farm,
                farmName = "��������",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 5.0f,
                farmImage = corn
            });

            //���
            farmDataList.Add(new FarmDataInfo()
            {
                farmType = FarmType.Farm,
                farmName = "���",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 5.0f,
                farmImage = bean
            });

            //�丶���
            farmDataList.Add(new FarmDataInfo()
            {
                farmType = FarmType.Farm,
                farmName = "�丶���",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 5.0f,
                farmImage = tomato
            });

            //��ٹ�
            farmDataList.Add(new FarmDataInfo()
            {
                farmType = FarmType.Farm,
                farmName = "��ٹ�",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 5.0f,
                farmImage = carrot
            });


        }
    }
}

