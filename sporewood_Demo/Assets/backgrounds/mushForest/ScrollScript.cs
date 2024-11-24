using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float speed = 0.0f;
    private Vector2 textureOffset;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
        GetComponent<Renderer>().material.mainTextureOffset += new Vector2(InputManager.GetInstance().GetMoveDirection().x * speed * Time.deltaTime, 0f);
    }
}
