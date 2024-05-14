using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;
    [SerializeField]
    private float minX, maxX; //if the variables are of the same type, you can declare them in the same line with commas
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Debug.Log("The selected index: " + GameManager.instance.CharIndex);
    }

    // Update is called once per frame
    void LateUpdate() //lateUpdate is called AFTER Update is finished completely
    {
        // !player <--> player = null
        if (!player) //if player is null, that means player has no reference and so the player is destroyed
        {
            return;
        }
        tempPos = transform.position; //tempPos will be the current position of the camera
        tempPos.x = player.position.x; //set the current position of the camera's x position to the player's x position
        if(tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }
        transform.position = tempPos; //store the camera's position in transform.position
    }
}
