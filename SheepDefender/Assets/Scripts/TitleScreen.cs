﻿using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
	public GameObject effectFlare;
	public GameObject pressKeyText;
	public GameObject gameLogo;
	Vector3 endPointForFlare = new Vector3 (39.67602f, 9.015059f, 591.6068f);//The end point of the flare's movement
	bool flareReturning = false;//used to store the direction towards which the flare is going.
	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("MoveFlare", 0, 0.1f);//Starts the flare's movement
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.anyKeyDown) {//Close the title and show the level menu
			pressKeyText.SetActive(false);
			gameLogo.SetActive(false);
			effectFlare.SetActive(false);
			CancelInvoke();//MoveFlare won't be called again
			gameObject.GetComponent<LevelMenu>().enabled = true;
		}
	}
	
	void MoveFlare ()//Moves the flare from one direction to another
	{
		effectFlare.transform.position = Vector3.MoveTowards (effectFlare.transform.position, endPointForFlare, 0.2f);
		if (effectFlare.transform.position == endPointForFlare) {
			if (flareReturning) {
				endPointForFlare = new Vector3 (39.67602f, 9.015059f, 591.6068f);
				flareReturning = false;
			} else {
				endPointForFlare = new Vector3 (39.67602f, 9.015059f, 615.2715f);
				flareReturning = true;
			}
		}
	}
}
