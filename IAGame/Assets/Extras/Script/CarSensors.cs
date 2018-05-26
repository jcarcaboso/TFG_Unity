using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{	
	[RequireComponent(typeof(CarController))]
	public class CarSensors : MonoBehaviour
	{
        
		public float sensor_length, angle_sensors;

		private const float HALF_HEIGTH_CAR = 4.7f, HALF_WIDTH_CAR = 0.9f;

		bool show_sensors = true;
		CarMovement movement; 

	    void Awake()
		{
			movement = new CarMovement(GetComponent<CarController>());
		}

		void FixedUpdate()
		{

			if (Input.GetKeyUp(KeyCode.I))
			{
				show_sensors = !show_sensors;
			}
			Sensors(this.transform);
		}

		void Sensors(Transform car)
		{
			RaycastHit hit;
			Vector3 sensor_pos;

			sensor_pos = car.position;
			sensor_pos += car.forward * HALF_HEIGTH_CAR;

			//Front
			if (Physics.Raycast(sensor_pos, car.transform.forward, out hit, sensor_length))
			{
				if (show_sensors)
				{
					Debug.DrawLine(sensor_pos, hit.point, Color.red);
                    
				}
			}else{
				movement.goStraigthOn();
			}

			sensor_pos += car.right * HALF_WIDTH_CAR;
			//Right
			if (Physics.Raycast(sensor_pos,
								Quaternion.AngleAxis(angle_sensors, car.transform.up) * car.transform.forward, out hit, sensor_length))
			{
				movement.turnLeft(); 
				if (show_sensors)
				{
					Debug.DrawLine(sensor_pos, hit.point, Color.yellow);
				}
			}

			sensor_pos += car.right * (-2f * HALF_WIDTH_CAR);
			//Left
			if (Physics.Raycast(sensor_pos,
								Quaternion.AngleAxis(-angle_sensors, car.transform.up) * car.transform.forward, out hit, sensor_length))
			{
				movement.turnRight();
				if (show_sensors)
				{
					Debug.DrawLine(sensor_pos, hit.point, Color.blue);
				}
			}
		}
	}
}