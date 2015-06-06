using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AngleController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	public Image angleFace;
	public RectTransform angleDesired;
	public RectTransform angleCurrent;
	
	private Vector2 pivotPoint = new Vector2(0,0);
	
	private bool mouseDown;
	private Vector3 clickMousePos;
	private Vector3 clickPos;
	
	
	void Start () {
	}
	
	void Update () {
		
	}
	
	void LateUpdate(){
		rotateCurrentAngleNeedle ();
		rotateDesiredAngleNeedle ();
	}
	
	public void OnPointerDown(PointerEventData ped){
		setDesiredAngle (ped);
	}
	
	public void OnPointerUp(PointerEventData ped){
		
	}
	
	void rotateCurrentAngleNeedle(){
		angleCurrent.transform.rotation = Quaternion.Euler(0, 0, -CourseInfo.currentAngle-90);
	}
	
	void rotateDesiredAngleNeedle(){
		angleDesired.transform.rotation = Quaternion.Euler (0, 0, -CourseInfo.desiredAngle-90);
	}
	
	void setDesiredAngle(PointerEventData ped)
	{
		Vector2 localCursor;
		if (!RectTransformUtility.ScreenPointToLocalPointInRectangle (GetComponent<RectTransform> (), ped.position, ped.pressEventCamera, out localCursor)) {
			return;
		}
		
		Vector2 mouseVec = localCursor - pivotPoint;
		float angle = Mathf.Atan2 (mouseVec.y, mouseVec.x);
		float degrees = angle * Mathf.Rad2Deg;
		
		if (degrees < 0) {
			degrees = degrees + 360;
		}
		degrees = (((degrees)-360)*(-1));

		CourseInfo.desiredAngle = degrees;
	}
}
