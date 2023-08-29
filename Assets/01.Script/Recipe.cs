using UnityEngine;
using System.Collections.Generic;
using JinnyProcessItem;
using JinnyCropItem;

//by.J:230816 ������, �����, ������ ����
//by.J;230829 ����ð� �߰�

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
    //public List<object> ingredients;  //���� Ingredient Ÿ���� ����ϱ� ���� object ���
    //public ProcessItemDataInfo outputItem;
    //public int outputCount;
    //public string finishedProductId; //�ϼ�ǰ ID ����
    //public float productionTime;     //���� �ð�
    public bool IsInitialized;

    public List<object> ingredients;
    public ProcessItemDataInfo finishedProduct;
    public int finishedProductCount;
    public float productionTime;
    public string finishedProductId;

    //�ϼ�ǰ ID �������� �̹��� �߰�
    public Sprite FinishedProductImage
    {
        get
        {
            Debug.Log("������Ƽ ���۾�");

            Sprite resultSprite = null;

            Debug.Log("Instance: " + CropItem.Instance);
            Debug.Log("List: " + CropItem.Instance.cropItemDataInfoList);
            Debug.Log("Finished Product ID: " + finishedProductId);

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


    public Recipe(List<object> ingredients, ProcessItemDataInfo finishedProduct, int finishedProductCount, float productionTime)
    {
        this.ingredients = ingredients;
        this.finishedProduct = finishedProduct;
        this.finishedProductCount = finishedProductCount;
        this.productionTime = productionTime;
        this.finishedProductId = finishedProduct.processItemId;
        this.IsInitialized = true;
    }
}
   

