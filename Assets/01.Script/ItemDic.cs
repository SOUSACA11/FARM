using UnityEngine;
using System.Collections.Generic;
using JinnyBuilding;
using JinnyFarm;
using JinnyCropItem;


//by.J:230721 아이템 사전
public class ItemDic : MonoBehaviour
{
    Building building;
    Farm farm;

    //by.J:230721 아이템 사전 선언
    Dictionary<string, object> Item = new Dictionary<string, object>();

    public void Start()
    {
        building = new Building();
        farm = new Farm();

        Item.Add("건물", building.buildingDataList);
        Item.Add("농장밭", farm.farmDataList);
        //Item.Add("농작물", )

    }

}