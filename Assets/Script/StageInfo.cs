using UnityEngine;
using System.Collections;

[System.Serializable]
public class StageInfo
{
    [System.Serializable]
    public struct EntityInfo
    {
        public int id;
        public float x;
        public float y;
        public float z;
    };
    public int stageId;
    public EntityInfo[] entityInfo;

    public StageInfo(int size) {
        entityInfo = new EntityInfo[size];
    }
}
