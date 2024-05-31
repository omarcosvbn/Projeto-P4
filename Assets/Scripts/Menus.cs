using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Menus : MonoBehaviour{

    public InputActionReference leftTriggerAction;
    public InputActionReference rightTriggerAction;
    [SerializeField] GameObject blackScreen;
    public bool canStart = false; 

    void Start(){
        blackScreen.SetActive(true);
    }


    void Update(){
        if(leftTriggerAction.action.ReadValue<float>() > 0.3f && rightTriggerAction.action.ReadValue<float>() > 0.3f){
            blackScreen.SetActive(false);
            canStart = true;
        }        
    }
}
