using UnityEngine;

public class Button : MonoBehaviour {
    public bool isPressed;
    //private bool alreadyPressed;

    private void OnTriggerEnter(Collider other){
        //if (!alreadyPressed){
            isPressed = true;
        //    alreadyPressed = true;
        //}
        //isPressed = false;
    }

    private void OnTriggerExit(Collider other){
            isPressed = false;
          //  alreadyPressed = false;
    }
}