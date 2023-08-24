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
                Debug.Log("ũ�Ӿ�");
                var foundItem = CropItem.Instance.cropItemDataInfoList
                    .Find(item => item.cropItemId == finishedProductId);

                if (!foundItem.Equals(default(CropItemDataInfo)))
                {
                    resultSprite = foundItem.cropItemImage;
                }
            }

            else if (finishedProductId.StartsWith("animal_") ||
                     finishedProductId.StartsWith("bread_") ||
                     finishedProductId.StartsWith("windmill_") ||
                     finishedProductId.StartsWith("grill_") ||
                     finishedProductId.StartsWith("juice_") ||
                     finishedProductId.StartsWith("dairy_"))
            {
                Debug.Log("ã�´�");
                var foundItem = ProcessItem.Instance.processItemDataInfoList
                    .Find(item => item.processItemId == finishedProductId);
                
                if (!foundItem.Equals(default(ProcessItemDataInfo)))
                {
                    resultSprite = foundItem.processItemImage;
                }
            }

            Debug.Log("Finished Product ID: " + finishedProductId);
            Debug.Log("�ϼ�ǰ �̹��� : " + (resultSprite ? resultSprite.name : "None"));
            return resultSprite;
        }



    }

    public Recipe(List<object> ingredients, ProcessItemDataInfo outputItem, int outputCount)
    {
        this.ingredients = ingredients;
        this.outputItem = outputItem;
        this.outputCount = outputCount;
//this.finishedProductId = finishedProductId;
    }
}
   

