using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : IItem
{

    public string[] ItemName { get; private set; }
    public int[] ItemCost { get; private set; }
    public Sprite[] ItemImage { get; private set; }

    // 생성자를 통해 아이템 이름, 가격, 이미지를 설정
    public Test(string name,int cost, Sprite image) 
    {
        this.ItemName = new string[] { name };
        this.ItemCost = new int[] { cost };
        this.ItemImage = new Sprite[] { image };
    }
}