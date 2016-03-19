using UnityEngine;
using System.Collections;
using System.IO;

public class DungeonPopulator : MonoBehaviour {
	private int currentSize=0;
	private int finalSize=40; //arbitrary but this will work for now

	void Start () {
		Build(GameObject.FindGameObjectsWithTag("buildable"), finalSize);
	}
	
	void Update () {
	}

	/* Recursive method for constructing the dungeon module-by-module. Takes in a number of modules and a list of unconnected JoinPOints and calls itself until the whole dungeon is fleshed out. */
	void Build(GameObject[] unconnectedPaths, int size) {
		foreach (GameObject path in unconnectedPaths) {
			foreach (Transform joinPoint in path.transform) {
				if (joinPoint.gameObject.name == "JoinPoint") {
					addModule(joinPoint);
					DestroyImmediate(joinPoint.gameObject);
				}
			}
		}

		if (currentSize < finalSize) {
			GameObject[] paths = GameObject.FindGameObjectsWithTag("buildable");
			int newSize = size - currentSize;
			Debug.Log(currentSize);
			Build(paths, newSize);
		}

		else if (currentSize >= finalSize) {
			foreach (GameObject path in unconnectedPaths)
				capOff(path);
		}
	}

	/* Instantiates a new module (room, hall, or juncture) at a JoinPoint according to these rules: halls must always connect to either junctures or rooms, rooms and junctures must always connect to halls */
	void addModule(Transform joinPoint) {
		string typeToBuild = "";
		string joinType = joinPoint.gameObject.tag;
		Vector3 point = joinPoint.position;

		if (joinType == "juncture" || joinType == "room") {
			Instantiate((GameObject)Resources.Load("Prefabs/hall/" + Random.Range(1, 4)), point, joinPoint.rotation);
			joinPoint.tag = "built";
		}

		else if (joinType == "hall") {
			if (Random.value < 0.5f)
				typeToBuild = "room";
			else typeToBuild = "juncture";
			Instantiate((GameObject)Resources.Load("Prefabs/" + typeToBuild + "/" + Random.Range(2, 4) + "way/" + Random.Range(1, 3)), point, joinPoint.rotation);
			joinPoint.tag = "built";
		}

		currentSize++;
		Debug.Log("NUMBER OF MODULES: " + currentSize);
	}

	/* Adds a treasure/boss room at the end of the chain of modules */
	void capOff(GameObject path) {
		//lol I'll do this later
	}
}
