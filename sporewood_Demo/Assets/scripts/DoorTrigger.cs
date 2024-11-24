using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Scene to Load")]
    [SerializeField] public string sceneName;

    [Header("Door Locked?")]
    [SerializeField] public bool isLocked = false;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.GetComponent<SpriteRenderer>().enabled = true;
            if (InputManager.GetInstance().GetInteractPressed())
            {
                if (!isLocked)
                {
                    SceneManager.LoadScene(sceneName: sceneName);
                }
                else
                {
                    Debug.Log("Door is locked!");
                }
            }
        }
        else
        {
            visualCue.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
