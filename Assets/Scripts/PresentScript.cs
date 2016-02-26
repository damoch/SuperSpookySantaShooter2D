using UnityEngine;
using System.Collections;

public class PresentScript : MonoBehaviour {
    Rigidbody2D RB;
    
    public bool IsGrounded;
    Quaternion rotation;
    int HealthPoints;
    float Direction;
    public GameObject BOOM;
    void Awake () {
        
        RB = GetComponent<Rigidbody2D>();
        rotation = transform.rotation;
        HealthPoints = 100;
        Direction = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsGrounded)
            transform.position = new Vector2(transform.position.x +Direction,
                transform.position.y);
        transform.rotation = rotation;



        if (HealthPoints <= 0) DestroyPresent();
        if (Player.isGameOver) DestroyPresent();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            HealthPoints -= 20;
            
            Destroy(col.gameObject);//destroy bullet
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Present")
        {
            Direction *= -1;
        }
    }
    void DestroyPresent()
    {
        if (!Player.isGameOver) Player.CounterS++;
        Instantiate(BOOM, new Vector2(transform.position.x,
            transform.position.y-0.3f), transform.rotation);
        Destroy(gameObject);     
    }
}
