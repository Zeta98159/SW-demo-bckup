using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamabotMovement : MonoBehaviour
{
    public float closenessThreshold;
    public bool FollowPlayer;
    public float movementSpeed;
    private Transform mamabotTransform;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        mamabotTransform = GameObject.FindGameObjectWithTag("Mamabot").transform;
        if (FollowPlayer)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowPlayer && closenessThreshold != 0)
        {
            if (Mathf.Abs(playerTransform.position.x - mamabotTransform.position.x) > closenessThreshold)
            {
                mamabotTransform.Translate((playerTransform.position.x - mamabotTransform.position.x) * Time.deltaTime * movementSpeed, 0, 0);
            }
        }
    }
}
