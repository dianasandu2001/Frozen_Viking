using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager manager;

    private void Awake()
    {
        // Singleton, we want to make sure that there is only one instance of GameManager in our game
        if (manager == null)
        {
            // If we do not have a manager. lets tell that this class instance is the manager.
            // we also tell that this manager cannot be destroyed if we change the scene
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            // we'll run this if there is already a manager in the scene for some reason
            // this manager will be a second manager that is ot allowed, we destroy the second "king" in this game
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
