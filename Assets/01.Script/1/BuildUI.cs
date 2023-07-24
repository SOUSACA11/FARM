using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

////by.J:230724 �ǹ� ���� UI
public class BuildUI : MonoBehaviour
{
    public Text itemNameText; // ������ �̸��� ǥ���� Text ������Ʈ
    public Text itemPriceText; // ������ ������ ǥ���� Text ������Ʈ
    public GameObject storePanel; // ���� �г�
    public Button purchaseButton; // ���� ��ư

    private ItemDic itemDic;
    private string selectedItem;

    private void Start()
    {
        itemDic = FindObjectOfType<ItemDic>(); // ������ ���� ���� ��������

        // ���� ��ư�� Ŭ�� �̺�Ʈ �߰�
        purchaseButton.onClick.AddListener(PurchaseItem);
    }

    public void ShowItem(string itemType)
    {
        selectedItem = itemType;

        // ������ �̸��� ������ UI�� ǥ���ϱ�
        // �� �κ��� ���� ���ӿ� ���� �޶��� �� ����
        // itemType�� ���� �ش� �������� �̸��� ������ �����;� ��
        itemNameText.text = itemType;
        itemPriceText.text = "����";
    }

    public void PurchaseItem()
    {
        // ���� ����
        // �� �κ��� ���� ������ ���� ������ ���� �޶��� �� ����
        Debug.Log(selectedItem + " ����!");
    }
}


    //public GameObject storePanel;  // ���� �г� ����
    //public Button openStoreButton; // ���� ���� ��ư ����
    //public Button closeStoreButton; // ���� �ݱ� ��ư ����
    //public Transform itemListPanel; // ������ ����Ʈ �г� ����
    //public GameObject itemPrefab; // ������ ��ư Prefab ����

    //// �ӽ� ������ ����Ʈ
    //private List<string> items = new List<string>() { "item1", "item2", "item3" };

    //private void Start()
    //{
    //    // ��ư�� Ŭ�� ������ �߰�
    //    openStoreButton.onClick.AddListener(OpenStore);
    //    closeStoreButton.onClick.AddListener(CloseStore);

    //    // �ʱ� ���¿����� ���� �г��� ����
    //    storePanel.SetActive(false);

    //    // ������ ����Ʈ �ʱ�ȭ
    //    InitItemList();
    //}

    //// ���� ���� ��ư�� ���� �� ȣ��Ǵ� �Լ�
    //public void OpenStore()
    //{
    //    // ���� �г� Ȱ��ȭ
    //    storePanel.SetActive(true);
    //}

    //// ���� �ݱ� ��� (�̸� ȣ���ϴ� ��ư�� �ʿ�)
    //public void CloseStore()
    //{
    //    // ���� �г� ��Ȱ��ȭ
    //    storePanel.SetActive(false);
    //}

    //// ������ ����Ʈ �ʱ�ȭ
    //private void InitItemList()
    //{
    //    foreach (string item in items)
    //    {
    //        GameObject itemButton = Instantiate(itemPrefab, itemListPanel);
    //        itemButton.GetComponentInChildren<Text>().text = item;
    //        itemButton.GetComponent<Button>().onClick.AddListener(() => PurchaseItem(item));
    //    }
    //}

    //// ������ ���� ���
    //private void PurchaseItem(string item)
    //{
    //    Debug.Log($"{item}��(��) �����߽��ϴ�.");
    //    // ���� ���� ��� ���� �ʿ�.
    //}

