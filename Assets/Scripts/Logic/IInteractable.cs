using UnityEngine;

public interface IInteractable
{
    public void OnPress(Interactor interactor);
    public void OnRelease(Interactor interactor);
}
