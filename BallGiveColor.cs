using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGiveColor : MonoBehaviour
{
    private Renderer hitTexture;
    public Texture[] arrayTexture;
    int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }


    private void OnCollisionEnter(Collision hitColl) {
        string coll = hitColl.gameObject.name;
        if ((coll == "pasted__polySurface43") && (count <= 5))
        {   
            int rand = Random.Range(0,5);
            Debug.Log(count);
            hitTexture = hitColl.gameObject.GetComponent<Renderer>();
            hitTexture.material.mainTexture = arrayTexture[rand];
        }
    

    }



}
