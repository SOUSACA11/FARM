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

    public void Awake()
    {

        building = gameObject.AddComponent<Building>();
        farm = gameObject.AddComponent<Farm>();
        cropItem = gameObject.AddComponent<CropItem>();
        processItem = gameObject.AddComponent<ProcessItem>();

    }
    public void Start()
    {

        Item.Add("�ǹ�", building.buildingDataList);
        Item.Add("�����", farm.farmDataList);
        Item.Add("���� ����ǰ", cropItem.cropItemDataInfoList);
        Item.Add("���� ����ǰ", processItem.processitemDataInfoList);

        Debug.Log("Item count: " + Item.Count);

    }
}