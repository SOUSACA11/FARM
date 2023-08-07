using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // 아이템 정보
    [System.Serializable]
    public class Item
    {
        public string id;    // 아이템의 고유 ID
        public int quantity; // 아이템의 수량
        // 필요하다면, 여기에 다른 정보(이름, 이미지 등)를 추가할 수 있습니다.
    }

    private Dictionary<string, Item> items = new Dictionary<string, Item>(); // ID를 키로 가지는 아이템 사전

    // 아이템을 추가하는 메서드
    public void AddItem(string id, int quantity)
    {
        if (items.ContainsKey(id)) // 이미 해당 ID의 아이템이 있으면
        {
            items[id].quantity += quantity; // 수량을 더함
        }
        else // 해당 ID의 아이템이 없으면
        {
            items[id] = new Item { id = id, quantity = quantity }; // 새 아이템을 생성
        }
    }

    // 아이템을 제거하는 메서드
    public bool RemoveItem(string id, int quantity)
    {
        if (!items.ContainsKey(id) || items[id].quantity < quantity) // 아이템이 없거나, 수량이 부족하면
        {
            return false; // 제거 실패
        }

        items[id].quantity -= quantity; // 수량을 뺌

        if (items[id].quantity <= 0) // 아이템의 수량이 0이하가 되면
        {
            items.Remove(id); // 아이템을 제거
        }

        return true; // 제거 성공
    }

    // 아이템의 수량을 가져오는 메서드
    public int GetQuantity(string id)
    {
        if (!items.ContainsKey(id)) // 해당 ID의 아이템이 없으면
        {
            return 0; // 0을 반환
        }

        return items[id].quantity; // 아이템의 수량을 반환
    }

    // 모든 아이템을 가져오는 메서드
    public List<Item> GetAllItems()
    {
        return new List<Item>(items.Values);
    }
}
