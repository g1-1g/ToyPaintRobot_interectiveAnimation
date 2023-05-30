using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    public float speed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        //Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision hitColl) {
        Destroy(gameObject, 100f);
    }

    
    
    

}
