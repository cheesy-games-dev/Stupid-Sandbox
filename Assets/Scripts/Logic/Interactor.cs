using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public PlayerController controller;

    void Update() {
        var interactableUI = controller.MyUI.interactableUI;
        if (Physics.Raycast(controller.input.camera.transform.position, controller.input.camera.transform.forward, out RaycastHit hit, 5f)) {
            bool active = hit.transform.GetComponent<IInteractable>() != null;
            interactableUI.alpha = Mathf.MoveTowards(interactableUI.alpha, active ? 1 : 0, 10*Time.deltaTime);
        }
        else {
            interactableUI.alpha = Mathf.MoveTowards(interactableUI.alpha, 0, 10 * Time.deltaTime);
        }
    }
    public IInteractable LastInteractable { get; set; }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.action.WasPressedThisFrame())
        {
            if (Physics.Raycast(controller.input.camera.transform.position, controller.input.camera.transform.forward, out RaycastHit hit, 5f))
            {
                LastInteractable = hit.transform.GetComponent<IInteractable>();
                if (LastInteractable != null) LastInteractable.OnPress(this);
            }
        }
        else if (context.action.WasReleasedThisFrame()) {
            if (LastInteractable != null) LastInteractable.OnRelease(this);
        }
    }

}
