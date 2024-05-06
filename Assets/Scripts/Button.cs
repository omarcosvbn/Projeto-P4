using UnityEngine;

public class Button : MonoBehaviour {
    public bool isPressed;

    private void OnTriggerEnter(Collider other){
        if (!other.CompareTag("Base")) {
            isPressed = true;
        }
        transform.position = new Vector3(0, 0, 0);
    }

    private void OnTriggerExit(Collider other){
        if (!other.CompareTag("Base")) {
            isPressed = false;
        }
    }
}