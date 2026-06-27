using UnityEngine;

public class ActiveData : MonoBehaviour
{
    public static ActiveData Instance { get; private set; } 
    public string gameManagerAddress;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
