using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CompassController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	public Image compassFace;
	public RectTransform compassDesired;
	public RectTransform compassCurrent;
	
	private Vector2 pivotPoint = new Vector2(0,0);

	private bool mouseDown;
	private Vector3 clickMousePos;
	private Vector3 clickPos;


	void Start () {
	}

	void Update () {

	}

	void LateUpdate(){
		rotateCurrentHeadingNeedle ();
		rotateDesiredHeadingNeedle ();
	}

	public void OnPointerDown(PointerEventData ped){
		setDesiredHeading (ped);
	}
	
	public void OnPointerUp(PointerEventData ped){

	}

	void rotateCurrentHeadingNeedle(){
		compassCurrent.transform.rotation = Quaternion.Euler(0, 0, -CourseInfo.currentHeading);
	}

	void rotateDesiredHeadingNeedle(){
		compassDesired.transform.rotation = Quaternion.Euler (0, 0, -CourseInfo.desiredHeading);
	}

	void setDesiredHeading(PointerEventData ped)
	{
		Vector2 localCursor;
		if (!RectTransformUtility.ScreenPointToLocalPointInRectangle (GetComponent<RectTransform> (), ped.position, ped.pressEventCamera, out localCursor)) {
			return;
		}

		Vector2 mouseVec = localCursor - pivotPoint;
		float angle = Mathf.Atan2 (mouseVec.y, mouseVec.x);
		float degrees = angle * Mathf.Rad2Deg-90;

		if (degrees < 0) {
			degrees = degrees + 360;
		}
		degrees = (((degrees)-360)*(-1));

		CourseInfo.desiredHeading = degrees;
	}
}
