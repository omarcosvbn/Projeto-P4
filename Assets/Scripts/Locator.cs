using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour{
    [SerializeField] Button buttonUpScript;
    [SerializeField] Button buttonDownScript;

    [SerializeField] GameObject smallCollider;
    [SerializeField] GameObject bigCollider;

    void Update(){
        if(buttonUpScript.isPressed == true){
            Debug.Log("aa");
            if(smallCollider.transform.position.x < 0.08f) smallCollider.transform.position += new Vector3 (0.01f, 0, 0);
            if(bigCollider.transform.position.x < 40f) bigCollider.transform.position += new Vector3 (5f, 20, 0);
        }

        if(buttonDownScript.isPressed == true){
            Debug.Log("bb");
            if(smallCollider.transform.position.x > 0f) smallCollider.transform.position -= new Vector3 (0.01f, 0, 0);
            if(bigCollider.transform.position.x > 0f) bigCollider.transform.position -= new Vector3 (5f, 20, 0);
        }
    }


}
