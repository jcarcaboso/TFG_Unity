using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	public class CarMovement : MonoBehaviour
	{
		private CarController car; // the car controller we want to use
        
		public CarMovement(CarController car){
			this.car = car;
		}

        //private void Awake()
        //{
        //    // get the car controller
        //    m_Car = GetComponent<CarController>();
		//}

		public void goStraigthOn(){
			car.Move(0f, 0.8f, 0.8f, 0f);	
		}

		public void turnLeft(){
			car.Move(-0.7f, 0.1f, 0.1f, 1f);
		}
        
		public void turnRight()
        {
            car.Move(0.7f, 0.1f, 0.1f, 1f);
        }
		public void reverse()
        {
            car.Move(0f, -0.8f, -0.8f, 0f);
        }
	}

}
