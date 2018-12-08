using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour {

    [SerializeField]
    private Sprite triggeredSprite;

    [SerializeField]
    private GameObject[] activatedBlocks;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = triggeredSprite;

            foreach(var block in activatedBlocks)
            {
                Destroy(block);
            }
        }
    }
}
