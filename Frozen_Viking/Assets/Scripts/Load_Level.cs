using UnityEngine;

public class Load_Level : MonoBehaviour
{
    public string level_to_load; //Name of scene we want to open
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cleared (bool is_cleared)
    {
        if (is_cleared == true)
        {
            // display lvl clear sign
            transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
            // because the level is passed we want to disable collider
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
