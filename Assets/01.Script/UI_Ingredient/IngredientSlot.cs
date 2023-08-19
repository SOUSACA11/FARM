using UnityEngine;
using UnityEngine.UI;
using TMPro;

//by.J:230817 �ǹ� ����� ���� ����
public class IngredientSlot : MonoBehaviour
{
    public Image ingredientImage; //����� �̹���
    public TextMeshProUGUI ingredientQuantity; //����� ����

    public void SetIngredient(IItem production, int quantity)
    {
        ingredientImage.sprite = production.ItemImage;
        ingredientQuantity.text = quantity.ToString();

        //Debug.Log("Setting ingredient: " + production.ItemName());
    }
}
