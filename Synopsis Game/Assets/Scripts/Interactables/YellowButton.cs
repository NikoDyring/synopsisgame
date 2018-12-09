using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour {

    [SerializeField]
    private Sprite triggeredSprite;

    [SerializeField]
    private GameObject[] activatedBlocks;

    private bool blocksDestroyed;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        blocksDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !blocksDestroyed)
        {
            spriteRenderer.sprite = triggeredSprite;
            audioSource.Play();
            foreach(var block in activatedBlocks)
            {
                Destroy(block);
            }
            blocksDestroyed = true;
        }
    }
}
