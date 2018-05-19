using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CarSpawn : MonoBehaviour {
	public int max_cars;
	public GameObject car_prefab;

	private int live_cars = 0;

	private void Awake () {
		spawn_cars ();
	}

	void FixedUpdate () {
		update_car_count ();
	}

	private void spawn_cars () {
		const float MAX_DIST = 14f;
		GameObject new_car;
		int fila = 0;
		Vector3 actual_pos = transform.position;

		for (int car_number = 0; car_number < max_cars; car_number++) {
			if (car_number % 4 == 0) {
				//Add max_dist to Z axis 
				if (fila != 0) {
					actual_pos.z += MAX_DIST;
				}
				fila++;
				actual_pos.x = transform.position.x - MAX_DIST;
			} else {
				actual_pos.x = transform.position.x + MAX_DIST / 2;
			}

			new_car = Instantiate (car_prefab) as GameObject;
			new_car.transform.parent = transform;
			new_car.transform.position = actual_pos;
		}

	}

	private void update_car_count () {
		GameObject[] cars;
		Text cars_number;

		cars = GameObject.FindGameObjectsWithTag ("Car");
		live_cars = cars.Length;

		cars_number = GameObject.Find ("Cars counter").GetComponent<Text> ();
		cars_number.text = "Cars: " + live_cars;

	}

}