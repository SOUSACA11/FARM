using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JinnyProcessItem;
using JinnyCropItem;

//by.J:230808 â�� ���� UI ����
public class StorageSlotUI : MonoBehaviour
{
    public GameObject slotPrefab;  //���� ������
    private Storage storage;  //â�� ������

    private void Awake()
    {
        storage = Storage.Instance;
        //storage = gameObject.AddComponent<Storage>();


        storage.OnStorageChanged += UpdateUI; // �̺�Ʈ ����
    }


    //â�� ����
    private void Start() //������ ȹ��� �߰� �� ���� ���� ��� �߰� �ʿ�
    {
        //Storage storage = gameObject.AddComponent<Storage>();
        //storage.Storages(100);  //�뷮�� 100�� â�� ����

       
        UpdateUI(); // �ʱ� UI ����



        //â���� ������ ������ ���� ������ ����
        foreach (var item in storage.Items)
        {
            AddItemSlot(item.Key, item.Value);
        }
    }

    //���ο� ������ �����ϰ� â�� UI�� �߰�
    private void AddItemSlot(IItem itemData, int count)
    {
        Debug.Log("â�� ���� �߰�");
        GameObject slot = Instantiate(slotPrefab, transform);  //���� �������� ����
        //Debug.Log("���� ��ġ :"+ transform);
        StorageSlot slotScript = slot.GetComponent<StorageSlot>();  //StarageSlot ��ũ��Ʈ�� ����

        //���Կ� ������ �����͸� ����
        slotScript.SetItem(itemData, count);
    }

    private void UpdateUI()
    {
        //���� ���� ����
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // storage�� ������ �α׷� ���
        foreach (var item in storage.Items)
        {
            Debug.Log($"Item: {item.Key.ItemName}, Count: {item.Value}");  //ItemName�� IItem�� �ִ� �Ӽ��̶�� ����
        }

        //�� ���� �߰�
        foreach (var item in storage.Items)
        {
            AddItemSlot(item.Key, item.Value);
        }
    }
}

