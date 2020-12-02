namespace Scripts.Data
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public struct GameStateSave
    {
        public Vector3 position;
        public Quaternion rotation;

        //public List<ItemData>;
        public int money;
    }
}