using UnityEngine;

//by.J:230719 건물 오브젝트 스크립터블
namespace JinnyBuildingData
{
    [CreateAssetMenu(fileName = "NewBuilding", menuName = "Building")]

    public class BuildingData : ScriptableObject
    {
        public string buildingName;     //이름
        public int buildingCost;        //가격
        public float buildingBuildTime; //건축 시간
    }
}
