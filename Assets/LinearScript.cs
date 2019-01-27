using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearScript : MonoBehaviour {

	public LineRenderer lineRenderer;
	private int numberOfPoints = 50;
	private Vector3 [] positions = new Vector3[50];
	public Transform p0,p1;

	void Start () {
		
		lineRenderer.positionCount = numberOfPoints;
	}
	
	void Update () {
		Draw();
	}

	private Vector3 LinearBezier(float t, Vector3 p0, Vector3 p1) {
		return p0 + t *(p1 - p0);
	}

	private void Draw() {
		for(int i = 1; i < numberOfPoints + 1; i++) {
			float t = i / (float)numberOfPoints;
			positions[i-1] = LinearBezier(t,p0.position, p1.position);
		}
		lineRenderer.SetPositions(positions);
	}

	public void SetPoints(Transform p0, Transform p1) {
		this.p0 = p0;
		this.p1 = p1;
	}
}
