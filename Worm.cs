using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour {

    public float speed = 1f;
    public int health = 5;
    private Rigidbody2D myBody;
    public float moveTime=2;
    private float moveWait = 1000;
    private int i;
    
    
    
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
       
        Vector3 move = new Vector3(0, -1, 0);
        myBody.velocity = move * speed;
        StartCoroutine("WormMove");
    }

    public IEnumerator WormMove()
    {
        yield return new WaitForSeconds(moveTime);
        //transform.Translate(0, 0, 1);

    }
}
