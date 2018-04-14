using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsRespect : MonoBehaviour {

	public float bigger = 0.4f, lower = 0.3f;

		
		void OnMouseDown () {
			transform.localScale = new Vector3 (bigger, bigger, bigger);
		}

		void OnMouseUp () {
			transform.localScale = new Vector3 (lower, lower, lower);
		}

		void OnMouseUpAsButton () {
		switch (gameObject.name) { 



		case "ZakharovGames":
			Application.OpenURL ("https://vk.com/im");
			break;
		}
	}

}