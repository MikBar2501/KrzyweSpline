using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineScript : MonoBehaviour {

	public Transform p0,p1,p2,p3;

	public LineRenderer lineRenderer;
	
	private static int numberOfPoints = 50;
	private Vector3 [] positions = new Vector3[numberOfPoints];

	public bool mainCurve;



	void Start () {
		Transform tp0 = SplineController.controller.points[SplineController.controller.points.Count - 4];
		Transform tp1 = SplineController.controller.points[SplineController.controller.points.Count - 3];
		Transform tp2 = SplineController.controller.points[SplineController.controller.points.Count - 2];
		Transform tp3 = SplineController.controller.points[SplineController.controller.points.Count - 1];
		SetPoints(tp0,tp1,tp2,tp3);
		lineRenderer.positionCount = numberOfPoints;
		
	}
	
	void Update () {
		Draw();
	}
	private Vector3 CubicBezier(float t, Transform p0, Transform p1, Transform p2, Transform p3) {
		float u = 1-t;
		return (Mathf.Pow(u,3) * p0.position) + (3 * Mathf.Pow(u,2) * t * p1.position) + (3 * u * Mathf.Pow(t,2) * p2.position) + (Mathf.Pow(t,3) * p3.position);
	}

	private void Draw() {
		for(int i = 1; i < numberOfPoints + 1; i++) {
			float t = i / (float)numberOfPoints;
			positions[i-1] = CubicBezier(t,p0,p1,p2,p3);
		}
		lineRenderer.SetPositions(positions);
	}

	public void SetPoints(Transform p0, Transform p1, Transform p2,Transform p3) {
		this.p0 = p0;
		this.p1 = p1;
		this.p2 = p2;
		this.p3 = p3;
	}
}
