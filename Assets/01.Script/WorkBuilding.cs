using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JinnyInventory;

//by.J:230811 복제된 건물 생산품 제작
public class WorkBuilding : MonoBehaviour
{
    public bool isProducing = false; //생산중
    public float startTime; //생산시작
    public float productionDuration = 60f; //생산 필요 시간
    public List<IItem> ingredientList = new List<IItem>(); //필요 재료 목록
    public List<IItem> requiredIngredients = new List<IItem>(); //생산에 필요한 재료 목록
    public IItem product; //생산 완료 아이템

    private void Update()
    {
        CheckProduction();
    }

    public void AddIngredient(IItem item) //재료 추가
    {
        ingredientList.Add(item);

        // 모든 재료가 추가되었는지 확인
        if (ingredientList.Count == requiredIngredients.Count)
        {
            StartProduction();
        }
    }

    public void StartProduction() //생산 시작
    {
        isProducing = true;
        startTime = Time.time;
    }

    private void CheckProduction() //생산 완료 체크
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

        // 재료 목록 초기화
        ingredientList.Clear();
    }
}
