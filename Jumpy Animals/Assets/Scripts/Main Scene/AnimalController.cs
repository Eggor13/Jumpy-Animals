using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour {

	Animator anim;
	[SerializeField]
	float Timer = 1f;
	int score;
	[SerializeField]
	Text Score;

	bool Play = true;

	Coroutine counter;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		Score.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		if (Play){
		#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			SetJump();
		}
		#else
		if (Input.touchCount>0 && Input.GetTouch(0))
		{
		SetJump();
		}
		#endif
		}
	}


	public void LandingEvent()
	{
		// count score;
		score+=15;
		//display
		Score.text = score.ToString();
		//start count for loose;
		counter = StartCoroutine(StartCount());
	}

	IEnumerator StartCount()
	{
		yield return null;
		for (float timer = 0; timer < Timer; timer+=Time.deltaTime)
		{
			yield return new WaitForSeconds(Time.deltaTime);
		}
		//time is over so you lose;
		gameOver();
	}


	/// <summary>
	/// Game is over.
	/// wright some code here (display banner or something)
	/// </summary>
	void gameOver()
	{
		Score.text = "GameOver";
		//stop input;
		Play = false;
	}

	void SetJump()
	{
		if (counter!=null)
		StopCoroutine(counter);
		anim.SetTrigger("Jump");

	}
}
