using UnityEngine;

public class Locator : MonoBehaviour {
    [SerializeField] Button buttonUpScript;
    [SerializeField] Button buttonMiddleScript;
    [SerializeField] Button buttonDownScript;

    [SerializeField] Transform smallColliderTransform;
    [SerializeField] Transform bigColliderTransform;

    [SerializeField] Vector3 smallColliderUpPosition;
    [SerializeField] Vector3 bigColliderUpPosition;
    [SerializeField] Vector3 smallColliderMiddlePosition;
    [SerializeField] Vector3 bigColliderMiddlePosition;
    [SerializeField] Vector3 smallColliderDownPosition;
    [SerializeField] Vector3 bigColliderDownPosition;

    void Update() {
        if (buttonUpScript.isPressed) {
            TeleportCollider(smallColliderTransform, smallColliderUpPosition);
            TeleportCollider(bigColliderTransform, bigColliderUpPosition);
        }
        if (buttonMiddleScript.isPressed) {
            TeleportCollider(smallColliderTransform, smallColliderMiddlePosition);
            TeleportCollider(bigColliderTransform, bigColliderMiddlePosition);
        }
        if (buttonDownScript.isPressed) {
            TeleportCollider(smallColliderTransform, smallColliderDownPosition);
            TeleportCollider(bigColliderTransform, bigColliderDownPosition);
        }
    }

    void TeleportCollider(Transform colliderTransform, Vector3 targetPosition) {
        // Teleport the collider to the target position
        colliderTransform.localPosition = targetPosition;
    }
}