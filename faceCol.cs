using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceCol : MonoBehaviour
{
    private Renderer hitFace;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider hitTrig){

        if(hitTrig.gameObject.tag == "face"){
            hitFace = hitTrig.gameObject.GetComponent<Renderer>();
            hitFace.material = mat;
        }   
    }
}
