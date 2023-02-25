using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericPooler : MonoBehaviour {
	
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = true;
	
	public List<GameObject> listPooledObjects;
	
	public static GenericPooler instance;
	// Use this for initialization
	void Start () {
		instance = this;
		
		listPooledObjects = new List<GameObject>();
		
//		for (int i = 0; i < pooledAmount; i++) {
//			GameObject clone = Instantiate(pooledObject) as GameObject;
//			clone.SetActive(false);
//			listPooledObjects.Add(clone);
//		}
	}

	public void CreatePool () {
		for (int i = 0; i < pooledAmount; i++) {
			GameObject clone = Instantiate(pooledObject) as GameObject;
			clone.SetActive(false);
			listPooledObjects.Add(clone);
		}
	}
	
	public GameObject GetPooledObject () {
		
		for(int i = 0; i < listPooledObjects.Count; i++) {
			
			if(!listPooledObjects[i].activeInHierarchy) {
				return listPooledObjects[i];
			}
		}
		
		if(willGrow) {
			GameObject clone = Instantiate(pooledObject) as GameObject;
			listPooledObjects.Add(clone);
			return clone;
		}
		
		return null;
	}
	
}