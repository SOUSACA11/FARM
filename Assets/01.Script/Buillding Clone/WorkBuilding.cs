using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using JinnyBuilding;
using JinnyProcessItem;
using JinnyFarm;
using System.Linq;
using System.Collections;

//by.J:230811 ������ �ǹ� ���� ���� / ����ǰ ����
//by.J:230816 ������ ���� �߰�
//by.J:230825 Ÿ�� ���� �߰�
//by.J:230827 �ϼ�ǰ �̹��� �巡�� ��ӽ� ���� ����
//by.J:230829 ����Ϸ�� ��¦��¦ ȿ��
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

    public Sprite finishedProductImage;                         //�ϼ�ǰ �̹���
    public GameObject finishedProductUI;                        //�巡�� �� �ϼ�ǰ â

    private SpriteRenderer spriteRenderer;
    private Color originalColor;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

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
        Debug.Log("��������2");
        this.farmType = type;
        this.buildingType = BuildingType.None;


        //Debug.Log(farmType);
    }

    //������ ����
    public void SetRecipe(Recipe recipe)
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

    //��� �߰�
    public void AddItem(IItem item)
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

    //���� ����
    public void StartProduction() 
    {
        Debug.Log("���� ����");

        // �ʿ��� ��ᰡ ������� Ȯ��
        foreach (IItem requiredItem in needIngredient)
        {
            int requiredCount = needIngredient.Count(item => item == requiredItem);
            int availableCount = ingredientList.Count(item => item == requiredItem);

            if (availableCount < requiredCount)
            {
                Debug.Log("��ᰡ �����մϴ�!");
                return;
            }
        }

        //�̹��� �����
        if (finishedProductUI)
        {
            finishedProductUI.SetActive(false);
        }

        isProducing = true;
        startTime = Time.time;
    }

    //���� �Ϸ� üũ
    private void CheckProduction() 
    {

        if (isProducing && Time.time - startTime >= productionDuration)
        {
            isProducing = false;
            CompleteProduction();
        }
    }

    //���� �Ϸ�
    private void CompleteProduction() 
    {
        Debug.Log("���� �Ϸ�");
        
        //��� ��� �ʱ�ȭ
        ingredientList.Clear();

        if (spriteRenderer != null)
        {
            StartCoroutine(BlinkEffect());
        }

    }

    IEnumerator BlinkEffect()
    {
        int blinkTimes = 5;
        float blinkDuration = 0.1f;

        for (int i = 0; i < blinkTimes; i++)
        {
            // �����ϰ� ����
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
            yield return new WaitForSeconds(blinkDuration);

            // ���� �������� ����
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
