using UnityEngine;

public class Button : MonoBehaviour {
    private Fire fireScript;
    bool isPressed;


    [SerializeField] GameObject detectScriptObject; // GameObject containing the Fire script



    void Start() {
        // Get the Fire script component attached to the specified GameObject
        fireScript = detectScriptObject.GetComponent<Fire>();

        // Check if the Fire script component was found
        if (fireScript == null) Application.Quit();
    }

    private void OnTriggerEnter(Collider other){
            fireScript.SetOnFire(false);
    }



   void Update(){
    //Debug.Log(isPressed);
   }
}