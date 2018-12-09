using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YellowDoor : MonoBehaviour {

    public static bool isOpen = false;

    [SerializeField]
    private GameObject topPart;
    [SerializeField]
    private GameObject bottomPart;

    [SerializeField]
    private Sprite openTop;
    [SerializeField]
    private Sprite openBottom;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(isOpen)
        {
            topPart.GetComponent<SpriteRenderer>().sprite = openTop;
            bottomPart.GetComponent<SpriteRenderer>().sprite = openBottom;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isOpen && collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Credits");
            isOpen = false;
        }
    }
}
