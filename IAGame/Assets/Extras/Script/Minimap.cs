using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

	GameObject minimap; 

	// Use this for initialization
	void Start () {
		minimap = GameObject.Find("MiniMapObject"); 
		//minimap.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update () {

		// if (Input.GetKeyUp(KeyCode.M))
		// {
		// 	print("hola"); 
		// 	minimap.SetActive(true); 
		// }
	}
}
