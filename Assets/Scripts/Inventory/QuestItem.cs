using Scenes.Data;

namespace Scenes.Inventory.Scripts
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "quest_item", menuName = "KPU/퀘스트 아이템 데이터 생성하기.")]
    public class QuestItem : ItemData
    {
        // 사용되어야 할 퀘스트의 이름.
        public string questName;
    }
}
