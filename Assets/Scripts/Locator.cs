using UnityEngine;

public class Locator : MonoBehaviour{
    [SerializeField] GameObject locator;
    private float locatorX;
    private float locatorZ;

    private void Update(){
        locatorX = locator.transform.position.x;
        locatorZ = locator.transform.position.z;
        transform.position = new Vector3(locatorX/515, transform.position.y, locatorZ/515);
    }
}

