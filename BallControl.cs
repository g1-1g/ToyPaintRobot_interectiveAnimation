using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    [SerializeField] private Text txt;

    public GameObject HandBall;
    public GameObject HandBall2;
    public GameObject GroundBall;
    public GameObject[] ThrowBall;
    public GameObject HitTrig;
    public Animator RobotAnim;
    public Animator goalAnim;
    public Transform RobotPos;
    public Transform DropPos;
    public Transform DropRot;
    public Material[] mat;
    public int a = 0;
    public int b = 0;
    public int c = 0;
    public int d = 0;
    public int e = 0;
    public int f = 0;
    public int g = 0;
    public int Click = 0;
    public string[] OkBall = {"ThrowBallR", "ThrowBallY", "ThrowBallG", "ThrowBallB"};
    private AudioSource soundSource;
    public AudioClip S1;
    public AudioClip S2;
    public AudioClip S3;
    public AudioClip S4;
     

    void Start()
    {
        soundSource = gameObject.GetComponent<AudioSource>();
        txt.text = " 빨강: 1 노랑: 2 초록: 3 파랑: 4\r\n버튼을 눌러 공을 골라줘!​";
        
    }

    // Update is called once per frame

    void Update()
    {
        StartCoroutine(startGame()); 
        if((f == 0) && (c == 1) && Input.GetKeyDown("1")){
            if (Click == 0){
            soundSource.PlayOneShot(S3, 2f);
            Click = 1;
            }
            Click = 0;
            a = 1;
            RobotAnim.SetBool("Red", true);
            StartCoroutine(BallColor()); 
            goalAnim.SetBool("GoalMove", true);
            f = 1;
            txt.text = "던지기:SpaceBar\r\n색변경: R 누르고 재선택​";
  
               
        } 
        if((f == 0) && (c == 1) &&Input.GetKeyDown("2")){
            if (Click == 0){
            soundSource.PlayOneShot(S3, 2f);
            Click = 1;
            }
            Click = 0;
            a = 2;
            RobotAnim.SetBool("Yellow", true);
            StartCoroutine(BallColor()); 
            goalAnim.SetBool("GoalMove", true);
            f = 1;
            txt.text = "던지기:SpaceBar\r\n색변경: R 누르고 재선택​";


        }
        if((f == 0) && (c == 1) &&Input.GetKeyDown("3")){
            if (Click == 0){
            soundSource.PlayOneShot(S3, 2f);
            Click = 1;
            }
            Click = 0;
            a = 3;
            RobotAnim.SetBool("Green", true);;
            StartCoroutine(BallColor()); 
            goalAnim.SetBool("GoalMove", true);
            f = 1;
            txt.text = "던지기:SpaceBar\r\n색변경: R 누르고 재선택​";


        }
        if((f == 0) && (c == 1) &&Input.GetKeyDown("4")){
            if (Click == 0){
            soundSource.PlayOneShot(S3, 2f);
            Click = 1;
            }
            Click = 0;
            a = 4;
            RobotAnim.SetBool("Blue", true);
            StartCoroutine(BallColor()); 
            goalAnim.SetBool("GoalMove", true);
            f = 1;
            txt.text = "던지기:SpaceBar\r\n색변경: R 누르고 재선택​";


        }
        if(!(a == 0) && (g == 0) && (f == 1) && Input.GetKeyDown(KeyCode.Space) && (b == 0)){;
            RobotAnim.SetBool("ThrowBall", true);
            StartCoroutine(Ballcreation());
            if (Click == 0){
            soundSource.PlayOneShot(S4, 2f);
            Click = 1;
            }
            Click = 0;    
        } 
        if((c == 1) && Input.GetKeyDown(KeyCode.R)){;
            f = 0;  
            txt.text = " 빨강: 1 노랑: 2 초록: 3 파랑: 4\r\n버튼을 눌러 공을 골라줘!​";
        } 
        
        if((c == 1) && Input.GetKeyDown(KeyCode.G)){;
            goalAnim.SetBool("GoalMove", true);
        } 
        //if(Input.GetKeyDown("2")){
        //    RobotAnim.SetBool("DrumSpin", true);
        //    StartCoroutine(DrumSpining());
        //}
    }
    IEnumerator startGame(){
        yield return new WaitForSeconds(1.1f);
        if (d == 0){
            soundSource.PlayOneShot(S1, 2f);
            d = 1;
        }
        yield return new WaitForSeconds(1f);
        c = 1;
        
        

    }

    IEnumerator BallColor(){
        g = 1;
        yield return new WaitForSeconds(2f);
        GroundBall.gameObject.GetComponent<Renderer>().material = mat[a]; 
        RobotAnim.SetBool("Green", false);
        RobotAnim.SetBool("Red", false);
        RobotAnim.SetBool("Blue", false);
        RobotAnim.SetBool("Yellow", false);
        yield return new WaitForSeconds(0.5f);
        g = 0;

    }
    IEnumerator Ballcreation(){
        
        b = 1;
        RobotAnim.SetBool("ThrowBall", true);
        yield return new WaitForSeconds(0.5f);
        HandBall.gameObject.GetComponent<Renderer>().material = mat[a];
        HandBall2.gameObject.GetComponent<Renderer>().material = mat[a];
        yield return new WaitForSeconds(1.2f);
        GroundBall.GetComponent<MeshRenderer>().enabled = false;
        HandBall.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(1.2f);
        HandBall.GetComponent<MeshRenderer>().enabled = false;
        HandBall2.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(0.95f);
        HandBall2.GetComponent<MeshRenderer>().enabled = false;
        Instantiate(ThrowBall[a], RobotPos.position, DropRot.rotation);
        yield return new WaitForSeconds(0.1f);
        RobotAnim.SetBool("ThrowBall", false);
        b = 0;
        yield return new WaitForSeconds(1f);
        yield return new WaitForEndOfFrame();
        GroundBall.GetComponent<MeshRenderer>().enabled = true;
        

    }
    

    private void OnTriggerEnter(Collider hitTrig){ 
        if((hitTrig.gameObject.tag == OkBall[a-1]) && (f == 1)){
            goalAnim.SetBool("GoalMove", false);
            if (e == 0){
            soundSource.PlayOneShot(S2, 2f);
            e = 1;
            txt.text = "​";
            
        }
        }   
    }
    

}
