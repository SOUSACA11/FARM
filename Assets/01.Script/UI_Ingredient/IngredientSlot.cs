using UnityEngine;
using UnityEngine.UI;

//by.J:230817 �ǹ� ����� ���� ����
public class IngredientSlot : MonoBehaviour
{
    public Image ingredientImage;
    //public TextMeshProUGUI ingredientName;

    public void SetIngredient(IItem ingredient)
    {
        ingredientImage.sprite = ingredient.ItemImage;
        //ingredientName.text = ingredient.ItemName();
    }
}
