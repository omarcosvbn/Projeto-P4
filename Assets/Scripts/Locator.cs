using UnityEngine;

public class Locator : MonoBehaviour {
    [SerializeField] Button buttonUpScript;
    [SerializeField] Button buttonDownScript;

    [SerializeField] Rigidbody smallColliderRigidbody;
    [SerializeField] Rigidbody bigColliderRigidbody;

    [SerializeField] float smallColliderSpeed = 0.01f;
    [SerializeField] float bigColliderSpeed = 5f;

    void Update() {
        if (buttonUpScript.isPressed) {
            MoveCollider(smallColliderRigidbody, -smallColliderSpeed);
            MoveCollider(bigColliderRigidbody, -bigColliderSpeed);
        }

        if (buttonDownScript.isPressed) {
            MoveCollider(smallColliderRigidbody, smallColliderSpeed);
            MoveCollider(bigColliderRigidbody, bigColliderSpeed);
        }
    }

    void MoveCollider(Rigidbody colliderRigidbody, float speed) {
        // Move the collider along the x-axis
        Vector3 movement = new Vector3(speed, 0, 0) * Time.deltaTime;
        colliderRigidbody.MovePosition(colliderRigidbody.position + movement);
    }
}