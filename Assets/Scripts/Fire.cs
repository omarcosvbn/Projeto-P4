using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class Fire : MonoBehaviour{

    public GameObject temperature;
    [SerializeField] GameObject button;
    
    private Button buttonScript;

    public bool onFire;
    public float chance;


    void Start(){
        onFire = false;
        StartCoroutine(IncrementTemperature());
        StartCoroutine(RandomFireGeneration());
        buttonScript = button.GetComponent<Button>();
    }

    // Function to reverse map a value from range 1-4 to range 0-1
float ReverseMapValue(float value)
{
    // Clamping the value between 1 and 4
    float clampedValue = Mathf.Clamp(value, 1f, 4f);
    
    // Reversing the mapping from 1 to 4 to 0 to 1
    float reversedValue = (clampedValue - 1f) / 3f;

    return reversedValue;
}

IEnumerator IncrementTemperature(){
    while (true){
        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed
        if (onFire){
            float incrementValue = 0.01f; // Adjust the increment value as needed
            float newYScale = temperature.transform.localScale.y + incrementValue;
            
             newYScale = Mathf.Clamp(newYScale, 0f, 4);

            // Set the new Y scale of the temperature GameObject
            Vector3 newScale = temperature.transform.localScale;
            newScale.y = newYScale;
            temperature.transform.localScale = newScale;
        }
    }
}

    IEnumerator RandomFireGeneration(){
        while (true){
            yield return new WaitForSeconds(1.0f); // Repeat every 1 second
            if (!onFire){
                // Get the temperature's Y scale
                float temperatureYScale = temperature.transform.localScale.y;

                // Map the temperature's Y scale to the range 1-4
                float mappedValue = ReverseMapValue(temperatureYScale);

                // Use the mapped value to set the chance
                chance = mappedValue;
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
