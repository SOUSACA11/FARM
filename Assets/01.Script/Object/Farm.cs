using UnityEngine;
using System.Collections.Generic;

//by.J:230720 ≥Û¿ÂπÁ ø¿∫Í¡ß∆Æ 
//by.J:230721 List ∫Ø∞Ê»≠ 
namespace JinnyFarm
{
    //±∏¡∂√º ¡§¿«
    [System.Serializable]
    public struct FarmDataInfo
    {
        public string farmName;     //¿Ã∏ß
        public int farmCost;        //∞°∞›
        public int farmHaverst;     //¿€π∞ ºˆ»Æ∑Æ 
        public float farmGrowTime;  //¿€π∞ º∫¿Â Ω√∞£
        public Sprite farmImage;    //≥Û¿ÂπÁ ¿ÃπÃ¡ˆ

        public GameObject farmPrefab;//≥Û¿ÂπÁ «¡∏Æ∆’
    }

    //IFarm ¿Œ≈Õ∆‰¿ÃΩ∫ ¡§¿«
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

        //Ω√¿€Ω√ √ ±‚»≠ ±‚¥… Ω√¿€
        private void Start()
        {
            InitializeFarms();
            Debug.Log("≥Û¿ÂπÁ ∏ÆΩ∫∆Æ ≈©±‚ : " + farmDataList.Count);
        }

        //√ ±‚»≠ ±‚¥…
        private void InitializeFarms()
        {
            //π–πÁ
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "π–πÁ",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

            //ø¡ºˆºˆπÁ
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "ø¡ºˆπÁ",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

            //ƒ·πÁ
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "ƒ·πÁ",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

            //≈‰∏∂≈‰πÁ
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "≈‰∏∂≈‰πÁ",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });

            //¥Á±ŸπÁ
            farmDataList.Add(new FarmDataInfo()
            {
                farmName = "¥Á±ŸπÁ",
                farmCost = 10,
                farmHaverst = 3,
                farmGrowTime = 1.0f
            });


            //πÁ¿∫ «œ≥™∑Œ «œ∞Ì æææ—¿∏∑Œ ºˆ¡§ « ø‰
        }
    }
}

