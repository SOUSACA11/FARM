using UnityEngine;

//by.J:230720 생산품 오브젝트 스크립터블 / 생산품 정보 저장
namespace JinnyItemData
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item")]

    public class ItemData : ScriptableObject
    {
        public string itemName;     //이름
        public int itemCost;        //가격

    }
}
