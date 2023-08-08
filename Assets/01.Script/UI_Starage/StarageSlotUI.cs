using UnityEngine;

//by.J:230808 â�� ���� UI ����
public class StarageSlotUI : MonoBehaviour
{
    public GameObject slotPrefab;  // ���� ������
    private Starage starage;  // â�� ������

    public Sprite image1;
    public Sprite image2;


    //â�� ����
    private void Start() //������ ȹ��� �߰� �� ���� ���� ��� �߰� �ʿ�
    {
        Starage starage = gameObject.AddComponent<Starage>();
        starage.Starages(100);  // �뷮�� 100�� â�� ����

        //// �ӽ÷� �������� â�� �߰�
        starage.AddItem(new Test("��", 10, image1), 5);
        starage.AddItem(new Test("�ٰ�Ʈ", 10, image2), 10);


        // â���� ������ ������ ���� ������ ����
        foreach (var item in starage.Items)
        {
            AddItemSlot(item.Key, item.Value);
        }
    }

    // ���ο� ������ �����ϰ� â�� UI�� �߰�
    private void AddItemSlot(IItem itemData, int count)
    {
        GameObject slot = Instantiate(slotPrefab, transform);  // ���� �������� ����
        Debug.Log("���� ��ġ :"+ transform);
        StarageSlot slotScript = slot.GetComponent<StarageSlot>();  // StarageSlot ��ũ��Ʈ�� ����

        // ���Կ� ������ �����͸� ����
        slotScript.SetItem(itemData, count);
    }
}

