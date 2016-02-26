using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    
    bool Spinned;
    // Update is called once per frame
    void Start()
    {
        Spinned = Player.spinned;
        Destroy(this.gameObject, 1);
    }
    void Update () {

        // transform.position = new Vector3(transform.position.x - .07f, transform.position.y, transform.position.z);
        if(Spinned) transform.Translate(Vector2.right * .1f);
        else if(!Spinned) transform.Translate(Vector2.left * .1f);

    }
   

}
