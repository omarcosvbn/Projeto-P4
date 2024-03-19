using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour {
    public UnityEvent onPress;
    public UnityEvent onRelease;

    private Fire fireScript;
    bool isPressed;



    [SerializeField] GameObject detectScriptObject; // GameObject containing the Fire script



    void Start() {
        // Get the Fire script component attached to the specified GameObject
        fireScript = detectScriptObject.GetComponent<Fire>();

        // Check if the Fire script component was found
        if (fireScript == null) Application.Quit();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other){
        if(!isPressed){
            fireScript.SetOnFire(false);
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(isPressed){
            fireScript.SetOnFire(true);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void StopFire(){
        fireScript.SetOnFire(false);
        Debug.Log("aaaa");
    }

    public void StartFire(){
        fireScript.SetOnFire(true);
        Debug.Log("bbbb");
    }


   void Update(){
    Debug.Log(isPressed);
   }
}