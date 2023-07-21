using UnityEngine;
using System.Collections.Generic; //by.J:230721 List 변경화

//by.J:230720 생산품 (가공품) 오브젝트 
namespace JinnyProcessItem
{
    //by.J:230720 구조체 정의
    [System.Serializable]
    public struct ProcessItemDataInfo
    {
        public string processItemName; //이름
        public int processItemCost;    //가격
    }

    //by.J:230720 IItem 인터페이스 정의
    public class ProcessItem : MonoBehaviour, IItem
    {
        [SerializeField] private List<ProcessItemDataInfo> processitemDataInfoList = new List<ProcessItemDataInfo>();

        public string[] ItemName
        {
            get
            {
                string[] names = new string[processitemDataInfoList.Count];
                for (int i = 0; i < processitemDataInfoList.Count; i++)
                {
                    names[i] = processitemDataInfoList[i].processItemName;
                }
                return names;
            }
        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[processitemDataInfoList.Count];
                for (int i = 0; i < processitemDataInfoList.Count; i++)
                {
                    costs[i] = processitemDataInfoList[i].processItemCost;
                }
                return costs;
            }
        }


        ////by.J:230720 시작시 초기화 기능 시작
        private void Start()
        {
            InitializeBuildings();
        }

        //by.J:230720 초기화 기능
        private void InitializeBuildings()
        {
            //식빵
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "식빵",
                processItemCost = 10
            });

            //바게트
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "바게트",
                processItemCost = 10
            });

            //크루와상
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "크루와상",
                processItemCost = 10
            });

            //밀가루
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "밀가루",
                processItemCost = 10
            });

            //닭 사료
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "닭 사료",
                processItemCost = 10
            });

            //돼지 사료
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "돼지 사료",
                processItemCost = 10
            });

            //소 사료
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "소 사료",
                processItemCost = 10
            });

            //계란후라이
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "게란후라이",
                processItemCost = 10
            });

            //베이컨
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "베이컨",
                processItemCost = 10
            });

            //토마토 쥬스
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "토마토 쥬스",
                processItemCost = 10
            });

            //당근 쥬스
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "당근 쥬스",
                processItemCost = 10
            });

            //버터
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "버터",
                processItemCost = 10
            });

            //치즈
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "치즈",
                processItemCost = 10
            });
        }
    }
}

