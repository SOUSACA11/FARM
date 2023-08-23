using UnityEngine;
using System.Collections.Generic;

//by.J:230720 농장밭 오브젝트 
//by.J:230721 List 변경화 
namespace JinnyFarm
{
    //구조체 정의
    [System.Serializable]
    public struct FarmDataInfo
    {
        public string farmName;     //이름
        public int farmCost;        //가격
        public int farmHaverst;     //작물 수확량 
        public float farmGrowTime;  //작물 성장 시간
        public Sprite farmImage;    //농장밭 이미지

        public GameObject farmPrefab;//농장밭 프리팹
    }

    //IFarm 인터페이스 정의
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

        //시작시 초기화 기능 시작
        private void Start()
        {
            InitializeFarms();
            Debug.Log("농장밭 리스트 크기 : " + farmDataList.Count);
        }

        //초기화 기능
        private void InitializeFarms()
        {
            //이미지 추가
            Sprite[] sprites = Resources.LoadAll<Sprite>("FarmCrop");
            Sprite wheat = System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_0")); //밀
            Sprite carrot = System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_3")); //당근
            Sprite bean = System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_6")); //콩
            Sprite tomato = System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_13")); //토마토
            Sprite corn = System.Array.Find(sprites, sprite => sprite.name.Equals("FarmCrop_14")); //옥수수


            //밀밭
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "밀밭",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f,
                farmImage = wheat
            });

            //옥수수밭
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "옥수수밭",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f,
                farmImage = corn
            });

            //콩밭
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "콩밭",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f,
                farmImage = bean
            });

            //토마토밭
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "토마토밭",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f,
                farmImage = tomato
            });

            //당근밭
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "당근밭",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f,
                farmImage = carrot
            });


        }
    }
}

