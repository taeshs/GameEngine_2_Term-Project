using Scenes.Data;

namespace Scenes.Inventory.Scripts
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "usable_item", menuName = "KPU/사용가능 아이템 데이터 생성하기.")]
    
    public class UsableItem : ItemData
    {
        // 사용했을 때 발동되는 이벤트의 이름.
        public string eventName;
    }
}
