using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JinnyProcessItem;
using UnityEngine.UI;

//by.J:230817 �ǹ��� ����� �ִ� UI / ����� â �̵�
public class IngredientUI : MonoBehaviour
{
    public Image image;            //������ ���� â �̹��� 
    public Vector3 endPosition;    //������ �̵� ��ġ
    public float speed = 120f;     //�̵� �ӵ�
    private Vector3 startPosition; //������ġ


    public static IngredientUI Instance;
    public IngredientSlot[] ingredientSlots; //����� ����
    public Recipe specificRecipe; //������

    private void Awake()
    {
        Debug.Log("����� ��ũ��Ʈ");
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //�ǹ� ������ Ŭ��
    public void IngredientClick()
    {
        Debug.Log("����� ���");

        // Ray�� ĳ�����Ͽ� � �ǹ��� Ŭ���Ǿ����� Ȯ���մϴ�.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        GameObject clickedBuilding = null;
        if (hit.collider != null)
        {
            Debug.Log("��?");
            clickedBuilding = hit.collider.gameObject;
        }

        if (clickedBuilding == null) return; // Ŭ���� �ǹ��� ������ ��ȯ

        // SpriteRenderer�� ����Ͽ� Ŭ���� �ǹ��� ũ��� ��ġ�� �����ɴϴ�.
        SpriteRenderer buildingRenderer = clickedBuilding.GetComponent<SpriteRenderer>();
        if (buildingRenderer != null)
        {
            Debug.Log("��22?");
            Bounds buildingBounds = buildingRenderer.bounds;

            // �ǹ��� ��� �𼭸� ��ġ�� ����մϴ�.
            Vector3 targetPosition = new Vector3(buildingBounds.max.x, buildingBounds.max.y, 0);

            // UIâ�� ��ġ�� �ǹ��� �𼭸��� �°� �����մϴ�.
            transform.position = Camera.main.WorldToScreenPoint(targetPosition);
        }

        ShowIngredient(specificRecipe);
        
        //����� â ��� Ȱ��ȭ
        StartCoroutine(MoveImageUp());
    }

    //������ �� ����� �����ֱ�
    public void ShowIngredient(Recipe recipe)
    {
        Debug.Log("����� �Լ���");
        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            if (i < recipe.ingredients.Count)
            {
                object ingredientObj = recipe.ingredients[i];

                if (ingredientObj is Ingredient<IItem> itemIngredient)
                {
                    ingredientSlots[i].SetIngredient(itemIngredient.item);
                    ingredientSlots[i].gameObject.SetActive(true);
                }
                else if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
                {
                    ingredientSlots[i].SetIngredient(new ProcessItemIItem(processedIngredient.item));
                    ingredientSlots[i].gameObject.SetActive(true);
                }
                else
                {
                    ingredientSlots[i].gameObject.SetActive(false);
                }
            }
            else
            {
                ingredientSlots[i].gameObject.SetActive(false);
            }
        }
    }


    // *UI �̹��� ������ ó��*

    //�ۿ� �ִ� ����� â ȭ��� ��ġ
    IEnumerator MoveImageUp()
    {
        //ó�� y��    : -846
        //������ y��  : 318

        float t = 0f; //�ð� ����

        Vector3 startPosition = image.transform.position;  //���� ��ġ ����

        endPosition = new Vector3(948, image.rectTransform.position.y + 1150, 0); //������ ��ġ ����

        while (t < 1f) //t�� 1�� �� ������
        {
            if (image.rectTransform.position.y >= 318) //y���� 318 �̻��̸� ����
            {
                yield break;
            }

            t += Time.deltaTime * speed; //�ð� ����

            //Lerp�� �̿��� ���� ��ġ���� endPosition���� �ε巴�� �̵�
            image.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null; //������ ���ݴ�� ����
        }
    }

}
