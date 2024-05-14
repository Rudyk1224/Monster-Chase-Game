using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        


    }
    private void FixedUpdate()
    {
        //we have to add force to the rigidbody (which deals with forces and gravity. The monster's x velocity will have to change which is why we set it to the variable speed, but the monster's y velocity stays the same as myBody.velocity.y
        myBody.velocity = new Vector2(speed, myBody.velocity.y); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
