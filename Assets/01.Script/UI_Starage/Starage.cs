using System.Collections.Generic;
using UnityEngine;
//by.J:230808 창고 시스템
public class Starage : MonoBehaviour
{
    //Starage = Processitem, CropItem 을 IItem 타입으로 취급
    private Dictionary<IItem, int> items; //보유 아이템 사전
    private int capa;                     //최대 용량

    public void Starages(int capa)
    {
        this.items = new Dictionary<IItem, int>();
        this.capa = capa;
    }

    public Dictionary<IItem, int> Items { get { return items; } } // Items property 추가

    // 아이템 추가
    public bool AddItem(IItem item, int count)
    {
        if (GetTotalItemCount() + count > capa)
        {
            // 창고의 최대 용량을 초과하면 아이템을 추가하지 않음
            return false;
        }

        if (items.ContainsKey(item))
        {
            items[item] += count;  // 이미 보유중인 아이템인 경우 수량을 늘림
        }
        else
        {
            items[item] = count;  // 새로운 아이템인 경우 아이템을 추가
        }

        return true;
    }

    // 아이템 제거
    public bool RemoveItem(IItem item, int count)
    {
        if (!items.ContainsKey(item) || items[item] < count)
        {
            // 보유중인 아이템이 아니거나, 수량이 충분하지 않으면 아이템을 제거하지 않음
            return false;
        }

        items[item] -= count;  // 아이템 수량 줄임
        if (items[item] == 0)
        {
            items.Remove(item);  // 아이템 수량이 0이 되면 아이템을 제거
        }

        return true;
    }

    // 보유 중 아이템 총 개수 반환
    private int GetTotalItemCount()
    {
        int totalCount = 0;
        foreach (int count in items.Values)
        {
            totalCount += count;
        }
        return totalCount;
    }
}
