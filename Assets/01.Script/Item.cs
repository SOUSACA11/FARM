using UnityEngine;
using System.Collections.Generic;
using JinnyProcessItem;
//by.J:230816 ������, �����, ������ ����
//[System.Serializable]
//public class Item
//{
//    public string itemName;
//    public Sprite itemIcon;
//}

//����� ����
[System.Serializable]
public class Ingredient<T> //���׸� -> ������ Ÿ�� ����ȭ / Ÿ�� �̸� �������� �ʰ� ����� ����
{
    public T item;       //������
    public int quantity; //����

    public Ingredient(T item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}

//������ ����
[System.Serializable]
public class Recipe
{
    public List<object> ingredients;  //���� Ingredient Ÿ���� ����ϱ� ���� object ���
    public ProcessItemDataInfo outputItem;
    public int outputCount;

    public Recipe(List<object> ingredients, ProcessItemDataInfo outputItem, int outputCount)
    {
        this.ingredients = ingredients;
        this.outputItem = outputItem;
        this.outputCount = outputCount;
    }
}
   

