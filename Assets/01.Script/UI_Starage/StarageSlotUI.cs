using UnityEngine;

//by.J:230808 창고 슬롯 UI 관리
public class StarageSlotUI : MonoBehaviour
{
    public GameObject slotPrefab;  // 슬롯 프리팹
    private Starage starage;  // 창고 데이터

    public Sprite image1;
    public Sprite image2;


    //창고 생성
    private void Start() //아이템 획득시 추가 및 사용시 제거 기능 추가 필요
    {
        Starage starage = gameObject.AddComponent<Starage>();
        starage.Starages(100);  // 용량이 100인 창고를 생성

        //// 임시로 아이템을 창고에 추가
        starage.AddItem(new Test("빵", 10, image1), 5);
        starage.AddItem(new Test("바게트", 10, image2), 10);


        // 창고의 아이템 각각에 대해 슬롯을 생성
        foreach (var item in starage.Items)
        {
            AddItemSlot(item.Key, item.Value);
        }
    }

    // 새로운 슬롯을 생성하고 창고 UI에 추가
    private void AddItemSlot(IItem itemData, int count)
    {
        GameObject slot = Instantiate(slotPrefab, transform);  // 슬롯 프리팹을 생성
        Debug.Log("슬롯 위치 :"+ transform);
        StarageSlot slotScript = slot.GetComponent<StarageSlot>();  // StarageSlot 스크립트를 참조

        // 슬롯에 아이템 데이터를 설정
        slotScript.SetItem(itemData, count);
    }
}

