using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public bool FollowPlayer;
    public float movementSpeed;
    public float closenessThreshold;
    private Transform playerTransform;
    private Transform npcTransform;

    // Start is called before the first frame update
    void Start()
    {
        npcTransform = gameObject.GetComponentInParent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowPlayer && Mathf.Abs(npcTransform.position.x - playerTransform.position.x) > closenessThreshold)
        {
            Vector2 newMovement = new Vector2(playerTransform.position.x - npcTransform.position.x, 0f);
            npcTransform.position += new Vector3(Time.deltaTime * movementSpeed, 0f, 0f);
        }
    }
}
