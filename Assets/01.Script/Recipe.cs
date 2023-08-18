using UnityEngine;
using System.Collections.Generic;
using JinnyProcessItem;
using JinnyCropItem;

//by.J:230816 ������, �����, ������ ����

//����� ���� ����Ʈ ����
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
    public string finishedProductId; //�ϼ�ǰ ID ����

    //�ϼ�ǰ ID �������� �̹��� �߰�
    public Sprite FinishedProductImage
    {

        get
        {
            Debug.Log("������Ƽ ���۾�");

            Sprite resultSprite = null;
            if (finishedProductId.StartsWith("crop_"))
            {
                resultSprite = CropItem.Instance.cropItemDataInfoList
                    .Find(item => item.cropItemId == finishedProductId).cropItemImage;
            }
            else
            {
                resultSprite = ProcessItem.Instance.processitemDataInfoList
                    .Find(item => item.processItemId == finishedProductId).processItemImage;
            }

            Debug.Log("Finished Product Image: " + (resultSprite ? resultSprite.name : "None"));
            return resultSprite;
        }

    }

    public Recipe(List<object> ingredients, ProcessItemDataInfo outputItem, int outputCount)
    {
        this.ingredients = ingredients;
        this.outputItem = outputItem;
        this.outputCount = outputCount;
    }
}
   

