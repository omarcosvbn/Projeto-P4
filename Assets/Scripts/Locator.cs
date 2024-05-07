using UnityEngine;

public class Locator : MonoBehaviour {
    [SerializeField] Button buttonUpScript;
    [SerializeField] Button buttonDownScript;

    [SerializeField] Transform smallColliderTransform;
    [SerializeField] Transform bigColliderTransform;

    [SerializeField] float smallColliderSpeed = 0.1f;
    [SerializeField] float bigColliderSpeed = 10f;

    void Update() {
        if (buttonUpScript.isPressed) {
            MoveCollider(smallColliderTransform, -smallColliderSpeed);
            MoveCollider(bigColliderTransform, -bigColliderSpeed);
        }

        if (buttonDownScript.isPressed) {
            MoveCollider(smallColliderTransform, smallColliderSpeed);
            MoveCollider(bigColliderTransform, bigColliderSpeed);
        }
    }

    void MoveCollider(Transform colliderTransform, float speed) {
        // Move the collider along the x-axis in world space
        Vector3 movement = new Vector3(speed, 0, 0) * Time.deltaTime;
        colliderTransform.Translate(movement);
    }
}