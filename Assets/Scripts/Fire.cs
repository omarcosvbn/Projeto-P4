using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class Fire : MonoBehaviour{

    public GameObject temperature;
    [SerializeField] GameObject button;
    
    private Button buttonScript;
    [SerializeField] Menus menusScript;

    [SerializeField] GameObject fireParticles;
    [SerializeField] GameObject fireParticlesEdges;
    [SerializeField] AudioSource fireSound;

    [SerializeField] GameObject rainParticles;


    public bool onFire;
    public float chance;
    public float timer = 0f; // Time in seconds (60.0f = 60s)

    private bool alreadyStarted = false;



    void Start(){
        onFire = false;
        StartCoroutine(IncrementTemperature());
        StartCoroutine(RandomFireGeneration());
        buttonScript = button.GetComponent<Button>();

        fireParticles.SetActive(false);
        fireParticlesEdges.SetActive(false);
        rainParticles.SetActive(false);
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
            float incrementValue = 0.005f; // Adjust the increment value for difficulty (0.005f seems good)
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
            yield return new WaitForSeconds(15.0f); // Repeat every 15 second
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
        if(onFire == true){
            if(!fireSound.isPlaying)fireSound.Play();
            fireParticles.SetActive(true);
        }
        else{
            fireParticles.SetActive(false);
            fireSound.Stop();
        }

        if(timer > 0.0f) timer -= Time.deltaTime;
        else if(timer <= 0.0f){
            rainParticles.SetActive(false); 
        }


        Vector3 newScale = temperature.transform.localScale;
        if(menusScript.canStart == false){ 
            temperature.transform.localScale = new Vector3(newScale.x, 1f, newScale.z);                       
            chance = 0f;
            onFire = false;
        }
        else if(temperature.transform.localScale.y >= 4 || menusScript.canStart == true && alreadyStarted == false){                        
            temperature.transform.localScale = new Vector3(newScale.x, 1.1f, newScale.z);
            chance = 0.033f;
            onFire = false;
            alreadyStarted = true;
        }

        if(newScale.y >= 3f && fireParticlesEdges.activeSelf == false){
            fireParticlesEdges.SetActive(true);
        }
    }
    
    private void OnTriggerStay(Collider other){
        if(onFire == true && buttonScript.isPressed == true){
            onFire = false;
            rainParticles.SetActive(true);
            timer = 3f;
        }
    }
}
