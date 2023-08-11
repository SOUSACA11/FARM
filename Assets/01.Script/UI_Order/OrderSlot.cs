//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using JinnyProcessItem;
//using JinnyCropItem;

////주문 관리
//public class OrderSlot : MonoBehaviour
//{
//    public CropItem cropItemManager;
//    public ProcessItem processItemManager;

//    public List<Order> RandomOrder(int numberOfItems)
//    {
//        List<Order> orders = new List<Order>();
//        List<CropItemDataInfo> cropItems = cropItemManager.cropItemDataInfoList;
//        List<ProcessItemDataInfo> processItems = processItemManager.processitemDataInfoList;

//        List<IItem> allItems = new List<IItem>(cropItems);
//        allItems.AddRange(processItems);

//        for (int i = 0; i < numberOfItems; i++)
//        {
//            int randomIndex = Random.Range(0, allItems.Count);
//            IItem randomItem = allItems[randomIndex];
//            int randomQuantity = Random.Range(1, 6); // 1~5 사이의 랜덤 수량

//            orders.Add(new Order
//            {
//                ItemId = randomItem.ItemId,
//                ItemImage = randomItem.ItemImage,
//                Quantity = randomQuantity,
//                TotalCost = randomItem.ItemCost * randomQuantity
//            });
//        }

//        return orders;
//    }

//    public int CalculateTotalCost(List<Order> orders)
//    {
//        int totalCost = 0;

//        foreach (var order in orders)
//        {
//            totalCost += order.TotalCost;
//        }

//        return totalCost;
//    }
//}
