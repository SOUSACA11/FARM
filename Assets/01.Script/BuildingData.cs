using UnityEngine;

//by.J:230719 �ǹ� ������Ʈ ��ũ���ͺ�
namespace JinnyBuildingData
{
    [CreateAssetMenu(fileName = "NewBuilding", menuName = "Building")]

    public class BuildingData : ScriptableObject
    {
        public string buildingName;     //�̸�
        public int buildingCost;        //����
        public float buildingBuildTime; //���� �ð�
    }
}
