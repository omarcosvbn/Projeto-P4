using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class Fire : MonoBehaviour{

    public Slider temperature;
    [SerializeField] GameObject button;
    [SerializeField] GameObject buttonUp;
    [SerializeField] GameObject buttonDown;
    
    private Button buttonScript;
    private Button buttonUpScript;
    private Button buttonDownScript;

    public bool onFire;
    public float chance;

    [SerializeField] GameObject bigCollider;
    [SerializeField] GameObject smallCollider;

    void Start(){
        onFire = false;
        StartCoroutine(IncrementTemperature());
        StartCoroutine(RandomFireGeneration());
        buttonScript = button.GetComponent<Button>();
        buttonUpScript = buttonUp.GetComponent<Button>();
        buttonDownScript = buttonDown.GetComponent<Button>();
    }

    IEnumerator IncrementTemperature(){
        while (true){
            yield return new WaitForSeconds(1.0f); // Adjust the delay as needed
            if (onFire){
                temperature.value += 0.1f; // Adjust the increment value as needed
            }
        }
    }

    IEnumerator RandomFireGeneration(){
        while (true){
            yield return new WaitForSeconds(1.0f); // Repeat every 1 second
            if (!onFire){
                float temperatureNormalized = temperature.value / 10000 / temperature.maxValue;
                chance = temperatureNormalized * 100;
                if (Random.value < chance){
                    onFire = true;
                }
            }
        }
    }

    void Update(){  
        //mudar cor para teste
        if(onFire == true) GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        else GetComponent<Renderer>().material.color = new Color(0, 255, 0);

        if(buttonUpScript.isPressed == true){
            if(smallCollider.transform.position.x < 0.08f) smallCollider.transform.position = new Vector3 (smallCollider.transform.position.x + 0.04f, 0, 0);
            if(bigCollider.transform.position.x < 40f) bigCollider.transform.position = new Vector3 (bigCollider.transform.position.x + 20f, 20, 0);
        }

        if(buttonDownScript.isPressed == true){
            if(smallCollider.transform.position.x > 0f) smallCollider.transform.position = new Vector3 (smallCollider.transform.position.x - 0.04f, 0, 0);
            if(bigCollider.transform.position.x > 0f) bigCollider.transform.position = new Vector3 (bigCollider.transform.position.x - 20f, 20, 0);
        }
    }

    private void OnTriggerStay(Collider other){
        if(onFire == true && buttonScript.isPressed == true) onFire = false;
    }
}
