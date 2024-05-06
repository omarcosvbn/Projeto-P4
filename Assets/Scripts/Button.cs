using UnityEngine;

public class Button : MonoBehaviour {
    public bool isPressed;
    private bool canPress = true; // Add a flag to indicate if the button can be pressed again
    [SerializeField] GameObject botao;
    private Vector3 originalPosition;
    private float pressedOffset = -0.009f; // Offset to move the button down when pressed

    private void Start() {
        originalPosition = botao.transform.position;
    }

    private void OnTriggerEnter(Collider other){
        if (!other.CompareTag("Base") && canPress) { // Check if the button can be pressed
            isPressed = true;
            canPress = false; // Set canPress to false to prevent repeated pressing
            Debug.Log("Button pressed");
            // Move down when pressed
            botao.transform.position += new Vector3(0, pressedOffset, 0);
        }
    }

    private void OnTriggerExit(Collider other){
        if (!other.CompareTag("Base")) {
            isPressed = false;
            canPress = true; // Reset the canPress flag when the button is released
            Debug.Log("Button released");
            // Return to the original position
            botao.transform.position = originalPosition;
        }
    }
}