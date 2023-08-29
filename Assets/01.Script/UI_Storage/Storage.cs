using System.Collections.Generic;
using UnityEngine;

//by.J:230808 창고 시스템
//by.J:230829 싱글톤
public class Storage : MonoBehaviour
{
    //Storage = Processitem, CropItem 을 IItem 타입으로 취급
    private Dictionary<IItem, int> items; //보유 아이템 사전
    private int capa;                     //최대 용량

    public static Storage Instance { get; private set; } //싱글톤

    //이벤트
    public delegate void StorageChanged();
    public event StorageChanged OnStorageChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Storages(100); //초기 용량
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void Storages(int capa)
    {
        this.items = new Dictionary<IItem, int>();
        this.capa = capa;
    }

    public Dictionary<IItem, int> Items { get { return items; } } 

    //아이템 추가
    public bool AddItem(IItem item, int count)
    {
        Debug.Log("창고 아이템 추가");
        
        if (GetTotalItemCount() + count > capa)
        {
            //창고의 최대 용량을 초과하면 아이템을 추가하지 않음
            return false;
        }

        if (items.ContainsKey(item))
        {
            items[item] += count;  //이미 보유중인 아이템인 경우 수량을 늘림
        }
        else
        {
            items[item] = count;  //새로운 아이템인 경우 아이템을 추가
        }

        OnStorageChanged?.Invoke(); //아이템이 추가되면 이벤트 호출
        return true;
    }

    //아이템 제거
    public bool RemoveItem(IItem item, int count)
    {
        Debug.Log("창고 아이템 제거");

        if (!items.ContainsKey(item) || items[item] < count)
        {
            //보유중인 아이템이 아니거나, 수량이 충분하지 않으면 아이템을 제거하지 않음
            return false;
        }

        items[item] -= count;  //아이템 수량 줄임
        if (items[item] == 0)
        {
            items.Remove(item);  //아이템 수량이 0이 되면 아이템을 제거
        }

        OnStorageChanged?.Invoke(); //아이템이 제거되면 이벤트 호출
        return true;
    }

    //보유 중 아이템 총 개수 반환
    private int GetTotalItemCount()
    {
        if (items == null)
        {
            Debug.LogError("Items dictionary is not initialized!");
            return 0;
        }

        int totalCount = 0;
        foreach (int count in items.Values)
        {
            totalCount += count;
        }
        return totalCount;
    }
}
