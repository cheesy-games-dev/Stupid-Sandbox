using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public PlayerController controller;
    public Transform pointer;
    void Update()
    {
        length = Physics.OverlapSphereNonAlloc(pointer.position, 3, colliders);
        var interactableUI = controller.MyUI.interactableUI;
        if (TryGetInteractable(out IInteractable interactable))
        {
            interactableUI.alpha = Mathf.MoveTowards(interactableUI.alpha, 1, 10 * Time.deltaTime);

            Vector3 screenPos = controller.input.camera.WorldToScreenPoint((interactable as MonoBehaviour).transform.position);
            interactableUI.transform.position = screenPos;
        }
        else
        {
            interactableUI.alpha = Mathf.MoveTowards(interactableUI.alpha, 0, 10 * Time.deltaTime);
        }
    }
    public IInteractable LastInteractable { get; set; }
    private Collider[] colliders = new Collider[4];
    private int length;
    public bool TryGetInteractable(out IInteractable interactable)
    {
        for (int i = 0; i < length; i++) {
            if (colliders[i].TryGetComponent(out interactable)) {
                return true;
            }
        }
        interactable = null;
        return false;
    }
    public void OnInteract()
    {
        if (TryGetInteractable(out IInteractable interactable))
        {
            interactable?.OnPress(this);
        }
    }
}
