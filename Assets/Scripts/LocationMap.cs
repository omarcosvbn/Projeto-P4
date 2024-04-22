using UnityEngine;

public class LocationMap : MonoBehaviour{
    [SerializeField] GameObject fire;
    private Fire fireScript;


    private void Start(){
        fireScript = fire.GetComponent<Fire>();
    }

    private void Update(){
        if (fireScript.onFire == true){
            GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else if (fireScript.onFire == false) {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
    }
}
