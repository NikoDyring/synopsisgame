using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("ChangeLevelToStartMenu", 20);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeLevelToStartMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
