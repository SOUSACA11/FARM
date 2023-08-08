using System.Collections.Generic;
using UnityEngine;
//by.J:230808 â�� �ý���
public class Starage : MonoBehaviour
{
    //Starage = Processitem, CropItem �� IItem Ÿ������ ���
    private Dictionary<IItem, int> items; //���� ������ ����
    private int capa;                     //�ִ� �뷮

    public void Starages(int capa)
    {
        this.items = new Dictionary<IItem, int>();
        this.capa = capa;
    }

    public Dictionary<IItem, int> Items { get { return items; } } // Items property �߰�

    // ������ �߰�
    public bool AddItem(IItem item, int count)
    {
        if (GetTotalItemCount() + count > capa)
        {
            // â���� �ִ� �뷮�� �ʰ��ϸ� �������� �߰����� ����
            return false;
        }

        if (items.ContainsKey(item))
        {
            items[item] += count;  // �̹� �������� �������� ��� ������ �ø�
        }
        else
        {
            items[item] = count;  // ���ο� �������� ��� �������� �߰�
        }

        return true;
    }

    // ������ ����
    public bool RemoveItem(IItem item, int count)
    {
        if (!items.ContainsKey(item) || items[item] < count)
        {
            // �������� �������� �ƴϰų�, ������ ������� ������ �������� �������� ����
            return false;
        }

        items[item] -= count;  // ������ ���� ����
        if (items[item] == 0)
        {
            items.Remove(item);  // ������ ������ 0�� �Ǹ� �������� ����
        }

        return true;
    }

    // ���� �� ������ �� ���� ��ȯ
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
