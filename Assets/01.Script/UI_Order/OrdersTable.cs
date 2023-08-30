using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersTable : MonoBehaviour
{
    public static OrdersTable instance;

    public static List<Order> orders; //아이템 3개 배정
  //List<Order> tes

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("orders Count : " + orders.Count);
    }
}
