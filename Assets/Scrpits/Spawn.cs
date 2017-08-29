using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

	GameObject spawnPoint;
	GameObject selectedShape;
	public GameObject[] shapesArray;
	float timeInterval = .1f;


	// Use this for initialization
	void Start()
	{
		spawnPoint = this.gameObject;
		SpawnManager spawnManager = transform.parent.GetComponent<SpawnManager>();
		shapesArray = spawnManager.shapes;
	}

	// Update is called once per frame
	void Update()
	{
		SpawnShape();
	}

	void ShapeManager()
	{
		Destroy(selectedShape);

		int shape = Random.Range(0, (shapesArray.Length));
		selectedShape = Instantiate(shapesArray[shape], spawnPoint.transform.position, Quaternion.identity);
		selectedShape.transform.SetParent(spawnPoint.transform);
		Debug.Log("A " + selectedShape + " has spawned");
	}

	void SpawnShape()
	{
		timeInterval -= Time.deltaTime;
		if (timeInterval <= 0)
		{
			ShapeManager();
			timeInterval = .8f;
		}
	}
}