using UnityEngine;
using System.Collections.Generic;
using JinnyBuilding;
using JinnyFarm;
using JinnyCropItem;


//by.J:230721 ������ ����
public class ItemDic : MonoBehaviour
{
    Building building;
    Farm farm;

    //by.J:230721 ������ ���� ����
    Dictionary<string, object> Item = new Dictionary<string, object>();

    public void Start()
    {
        building = new Building();
        farm = new Farm();

        Item.Add("�ǹ�", building.buildingDataList);
        Item.Add("�����", farm.farmDataList);
        //Item.Add("���۹�", )

    }

}