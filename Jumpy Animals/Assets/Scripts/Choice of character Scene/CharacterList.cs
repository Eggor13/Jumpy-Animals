﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterList : MonoBehaviour {

	private GameObject[] characterList;

	private int index;

	private void Start()
	{
		index = PlayerPrefs.GetInt ("CharacterSelected");
		
		characterList = new GameObject[transform.childCount]; 

		for (int i = 0; i < transform.childCount; i++)
			characterList [i] = transform.GetChild (i).gameObject;

		foreach (GameObject go in characterList)
			go.SetActive (false);

		if (characterList [index])
			characterList [index].SetActive (true);

	}
	public void ToggleLeft()
	{
		characterList [index].SetActive (false);

		index--;//index -= 1; index = index - 1;
		if (index < 0)
			index = characterList.Length - 1;

		//Toggle on the new model
		characterList [index].SetActive (true);
	}

	public void ToggleRight()
	{
		characterList [index].SetActive (false);

		index++;//index -= 1; index = index - 1;
		if (index == characterList.Length)
			index = 0;

		//Toggle on the new model
		characterList [index].SetActive (true);
	}
	public void ConfirmButton()
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Play");
	}
}
