using UnityEngine;
using UnityEngine.UI;

//by.J:230817 �ǹ� ����� ���� ����
public class IngredientSlot : MonoBehaviour
{
    public Image ingredientImage;
    //public TextMeshProUGUI ingredientName;

    public void SetIngredient(IItem production)
    {
        ingredientImage.sprite = production.ItemImage;
        //ingredientName.text = ingredient.ItemName();
    }
}
