using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Character Name")]
    [SerializeField] private Text characterName;

    private bool playerInRange;

    private void Awake()
    {
        Debug.Log("Awake() ran.");
        playerInRange = false;
        visualCue.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (playerInRange)
        {
            Debug.Log("Player is in range.");
            visualCue.GetComponent<SpriteRenderer>().enabled = true;
            if (InputManager.GetInstance().GetInteractPressed())
            {
                Debug.Log(inkJSON.text);
            }
            Debug.Log(inkJSON.text);
        }
        else
        {
            //Debug.Log("Player out of range.");
            visualCue.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Something colliding!");
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player in range!");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player no longer in range.");
            playerInRange = false;
        }
    }
}
