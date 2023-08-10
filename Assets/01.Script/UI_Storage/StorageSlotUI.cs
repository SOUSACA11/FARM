using UnityEngine;

//by.J:230808 â�� ���� UI ����
public class StorageSlotUI : MonoBehaviour
{
    public GameObject slotPrefab;  //���� ������
    private Storage storage;  //â�� ������

    public Sprite image1;
    public Sprite image2;


    //â�� ����
    private void Start() //������ ȹ��� �߰� �� ���� ���� ��� �߰� �ʿ�
    {
        Storage storage = gameObject.AddComponent<Storage>();
        storage.Storages(100);  //�뷮�� 100�� â�� ����

        //// �ӽ÷� �������� â�� �߰�
        //storage.AddItem(new Test("��", 10, image1), 5);
        //storage.AddItem(new Test("�ٰ�Ʈ", 10, image2), 10);


        //â���� ������ ������ ���� ������ ����
        foreach (var item in storage.Items)
        {
            AddItemSlot(item.Key, item.Value);
        }
    }

    //���ο� ������ �����ϰ� â�� UI�� �߰�
    private void AddItemSlot(IItem itemData, int count)
    {
        GameObject slot = Instantiate(slotPrefab, transform);  //���� �������� ����
        //Debug.Log("���� ��ġ :"+ transform);
        StorageSlot slotScript = slot.GetComponent<StorageSlot>();  //StarageSlot ��ũ��Ʈ�� ����

        //���Կ� ������ �����͸� ����
        slotScript.SetItem(itemData, count);
    }
}

