using UnityEngine;
using System.Collections.Generic; //by.J:230721 List 변경화

//by.J:230720 생산품 (작물/동물) 오브젝트 
namespace JinnyCropItem
{
    //by.J:230720 구조체 정의
    [System.Serializable]
    public struct CropItemDataInfo
    {
        public string cropItemName;   //이름
        public int cropItemCost;     //가격
        public Sprite cropItemImage; //생산품 이미지
    }

    //by.J:230720 IItem 인터페이스 정의
    public class CropItem : MonoBehaviour, IItem
    {
        [SerializeField] public List<CropItemDataInfo> cropItemDataInfoList = new List<CropItemDataInfo>();

        public string[] ItemName
        {
            get
            {
                string[] names = new string[cropItemDataInfoList.Count];
                for (int i = 0; i < cropItemDataInfoList.Count; i++)
                {
                    names[i] = cropItemDataInfoList[i].cropItemName;
                }
                return names;
            }
            
        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[cropItemDataInfoList.Count];
                for (int i = 0; i < cropItemDataInfoList.Count; i++)
                {
                    costs[i] = cropItemDataInfoList[i].cropItemCost;
                }
                return costs;
            }
            
        }

        ////by.J:230720 시작시 초기화 기능 시작
        private void Start()
        {
            InitializeCropItems();
            Debug.Log("농장 생산품 리스트 크기 : " + cropItemDataInfoList.Count);
        }

        //by.J:230720 초기화 기능
        private void InitializeCropItems()
        {
            //우유
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "우유",
                cropItemCost = 10
            });

            //달걀
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "달걀",
                cropItemCost = 10
            });

            //돼지고기
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "돼지고기",
                cropItemCost = 10
            });


            //밀
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "밀",
                cropItemCost = 10
            });

            //옥수수
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "옥수수",
                cropItemCost = 10
            });

            //콩
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "콩",
                cropItemCost = 10
            });

            //토마토
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "토마토",
                cropItemCost = 10
            });

            //당근
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "당근",
                cropItemCost = 10
            });
            
        }
    }
}
