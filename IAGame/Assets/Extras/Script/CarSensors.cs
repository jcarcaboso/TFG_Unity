    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CarSensors : MonoBehaviour {

    		public float sensor_length, angle_sensors;

    		private const float HALF_CAR = 2.25f;

        		//GameObject car;
    		bool show_sensors = true;

    		private void Awake () {
    		    //car.transform = this.gameObject; 
    		}

    		void FixedUpdate () {

    			if (Input.GetKeyUp (KeyCode.I)) {
    				show_sensors = !show_sensors;
    			}
    		Sensors (this.transform);
    		}

    	    void Sensors (Transform car) {
    			RaycastHit hit;
    		    Vector3 sensor_start_pos = car.position; 
            
    			//sensor_start_pos.z += HALF_CAR;
    			//sensor_start_pos.y += 1;

    			//Front
    			if (Physics.Raycast (sensor_start_pos, car.transform.forward, out hit, sensor_length)) {
    				if (show_sensors) {
    					Debug.DrawLine (sensor_start_pos, hit.point);
    				}
    			} 
            
    			sensor_start_pos.x += -3f;
    			//Right
    			if (Physics.Raycast (sensor_start_pos, car.transform.forward, out hit, sensor_length)) {
    				if (show_sensors) {
    					Debug.DrawLine (sensor_start_pos, hit.point);
    				}
    			}
    			
    			//Right angle
    			if (Physics.Raycast (sensor_start_pos, Quaternion.AngleAxis (angle_sensors, car.transform.up) * car.transform.forward, out hit, sensor_length)) {
    				if (show_sensors) {
    					Debug.DrawLine (sensor_start_pos, hit.point);
    				}
    			}

    			//sensor_start_pos.x += 3f;
    		    //sensor_start_pos.z -= 3f;
    			////Left
    			//if (Physics.Raycast (sensor_start_pos, car.transform.forward, out hit, sensor_length)) {
    			//	if (show_sensors) {
    			//		Debug.DrawLine (sensor_start_pos, hit.point);
    			//	}
    			//}

    			////Left angle
    			//if (Physics.Raycast (sensor_start_pos, Quaternion.AngleAxis (-angle_sensors, car.transform.up) * car.transform.forward, out hit, sensor_length)) {
    			//	if (show_sensors) {
    			//		Debug.DrawLine (sensor_start_pos, hit.point);
    			//	}
    			//} 
    		}
    	
    }