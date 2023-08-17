using UnityEngine;
using System.Collections.Generic;
using JinnyProcessItem;
//by.J:230816 아이템, 원재료, 레시피 설정
//[System.Serializable]
//public class Item
//{
//    public string itemName;
//    public Sprite itemIcon;
//}

//원재료 설정
[System.Serializable]
public class Ingredient<T> //제네릭 -> 데이터 타입 유연화 / 타입 미리 지정하지 않고 실행시 지정
{
    public T item;       //아이템
    public int quantity; //수량

    public Ingredient(T item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}

//레시피 설정
[System.Serializable]
public class Recipe
{
    public List<object> ingredients;  //여러 Ingredient 타입을 허용하기 위해 object 사용
    public ProcessItemDataInfo outputItem;
    public int outputCount;

    public Recipe(List<object> ingredients, ProcessItemDataInfo outputItem, int outputCount)
    {
        this.ingredients = ingredients;
        this.outputItem = outputItem;
        this.outputCount = outputCount;
    }
}
   

