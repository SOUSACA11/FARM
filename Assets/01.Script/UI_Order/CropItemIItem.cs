using UnityEngine;
using JinnyCropItem;

//by.J:230814 래퍼클래스 / CropItemDataInfo 데이터를 IItem 맞게 포장
public class CropItemIItem : IItem
{
    private CropItemDataInfo _info;
    //_info -> 내부적으로 참조하고 있는 원래 데이터 객체 / CropItemDataInfo타입의 인스턴스 변수

    public CropItemIItem(CropItemDataInfo info)
        {
            _info = info;
        }

    public string ItemName => _info.cropItemName;
    public int ItemCost => _info.cropItemCost;
    public Sprite ItemImage => _info.cropItemImage;
    public string ItemId => _info.cropItemId;
}
