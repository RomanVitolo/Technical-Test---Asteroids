using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;

    public ObjectPoolItem(GameObject obj, int amt, bool exp = true)
    {
        objectToPool = obj;
        amountToPool = Mathf.Max(amt,2);
        shouldExpand = exp;
    }
}