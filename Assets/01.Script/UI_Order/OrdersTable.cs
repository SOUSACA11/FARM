using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersTable : MonoBehaviour
{
    public static OrdersTable instance;

    public static List<Order> orders; //������ 3�� ����
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
