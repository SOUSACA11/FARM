using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using JinnyBuilding;
using JinnyProcessItem;
using JinnyFarm;

//by.J:230811 ������ �ǹ� ���� ���� / ����ǰ ����
//by.J:230816 ������ ���� �߰�
//by.J:230825 Ÿ�� ���� �߰�
public class WorkBuilding : MonoBehaviour
{
    public bool isProducing = false;                            //������
    public float startTime;                                     //�������
    public float productionDuration = 60f;                      //���� �ʿ� �ð�
    public List<IItem> ingredientList = new List<IItem>();      //�ʿ� ��� ���
    public List<IItem> needIngredient = new List<IItem>();      //���꿡 �ʿ��� ��� ���
    public IItem product;                                       //���� �Ϸ� ������
    public BuildingType buildingType;                           //���� �ǹ� Ÿ��
    public FarmType farmType;                                   //���� Ÿ��

    public Recipe currentRecipe;                                //���� �ǹ����� ����� ������

    public Sprite finishedProductImage; //�ϼ�ǰ �̹���

    private void Update()
    {
        CheckProduction();
    }

    //���� Ÿ�� �ڵ� ����
    public void Initialize(BuildingType type)
    {
        //Debug.Log("���徲��2");
        this.buildingType = type;
        this.farmType = FarmType.None;
        //Debug.Log(buildingType);
    }

    //���� Ÿ�� �ڵ� ����
    public void Initialize(FarmType type)
    {
        //Debug.Log("��������2");
        this.farmType = type;
        this.buildingType = BuildingType.None;
        //Debug.Log(farmType);
    }

    public void SetRecipe(Recipe recipe) //������ ����
    {
        if (buildingType == BuildingType.None) return;

        currentRecipe = recipe;
        needIngredient.Clear();

        foreach (var ingredientObj in recipe.ingredients)
        {
            //��ᰡ Ingredient<IItem> Ÿ������ Ȯ��
            if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                needIngredient.Add(new ProcessItemIItem(processedIngredient.item));
            }
        }
        product = new ProcessItemIItem(recipe.outputItem);
    }

    public void AddItem(IItem item) //��� �߰�
    {
        if (buildingType == BuildingType.None) return;

        if (!isProducing && needIngredient.Contains(item)) //�����ǿ� �ʿ��� ������� Ȯ�� �� ���� ���� �ƴ��� Ȯ��
        {
            ingredientList.Add(item);

            //��� ��ᰡ �߰��Ǿ����� Ȯ��
            if (ingredientList.Count == needIngredient.Count)
            {
                StartProduction();
            }
        }
        else
        {
            //�ʿ����� ���� ���
        }
    }

    public void StartProduction() //���� ����
    {
        isProducing = true;
        startTime = Time.time;
    }

    private void CheckProduction() //���� �Ϸ� üũ
    {
        if (isProducing && Time.time - startTime >= productionDuration)
        {
            isProducing = false;
            CompleteProduction();
        }
    }

    private void CompleteProduction() //���� �Ϸ�
    {
       // product = new FinishedProduct();

        //��� ��� �ʱ�ȭ
        ingredientList.Clear();

        //��ᰡ ���Ǹ� ����ҿ��� ��Ḧ �����ϴ� �߰� ������ ���⿡ ������ �� �ֽ��ϴ�.
    }

    //void OnMouseDown() //�ǹ� Ŭ��
    //{
    //    if (EventSystem.current.IsPointerOverGameObject()) // UI Ŭ���� ����
    //        return;

    //    // �ش� �ǹ��� �����ǿ� ���� UI ������Ʈ
    //    IngredientUI.Instance.IngredientClick();
    //    Debug.Log("���� �۵���?");

    //}
}
