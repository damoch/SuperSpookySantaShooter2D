using UnityEngine;
using System.Collections;

public class DropperController : MonoBehaviour {
    public GameObject Present;
    Quaternion rotation;
    public  float maxTime;
    // Use this for initialization
    void Start () {
        maxTime = 5f;
        StartCoroutine("ProducePresents");
        StartCoroutine("FrequencyControler");
        rotation = Quaternion.Euler(0, 0, 0);
    }
    IEnumerator ProducePresents()
    {
        yield return new WaitForSeconds(Random.Range(.5f, maxTime));
        if(!Player.isGameOver)Instantiate(Present, transform.position, rotation);
        if (Player.isGameOver)
            maxTime = 5f;
        StartCoroutine("ProducePresents");

    }
    IEnumerator FrequencyControler()
    {
        yield return new WaitForSeconds(10);
        if(maxTime>1)maxTime -= 0.1f;
        if (Player.isGameOver)
            maxTime = 5f;
        StartCoroutine("FrequencyControler");
    }

}

