using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

	public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    void Update()
    {

		if(Input.GetMouseButton(1)) {
			yaw += speedH * Input.GetAxis("Mouse X");
        	pitch -= speedV * Input.GetAxis("Mouse Y");

        	transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

			if(Input.GetKey(KeyCode.W)) {
				//transform.localPosition += new Vector3(0,0,0.5f);
				transform.Translate(0, 0, 0.5f);
			}

			if(Input.GetKey(KeyCode.S)) {
				transform.Translate(0, 0, -0.5f);
			}

			if(Input.GetKey(KeyCode.A)) {
				transform.Translate(-0.5f, 0, 0);
			}

			if(Input.GetKey(KeyCode.D)) {
				transform.Translate(0.5f, 0, 0);
			}

		}

		if (Input.GetMouseButtonDown(0))
     	{

			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				//if (hitInfo.transform.gameObject.tag == "ControlPoint")
				if (hitInfo.transform.gameObject.GetComponent<PointScript>() != null)
				{
					hitInfo.transform.gameObject.GetComponent<PointScript>().Activated();
				} 
			} 
     	} 
        

    }
}
