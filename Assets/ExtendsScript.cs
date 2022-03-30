using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendsScript : MonoBehaviour
{
public GameObject landscape;

Vector3 topFrontLeft;
Vector3 topFrontRight;
Vector3 topBackLeft;
Vector3 topBackRight;
Vector3 bottomFrontLeft;
Vector3 bottomFrontRight;
Vector3 bottomBackLeft;
Vector3 bottomBackRight;

Vector3[] corners;
Bounds bounds;

void Start() {
	// MeshFilter mf = landscape.GetComponent(MeshFilter);
	bounds = landscape.GetComponent<Collider>().bounds;
	corners = new Vector3[8];
    // InvokeRepeating("DrawRaycasts", 0.25f, 0.25f);
}
void Update () {
	UpdateCorners();
    DrawBoundingBox();
    DrawRaycasts();
}


void UpdateCorners() {
	topFrontRight = bounds.center + bounds.extents;
	topFrontLeft = bounds.center + Vector3.Scale(bounds.extents, new Vector3(-1, 1, 1));
	topBackRight = bounds.center + Vector3.Scale(bounds.extents, new Vector3(1, 1, -1));
	topBackLeft = bounds.center + Vector3.Scale(bounds.extents, new Vector3(-1, 1, -1));
	bottomFrontRight = bounds.center + Vector3.Scale(bounds.extents, new Vector3(1, -1, 1));
	bottomFrontLeft = bounds.center + Vector3.Scale(bounds.extents, new Vector3(-1, -1, 1));
	bottomBackRight = bounds.center + Vector3.Scale(bounds.extents, new Vector3(1, -1, -1));
	bottomBackLeft = bounds.center + Vector3.Scale(bounds.extents, new Vector3(-1, -1, -1));
}

void DrawRaycasts(){
    Vector3 randomPoint = GetRandomPointBetweenExtents();
    Debug.DrawLine(randomPoint, randomPoint - Vector3.up*5, Color.red);
}

Vector3 GetRandomPointBetweenExtents(){
    Vector3 randomPoint = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
    return randomPoint;
}

void DrawBoundingBox(){
    Debug.DrawLine(topFrontLeft, topFrontRight);
	// Debug.DrawLine(bottomFrontLeft, bottomFrontRight);
	Debug.DrawLine(topBackLeft, topBackRight);
	// Debug.DrawLine(bottomBackLeft, bottomBackRight);
	Debug.DrawLine(topFrontLeft, topBackLeft);
	Debug.DrawLine(topFrontRight, topBackRight);
	// Debug.DrawLine(bottomFrontLeft, bottomBackLeft);
	// Debug.DrawLine(bottomFrontRight, bottomBackRight);
	// Debug.DrawLine(topFrontLeft, bottomFrontLeft);
	// Debug.DrawLine(topFrontRight, bottomFrontRight);
	// Debug.DrawLine(topBackLeft, bottomBackLeft);
	// Debug.DrawLine(topBackRight, bottomBackRight);
}

}
