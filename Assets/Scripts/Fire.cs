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


    }

    private void OnTriggerStay(Collider other){
        if(onFire == true && buttonScript.isPressed == true) onFire = false;
    }
}
