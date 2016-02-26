using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public static bool isGrounded;//that for limiting jumps
    public static bool isOnPresent;
    public static bool spinned;
    public static bool isGameOver;
    public GameObject PlayerObject;
    GameObject ThisPlayer;
    public GameObject LeftDropper;
    public GameObject RightDropper;
    public GameObject StartButton;
    public GameObject ExitButton;
    public GameObject TitleScreen;
    public static GameObject SB;
    public static GameObject TP;
    public static GameObject TS;
    public static GameObject EB;
    public Text Counter;
    public Text HiScore;
    public static int TopScore;
    public static int CounterS;

    // Use this for initialization
    void Start () {
        //StartCoroutine("DropControll");
        CheckTopScore();
        isGameOver = true;
        isGrounded = false;
        isOnPresent = false;
        spinned = false;
        SB = StartButton;
        EB = ExitButton;
        //freezing rotation
        TS = TitleScreen;
        CounterS = 0;
        //PlayerObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
        //setting old rotation
        
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.JoystickButton4)) Jump();//Jumping from keyboard
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.JoystickButton5)) Spin();
        Counter.text ="Presents destroyed: "+ CounterS.ToString();
        HiScore.text = "Record: " + TopScore.ToString();
        if (CounterS>=TopScore) { TopScore = CounterS; }
        //ThisPlayer.GetComponent<Rigidbody2D>().freezeRotation = true;




    }
    public void Jump()//method for jumping
    {
        if(isGrounded||isOnPresent)
        ThisPlayer.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 230f);//now refers to PlayerObject
    }
   public void Spin()//adds 180 to rotationY
    {
        if (!spinned) {
            ThisPlayer.transform.rotation = new Quaternion(
                transform.rotation.x,
                 180f,
                transform.rotation.z,
                transform.rotation.w);
            spinned = true;
        }
        else
        {
            ThisPlayer.transform.rotation = new Quaternion(
                transform.rotation.x,
                0f,
                transform.rotation.z,
                transform.rotation.w);
            spinned = false;
        }
    }
    IEnumerator DropControll()
    {
        RightDropper.SetActive(true);
        yield return new WaitForSeconds(Random.Range(0.5f, 5));
      
        LeftDropper.SetActive(true);

    }
    public static void GameOver(){
        CheckTopScore();
        Destroy(TP);
        isGameOver = true;
        SB.SetActive(true);
        TS.SetActive(true);
        EB.SetActive(true);
    }
    public void StartGame()
    {
        CheckTopScore();

        ThisPlayer = (GameObject)Instantiate(PlayerObject, new Vector2(0f, 0f), Quaternion.Euler(0, 0, 0));
        TP = ThisPlayer;
        CounterS = 0;
        isGameOver = false;
        StartButton.SetActive(false);
        ExitButton.SetActive(false);
        TitleScreen.SetActive(false);
    }
    public void ExitGame() {
        Application.Quit();
    }
    static void CheckTopScore()
    {
        if (PlayerPrefs.HasKey("TopScore"))
        {
            if (PlayerPrefs.GetInt("TopScore") > CounterS) TopScore = PlayerPrefs.GetInt("TopScore");
            else if (PlayerPrefs.GetInt("TopScore") <= CounterS) { PlayerPrefs.SetInt("TopScore", CounterS); TopScore = CounterS; }
        }//setting saved top score value
        else { TopScore = 0; PlayerPrefs.SetInt("TopScore", TopScore); }

        Debug.Log(TopScore);
    }
}
