using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour{

    public Slider temperature;
    public bool onFire;
    public float chance;

    void Start(){
            onFire = false;
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            temperature.value = 0.15f;
    }

    void Update(){
        //velocidade em que os incendios sobem a barra de temperatura
        if(onFire == true){
            temperature.value += 0.0005f * Time.deltaTime;
        }

        //apagar os incendios para testar
        if (Mouse.current.leftButton.wasPressedThisFrame){
            onFire = false;
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }

        //criar incendios com base no valor do slider
        chance = temperature.value * 100;
        if(Random.Range(1, 100) < chance){
            onFire = true;
            GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
    }

    public void SetOnFire(bool value){
        onFire = value;
    }

    public void OnTriggerEnter(){
        onFire = false;
        GetComponent<Renderer>().material.color = new Color(0, 255, 0);
    }
}
