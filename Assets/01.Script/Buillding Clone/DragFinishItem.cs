using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//by.J:230827 �ϼ������� �̹��� �巡�� ��� ���
public class DragFinishItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   // public Transform originalParent;
    private Vector3 startPosition;
    private GameObject clonedImage;


    public DragAndDropCamera cameraDragScript; //ī�޶� �巡�� ���
    public IngredientManagerUI ingredientManagerUI; //����� â
    //public GameObject clonedImage; //������ �ϼ�ǰ �̹���

    public int index = -1;

    private void Start()
    {
        // ī�޶��� DragAndDropCamera ��ũ��Ʈ�� ���
        cameraDragScript = Camera.main.GetComponent<DragAndDropCamera>();

        // IngredientManagerUI�� ���� ���� (���� IngredientManagerUI�� ���� ������Ʈ�� ������)
        ingredientManagerUI = GetComponent<IngredientManagerUI>();
    }

    //�巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("�ϼ�ǰ �̹��� �巡�� ����");

        // ���� �̹����� raycastTarget�� ��Ȱ��ȭ
        GetComponent<Image>().raycastTarget = false;
         
        if (cameraDragScript != null)
        {
            cameraDragScript.NoDrag();  // �巡�� ���۽� ī�޶� �巡�� ��Ȱ��ȭ
        }
        Debug.Log($"ingredientManagerUI: {ingredientManagerUI}, index: {index}");

        //// ������ �̹��� ����
        //clonedImage = Instantiate(gameObject, transform.position, transform.rotation, transform.root);
        //Image clonedImageComp = clonedImage.GetComponent<Image>();
        //if (clonedImageComp != null)
        //{
        //    Debug.Log("�̹��� ����");
        //    clonedImageComp.raycastTarget = false;  // ������ �̹����� raycastTarget�� ��Ȱ��ȭ�Ͽ� Ŭ�� �̺�Ʈ�� ������ ���� �ʵ��� ��
        //}


        //// ������ �̹��� ����
        //clonedImage = Instantiate(gameObject, transform.position, transform.rotation, transform.root);
        //Image originalImageComp = GetComponent<Image>();
        //Image clonedImageComp = clonedImage.GetComponent<Image>();
        //if (originalImageComp != null && clonedImageComp != null)
        //{
        //    clonedImageComp.sprite = originalImageComp.sprite; // Sprite ����
        //    clonedImageComp.color = originalImageComp.color;   // Color ����
        //    clonedImageComp.raycastTarget = false;  // ������ �̹����� raycastTarget�� ��Ȱ��ȭ
        //}



        //// ������ �̹��� ����
        //clonedImage = Instantiate(gameObject, transform.position, transform.rotation);
        //// ���� ĵ������ ã�Ƽ� clonedImage�� �θ�� ����
        //Canvas mainCanvas = FindObjectOfType<Canvas>();
        //if (mainCanvas)
        //{
        //    clonedImage.transform.SetParent(mainCanvas.transform, false);
        //    clonedImage.transform.SetAsLastSibling();  // Ȯ���ϰ� ������ �ڽ����� ����
        //}
        //clonedImage.transform.SetAsLastSibling();  // Ȯ���ϰ� ������ �ڽ����� ����

        //Image originalImageComp = GetComponent<Image>();
        //Image clonedImageComp = clonedImage.GetComponent<Image>();
        //if (originalImageComp != null && clonedImageComp != null)
        //{
        //    clonedImageComp.sprite = originalImageComp.sprite; // Sprite ����
        //    clonedImageComp.color = originalImageComp.color;   // Color ����
        //    clonedImageComp.raycastTarget = false;  // ������ �̹����� raycastTarget�� ��Ȱ��ȭ
        //}



        // ������ �̹��� ����
        clonedImage = Instantiate(gameObject, transform.position, transform.rotation);
        // ���� ĵ������ ã�Ƽ� clonedImage�� �θ�� ����
        Canvas mainCanvas = FindObjectOfType<Canvas>();
        if (mainCanvas)
        {
            clonedImage.transform.SetParent(mainCanvas.transform, false);
            clonedImage.transform.SetAsLastSibling();  // Ȯ���ϰ� ������ �ڽ����� ����
        }
        clonedImage.transform.SetAsLastSibling();  // Ȯ���ϰ� ������ �ڽ����� ����

        Image originalImageComp = GetComponent<Image>();
        Image clonedImageComp = clonedImage.GetComponent<Image>();
        if (originalImageComp != null && clonedImageComp != null)
        {
            clonedImageComp.sprite = originalImageComp.sprite; // Sprite ����
            clonedImageComp.color = originalImageComp.color;   // Color ����
            clonedImageComp.raycastTarget = false;  // ������ �̹����� raycastTarget�� ��Ȱ��ȭ
        }
        // ���� �̹����� ����
        GetComponent<Image>().enabled = false;

        // ���� �̹����� raycastTarget�� ��Ȱ��ȭ
        GetComponent<Image>().raycastTarget = false;



        // ���⼭ IngredientManagerUI�� ProductImageClicked�� ȣ���մϴ�.
        if (ingredientManagerUI != null)
        {
            Debug.Log("����� â �ҷ����� ����");
            ingredientManagerUI.ProductImageClicked(index);
        }

        //originalParent = transform.parent;
        startPosition = transform.position;
        //transform.SetParent(transform.root);  // �ֻ��� �θ�� ����
    }

    //�巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition;

        if (clonedImage != null)
        {
            clonedImage.transform.position = Input.mousePosition;
        }

    }

    //�巡�� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�ϼ�ǰ �̹��� �巡�� ��");

        // ������ �̹��� �ı�
        if (clonedImage != null)
        {
            Destroy(clonedImage);
        }

        if (cameraDragScript != null)
        {
            cameraDragScript.OkDrag();  // �巡�� ����� ī�޶� �巡�� Ȱ��ȭ
        }

        //���� �̹����� �ٽ� ǥ��
        GetComponent<Image>().enabled = true;

        // ���� �̹����� raycastTarget�� �ٽ� Ȱ��ȭ
        GetComponent<Image>().raycastTarget = true;



        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.GetComponent<WorkBuilding>())
        {
            // WorkBuilding�� StartProduction() �޼��� ȣ��
            hit.collider.GetComponent<WorkBuilding>().StartProduction();
        }
        else
        {
            // �ٽ� ���� ��ġ�� ���ư���
            transform.position = startPosition;
            //transform.SetParent(originalParent);
        }


        // ���� �̹����� raycastTarget�� �ٽ� Ȱ��ȭ
        GetComponent<Image>().raycastTarget = true;
    }
}