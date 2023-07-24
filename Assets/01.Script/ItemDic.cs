using UnityEngine;
using System.Collections.Generic;
using JinnyBuilding;
using JinnyFarm;
using JinnyCropItem;
using JinnyProcessItem;


//by.J:230721 아이템 사전
public class ItemDic : MonoBehaviour
{
    Building building;
    Farm farm;
    CropItem cropItem;
    ProcessItem processItem;
   
    //by.J:230721 아이템 사전 선언
    public Dictionary<string, object> Item = new Dictionary<string, object>();

    public void Start()
    {
        building = new Building();
        farm = new Farm();
        cropItem = new CropItem();
        processItem = new ProcessItem();

        Item.Add("건물", building.buildingDataList);
        Item.Add("농장밭", farm.farmDataList);
        Item.Add("농장 생산품", cropItem.cropItemDataInfoList);
        Item.Add("가공 생산품", processItem.processitemDataInfoList);
    }

}