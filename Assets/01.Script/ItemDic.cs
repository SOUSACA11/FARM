using UnityEngine;
using System.Collections.Generic;
using JinnyBuilding;
using JinnyFarm;
using JinnyCropItem;
using JinnyProcessItem;


//by.J:230721 ������ ����
public class ItemDic : MonoBehaviour
{
    Building building;
    Farm farm;
    CropItem cropItem;
    ProcessItem processItem;
   
    //by.J:230721 ������ ���� ����
    public Dictionary<string, object> Item = new Dictionary<string, object>();

    public void Start()
    {
        building = new Building();
        farm = new Farm();
        cropItem = new CropItem();
        processItem = new ProcessItem();

        Item.Add("�ǹ�", building.buildingDataList);
        Item.Add("�����", farm.farmDataList);
        Item.Add("���� ����ǰ", cropItem.cropItemDataInfoList);
        Item.Add("���� ����ǰ", processItem.processitemDataInfoList);
    }

}