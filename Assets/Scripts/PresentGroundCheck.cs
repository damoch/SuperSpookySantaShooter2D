using UnityEngine;
using System.Collections;

public class PresentGroundCheck : MonoBehaviour {
    public PresentScript PS;
    int counter;
	// Use this for initialization
	void Start () {
        PS.IsGrounded = true;
        counter = 0;
	}
    
    void OnTriggerEnter2D(Collider2D col)//entering trigger - player is on ground
    {
        if (col.tag == "Platform")
        {
            PS.IsGrounded = true;

     
        }
        if (col.tag == "SantaHead") Player.GameOver();
    }
    void OnTriggerExit2D()
    {
        counter++;
        if (counter < 2)
        {
            PS.IsGrounded = false;
           
        }
        else
            PS.IsGrounded = true;
        


    }
}
