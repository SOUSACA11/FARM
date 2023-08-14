using UnityEngine;
using System.Collections.Generic;

//by.J:230720 생산품 (작물/동물) 오브젝트
//by.J:230721 List 변경화
//by.J:230728 이미지 추가 작업
//by.J:230814 IItem 수정에 따른 작업
namespace JinnyCropItem
{
    //구조체 정의
    [System.Serializable]
    public struct CropItemDataInfo
    {
        public string cropItemName;   //이름
        public int cropItemCost;      //가격
        public Sprite cropItemImage;  //생산품 이미지
        public string cropItemId;             //아이템 고유 ID
    }

    //IItem 인터페이스 정의
    public class CropItem : MonoBehaviour //, IItem
    {
        [SerializeField] public List<CropItemDataInfo> cropItemDataInfoList = new List<CropItemDataInfo>();

        //public string[] ItemName
        //{
        //    get
        //    {
        //        string[] names = new string[cropItemDataInfoList.Count];
        //        for (int i = 0; i < cropItemDataInfoList.Count; i++)
        //        {
        //            names[i] = cropItemDataInfoList[i].cropItemName;
        //        }
        //        return names;
        //    }
            
        //}

        //public int[] ItemCost
        //{
        //    get
        //    {
        //        int[] costs = new int[cropItemDataInfoList.Count];
        //        for (int i = 0; i < cropItemDataInfoList.Count; i++)
        //        {
        //            costs[i] = cropItemDataInfoList[i].cropItemCost;
        //        }
        //        return costs;
        //    }
            
        //}

        //public Sprite[] ItemImage
        //{
        //    get
        //    {
        //        Sprite[] images = new Sprite[cropItemDataInfoList.Count];
        //        for (int i = 0; i < cropItemDataInfoList.Count; i++)
        //        {
        //            images[i] = cropItemDataInfoList[i].cropItemImage;
        //        }
        //        return images;
        //    }
        //}

        //public string[] ItemId
        //{
        //    get
        //    {
        //        string[] names = new string[cropItemDataInfoList.Count];
        //        for (int i = 0; i < cropItemDataInfoList.Count; i++)
        //        {
        //            names[i] = cropItemDataInfoList[i].cropItemId;
        //        }
        //        return names;
        //    }

        //}

        //시작시 초기화 기능 시작
        private void Awake()
        {
            InitializeCropItems();
            Debug.Log("농장 생산품 리스트 크기 : " + cropItemDataInfoList.Count);
        }

        //초기화 기능
        private void InitializeCropItems()
        {
            //이미지 추가
            Sprite[] sprites = Resources.LoadAll<Sprite>("Item");
            Sprite milk = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_0"));
            Sprite egg = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_1"));
            Sprite pork = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_2"));
            Sprite wheat = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_3"));
            Sprite corn = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_4"));
            Sprite bean = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_5"));
            Sprite tomato = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_6"));
            Sprite carrot = System.Array.Find(sprites, sprite => sprite.name.Equals("Item_7"));

            //우유
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "우유",
                cropItemCost = 10,
                cropItemImage = milk,
                cropItemId = "animal_01"
            });

            //달걀
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "달걀",
                cropItemCost = 10,
                cropItemImage = egg,
                cropItemId = "animal_02"
            });

            //돼지고기
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "돼지고기",
                cropItemCost = 10,
                cropItemImage = pork,
                cropItemId = "animal_03"
            });


            //밀
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "밀",
                cropItemCost = 10,
                cropItemImage = wheat,
                cropItemId = "crop_01"
            });

            //옥수수
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "옥수수",
                cropItemCost = 10,
                cropItemImage = corn,
                cropItemId = "crop_02"
            });

            //콩
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "콩",
                cropItemCost = 10,
                cropItemImage = bean,
                cropItemId = "crop_03"
            });

            //토마토
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "토마토",
                cropItemCost = 10,
                cropItemImage = tomato,
                cropItemId = "crop_04"
            });

            //당근
            cropItemDataInfoList.Add(new CropItemDataInfo()
            {
                cropItemName = "당근",
                cropItemCost = 10,
                cropItemImage = carrot,
                cropItemId = "crop_05"
            });
            
        }
    }
}
