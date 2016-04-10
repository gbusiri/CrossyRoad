using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

	float lerpTime;
	float currentLerpTime;
	float perc = 1;

	bool firstInput;
	public bool justJump;

	Vector3 startPos, endPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right"))
		{
			if (perc == 1)
			{
				lerpTime = 1;
				currentLerpTime = 0;
				firstInput = true;
				justJump = true;
			}
		}

		startPos = gameObject.transform.position;

		if (Input.GetButtonDown("right") && gameObject.transform.position == endPos)
		{
			endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
		}
		if (Input.GetButtonDown("left") && gameObject.transform.position == endPos)
		{
			endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
		}
		if (Input.GetButtonDown("up") && gameObject.transform.position == endPos)
		{
			endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
		}
		if (Input.GetButtonDown("down") && gameObject.transform.position == endPos)
		{
			endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
		}

		if(firstInput)
		{
			currentLerpTime += Time.deltaTime  * 5;
			perc = currentLerpTime / lerpTime;
			gameObject.transform.position = Vector3.Lerp(startPos, endPos, perc);
			if (perc > 0.8)
			{
				perc = 1;
			}
			if(Mathf.Round(perc) == 1)
			{
				justJump = false;
			}
		}
		
	}
}
