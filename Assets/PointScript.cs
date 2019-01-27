using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour {

	bool isActive = false;
	Renderer myRenderer;

	void Start () {
		myRenderer = GetComponent<Renderer>();
	}

	void Update () {
		if(isActive) {
			if(Input.GetKey(KeyCode.UpArrow)) {
				transform.position += new Vector3(0,0,0.01f);
			}
			if(Input.GetKey(KeyCode.DownArrow)) {
				transform.position += new Vector3(0,0,-0.01f);
			}
			if(Input.GetKey(KeyCode.RightArrow)) {
				transform.position += new Vector3(0.01f,0,0);
			}
			if(Input.GetKey(KeyCode.LeftArrow)) {
				transform.position += new Vector3(-0.01f,0,0);
			}

			if(Input.GetKey(KeyCode.PageUp)) {
				transform.position += new Vector3(0,0.01f,0);
			}
			if(Input.GetKey(KeyCode.PageDown)) {
				transform.position += new Vector3(0,-0.01f,0);
			}
		}
		
	}

	public void Activated() {
		PointScript [] points = GameObject.FindObjectsOfType<PointScript>();
		for(int i = 0; i< points.Length; i++) {
			points[i].Deactivated();
		}

		Color colorEmi = Color.cyan;
		myRenderer.material.SetColor("_Color",Color.cyan);
		isActive = true;

	}

	public void Deactivated() {
		Color colorEmi = Color.white;
		myRenderer.material.SetColor("_Color",Color.white);
		isActive = false;
	}


}
