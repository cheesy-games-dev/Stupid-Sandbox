using UnityEngine;

[DefaultExecutionOrder(-99)]
public class ActiveData : MonoBehaviour
{
    public static ActiveData Instance { get; private set; } 
    public string gameManagerAddress;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
