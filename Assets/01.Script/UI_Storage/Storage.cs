using System.Collections.Generic;
using UnityEngine;

//by.J:230808 â�� �ý���
//by.J:230829 �̱���
public class Storage : MonoBehaviour
{
    //Storage = Processitem, CropItem �� IItem Ÿ������ ���
    private Dictionary<IItem, int> items; //���� ������ ����
    private int capa;                     //�ִ� �뷮

    public static Storage Instance { get; private set; } //�̱���

    //�̺�Ʈ
    public delegate void StorageChanged();
    public event StorageChanged OnStorageChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Storages(100); //�ʱ� �뷮
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

    //������ �߰�
    public bool AddItem(IItem item, int count)
    {
        Debug.Log("â�� ������ �߰�");
        
        if (GetTotalItemCount() + count > capa)
        {
            //â���� �ִ� �뷮�� �ʰ��ϸ� �������� �߰����� ����
            return false;
        }

        if (items.ContainsKey(item))
        {
            items[item] += count;  //�̹� �������� �������� ��� ������ �ø�
        }
        else
        {
            items[item] = count;  //���ο� �������� ��� �������� �߰�
        }

        OnStorageChanged?.Invoke(); //�������� �߰��Ǹ� �̺�Ʈ ȣ��
        return true;
    }

    //������ ����
    public bool RemoveItem(IItem item, int count)
    {
        Debug.Log("â�� ������ ����");

        if (!items.ContainsKey(item) || items[item] < count)
        {
            //�������� �������� �ƴϰų�, ������ ������� ������ �������� �������� ����
            return false;
        }

        items[item] -= count;  //������ ���� ����
        if (items[item] == 0)
        {
            items.Remove(item);  //������ ������ 0�� �Ǹ� �������� ����
        }

        OnStorageChanged?.Invoke(); //�������� ���ŵǸ� �̺�Ʈ ȣ��
        return true;
    }

    //���� �� ������ �� ���� ��ȯ
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
