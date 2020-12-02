using UnityEngine;

namespace Scripts.Data
{
    using System.Collections.Generic;

    [CreateAssetMenu(fileName = "item", menuName = "KPU/create item")]
    public class ItemDatabase : ScriptableObject
    {
        public List<ItemData> ItemDatas;
    }
}
