using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStart : MonoBehaviour
{
    public GameObject[] DrumBall;
    public GameObject inRobot;
    public GameObject ineRobot;
    public GameObject ineRobot2;
    public GameObject ineRobot2B;
    public GameObject HPen;
    public GameObject Pen;
    public GameObject Pen2;
    public GameObject outRobot;
    public GameObject outRobotB;
    public GameObject endRobot;
    public GameObject endRobotB;
    public GameObject firstRobot;
    public GameObject lightBody;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject mouth;
    public GameObject lightBasic;
    public GameObject[] lightCol;
    public GameObject BeforeEye;
    public GameObject ChangeEye;
    public GameObject[] Hand;
    public Animator RobotAnim;
    public Animator goalAnim;
    public Animator cameraAnim;
    public Transform DropPos;
    public Material[] mat;
    public int a;
    public int i;
    public string[] OkBall = {"ThrowBallR", "ThrowBallY", "ThrowBallG", "ThrowBallB"};
    private AudioSource soundSource;
    public AudioClip LOnSound;
    public AudioClip DrumSound;
    public AudioClip Dding;
    
    // Start is called before the first frame update
    void Start()
    {
        
        soundSource = gameObject.GetComponent<AudioSource>();
    }

   
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown("5")){
        //    RobotAnim.SetBool("DrumSpin", true);
        //    StartCoroutine(DrumSpining());
        //    cameraAnim.SetBool("NextCamera", true);
       // }
        if(Input.GetKeyDown("1")){
            a = 1;

        }
        if(Input.GetKeyDown("2")){
            a = 2;

        }
        if(Input.GetKeyDown("3")){
            a = 3;

        }
        if(Input.GetKeyDown("4")){
            a = 4;

        }
        
    }

    IEnumerator DrumSpining(){
        ineRobot2B.gameObject.GetComponent<Renderer>().material = mat[a];
        outRobotB.gameObject.GetComponent<Renderer>().material = mat[a];
        endRobotB.gameObject.GetComponent<Renderer>().material = mat[a];
        yield return new WaitForSeconds(1.7f);
        firstRobot.SetActive(false);
        inRobot.SetActive(true);
        yield return new WaitForSeconds(4.4f);
        inRobot.SetActive(false);
        ineRobot.SetActive(true);
        yield return new WaitForSeconds(3f);
        soundSource.PlayOneShot(DrumSound, 2f);
        for (int i=1; i<170; i++){
            Instantiate(DrumBall[a], DropPos.position, DropPos.rotation);
            yield return new WaitForSeconds(0.05f);
        }  
        yield return new WaitForSeconds(0.1f);
        RobotAnim.SetBool("DrumSpin", false);
        RobotAnim.SetBool("ToyOut", true);
        yield return new WaitForSeconds(1f);
        ineRobot.SetActive(false);
        ineRobot2.SetActive(true);
        yield return new WaitForSeconds(2f);
        ineRobot2.SetActive(false);
        outRobot.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        HPen.SetActive(true);
        Pen.SetActive(false);
        yield return new WaitForSeconds(2f);
        eye1.gameObject.GetComponent<Renderer>().material = mat[0];
        yield return new WaitForSeconds(0.5f);
        eye2.gameObject.GetComponent<Renderer>().material = mat[0];
        yield return new WaitForSeconds(1.3f);
        mouth.gameObject.GetComponent<Renderer>().material = mat[0];
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(4.2f);
        outRobot.SetActive(false);
        endRobot.SetActive(true);
        yield return new WaitForSeconds(4f);
        HPen.SetActive(false);
        Pen2.SetActive(true);
        yield return new WaitForSeconds(4f);
        soundSource.PlayOneShot(Dding, 0.5f);
        BeforeEye.SetActive(false);
        ChangeEye.SetActive(true);
        //endRobot.SetActive(false);
        //firstRobot.SetActive(true);
        //HPen.SetActive(false);
        //lightBody.gameObject.GetComponent<Renderer>().material = mat[0];
        //lightCol[0].SetActive(true);


    }

    private void OnTriggerEnter(Collider hitTrig){
        Destroy(hitTrig.gameObject);
        if(hitTrig.gameObject.tag == OkBall[a-1]){
            cameraAnim.SetBool("NextCamera", true);
            RobotAnim.SetBool("DrumSpin", true);
            goalAnim.SetBool("GoalMove", false);
            lightBasic.SetActive(false);
            soundSource.PlayOneShot(LOnSound, 0.5f);
            lightCol[a].SetActive(true);
            lightBody.gameObject.GetComponent<Renderer>().material = mat[a+4];
            StartCoroutine(DrumSpining());
            for (i = 0; i < 15; i++){
                Hand[i].GetComponent<MeshCollider>().enabled = true;
            }
            Debug.Log("touch");
        }   

    }
}
