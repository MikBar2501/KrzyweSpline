using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplineController : MonoBehaviour {

	public static SplineController controller;
	public List<Transform> points = new List<Transform>();
	public List<GameObject> lines = new List<GameObject>();

	public Text instruction;
	public Transform point;
	public GameObject splineCubic;
	public GameObject line;

	public bool mainScript = true;

	bool hide = false;

	void Start () {
		controller = this;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			AddSpline();
		}
		if(Input.GetKeyDown(KeyCode.H)) {
			HideEverything();
		}

		if(Input.GetKeyDown(KeyCode.I)) {
			HideInstruction();
		}
	}

	public void AddSpline() {
		points.Add(Instantiate(point, new Vector3(points[points.Count - 1].position.x + 2, points[points.Count - 1].position.y, points[points.Count - 1].position.z), Quaternion.identity));
		points.Add(Instantiate(point, new Vector3(points[points.Count - 1].position.x + 2, points[points.Count - 1].position.y, points[points.Count - 1].position.z), Quaternion.identity));
		points.Add(Instantiate(point, new Vector3(points[points.Count - 1].position.x + 2, points[points.Count - 1].position.y, points[points.Count - 1].position.z), Quaternion.identity));
		Instantiate(splineCubic,new Vector3(points[points.Count - 1].position.x + 2, points[points.Count - 1].position.y, points[points.Count - 1].position.z), Quaternion.identity);
		
		lines.Add(Instantiate(line,new Vector3(points[points.Count - 1].position.x + 2, points[points.Count - 1].position.y, points[points.Count - 1].position.z), Quaternion.identity));
		lines.Add(Instantiate(line,new Vector3(points[points.Count - 1].position.x + 2, points[points.Count - 1].position.y, points[points.Count - 1].position.z), Quaternion.identity));

		lines[lines.Count - 2].GetComponent<LinearScript>().SetPoints(points[points.Count - 4].transform, points[points.Count - 3].transform);
		lines[lines.Count - 1].GetComponent<LinearScript>().SetPoints(points[points.Count - 2].transform, points[points.Count - 1].transform);
	}

	void HideEverything() {
		if(hide) {
			hide = false;
			foreach(Transform point in points) {
				point.GetComponent<MeshRenderer>().enabled = hide;
			}

			foreach(GameObject line in lines) {
				line.GetComponent<LineRenderer>().enabled = hide ;
			}
		} else {
			hide = true;
			foreach(Transform point in points) {
				point.GetComponent<MeshRenderer>().enabled = hide;
			}

			foreach(GameObject line in lines) {
				line.GetComponent<LineRenderer>().enabled = hide ;
			}
		}
	}

	void HideInstruction() {
		if(instruction.enabled == true) {
			instruction.enabled = false;
		} else {
			instruction.enabled = true;
		}
	}

}
