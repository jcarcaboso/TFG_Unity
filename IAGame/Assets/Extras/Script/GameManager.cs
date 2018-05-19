using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	GameObject minimap; 

	// Use this for initialization
	void Start () {
		minimap = GameObject.Find("MiniMapObject"); 
		minimap.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.M))
		{
			minimap.SetActive(!minimap.activeSelf); 
		}
	}
}
