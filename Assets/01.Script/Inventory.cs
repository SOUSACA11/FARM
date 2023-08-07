using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // ������ ����
    [System.Serializable]
    public class Item
    {
        public string id;    // �������� ���� ID
        public int quantity; // �������� ����
        // �ʿ��ϴٸ�, ���⿡ �ٸ� ����(�̸�, �̹��� ��)�� �߰��� �� �ֽ��ϴ�.
    }

    private Dictionary<string, Item> items = new Dictionary<string, Item>(); // ID�� Ű�� ������ ������ ����

    // �������� �߰��ϴ� �޼���
    public void AddItem(string id, int quantity)
    {
        if (items.ContainsKey(id)) // �̹� �ش� ID�� �������� ������
        {
            items[id].quantity += quantity; // ������ ����
        }
        else // �ش� ID�� �������� ������
        {
            items[id] = new Item { id = id, quantity = quantity }; // �� �������� ����
        }
    }

    // �������� �����ϴ� �޼���
    public bool RemoveItem(string id, int quantity)
    {
        if (!items.ContainsKey(id) || items[id].quantity < quantity) // �������� ���ų�, ������ �����ϸ�
        {
            return false; // ���� ����
        }

        items[id].quantity -= quantity; // ������ ��

        if (items[id].quantity <= 0) // �������� ������ 0���ϰ� �Ǹ�
        {
            items.Remove(id); // �������� ����
        }

        return true; // ���� ����
    }

    // �������� ������ �������� �޼���
    public int GetQuantity(string id)
    {
        if (!items.ContainsKey(id)) // �ش� ID�� �������� ������
        {
            return 0; // 0�� ��ȯ
        }

        return items[id].quantity; // �������� ������ ��ȯ
    }

    // ��� �������� �������� �޼���
    public List<Item> GetAllItems()
    {
        return new List<Item>(items.Values);
    }
}
