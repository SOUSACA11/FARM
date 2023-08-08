using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : IItem
{

    public string[] ItemName { get; private set; }
    public int[] ItemCost { get; private set; }
    public Sprite[] ItemImage { get; private set; }

    // �����ڸ� ���� ������ �̸�, ����, �̹����� ����
    public Test(string name,int cost, Sprite image) 
    {
        this.ItemName = new string[] { name };
        this.ItemCost = new int[] { cost };
        this.ItemImage = new Sprite[] { image };
    }
}