using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	public static ObjectPooler Instance;
	
	public List<ObjectPoolItem> itemsToPool;
	public List<List<GameObject>> pooledObjectsList;
	private List<GameObject> pooledObjects;
	private List<int> positions;

	void Awake()
	{
		Instance = this;

		InitialPoolSettings();
	}

	private void InitialPoolSettings()
	{
		pooledObjectsList = new List<List<GameObject>>();
		pooledObjects = new List<GameObject>();
		positions = new List<int>();

		for (int i = 0; i < itemsToPool.Count; i++)
		{
			ObjectPoolItemToPooledObject(i);
		}
	}

	//The way to call the different GameObject (by index) can be a future improvement in code.
	public GameObject GetPooledObject(int index)
	{
		int curSize = pooledObjectsList[index].Count;
		for (int i = positions[index] + 1; i < positions[index] + pooledObjectsList[index].Count; i++)
		{

			if (!pooledObjectsList[index][i % curSize].activeInHierarchy)
			{
				positions[index] = i % curSize;
				return pooledObjectsList[index][i % curSize];
			}
		}

		if (itemsToPool[index].shouldExpand)
		{

			GameObject obj = (GameObject)Instantiate(itemsToPool[index].objectToPool);
			obj.SetActive(false);
			obj.transform.parent = this.transform;
			pooledObjectsList[index].Add(obj);
			return obj;

		}
		return null;
	}

	public List<GameObject> GetAllPooledObjects(int index)
	{
		return pooledObjectsList[index];
	}


	//This method is used to dynamically add objects.
	//For example, if in the future it is implemented that the Asteroids instantiate smaller asteroids.
	//Thanks to this method we could add them to the pool already created. 
	public int AddObject(GameObject GO, int amt = 3, bool exp = true)
	{
		ObjectPoolItem item = new ObjectPoolItem(GO, amt, exp);
		int currLen = itemsToPool.Count;
		itemsToPool.Add(item);
		ObjectPoolItemToPooledObject(currLen);
		return currLen;
	}


	void ObjectPoolItemToPooledObject(int index)
	{
		ObjectPoolItem item = itemsToPool[index];

		pooledObjects = new List<GameObject>();
		for (int i = 0; i < item.amountToPool; i++)
		{
			GameObject obj = (GameObject)Instantiate(item.objectToPool);
			obj.SetActive(false);
			obj.transform.parent = this.transform;
			pooledObjects.Add(obj);
		}
		pooledObjectsList.Add(pooledObjects);
		positions.Add(0);

	}
}