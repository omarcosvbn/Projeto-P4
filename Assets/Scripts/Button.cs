using UnityEngine;

public class Button : MonoBehaviour {
    public bool isPressed;

    private void OnTriggerEnter(Collider other){
            isPressed = true;
    }

    private void OnTriggerExit(Collider other){
            isPressed = false;
    }



   void Update(){
    //Debug.Log(isPressed);
   }
}