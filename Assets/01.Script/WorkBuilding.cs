using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JinnyInventory;

//by.J:230811 ������ �ǹ� ����ǰ ����
public class WorkBuilding : MonoBehaviour
{
    public bool isProducing = false; //������
    public float startTime; //�������
    public float productionDuration = 60f; //���� �ʿ� �ð�
    public List<IItem> ingredientList = new List<IItem>(); //�ʿ� ��� ���
    public List<IItem> requiredIngredients = new List<IItem>(); //���꿡 �ʿ��� ��� ���
    public IItem product; //���� �Ϸ� ������

    private void Update()
    {
        CheckProduction();
    }

    public void AddIngredient(IItem item) //��� �߰�
    {
        ingredientList.Add(item);

        // ��� ��ᰡ �߰��Ǿ����� Ȯ��
        if (ingredientList.Count == requiredIngredients.Count)
        {
            StartProduction();
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

    private void CompleteProduction()
    {
       // product = new FinishedProduct();

        // ��� ��� �ʱ�ȭ
        ingredientList.Clear();
    }
}
