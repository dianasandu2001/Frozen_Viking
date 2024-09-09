using UnityEngine;

public class Load_Level : MonoBehaviour
{
    public string level_to_load; //Name of scene we want to open

    public bool cleared;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //When we open map scene, we check does game manager mark this lvl as passed.
        //if it is passed, then we run cleared function with parameters true
        if (Game_Manager.manager.GetType().GetField(level_to_load).GetValue(Game_Manager.manager).ToString() == "True")
        {
            Cleared(true); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cleared (bool is_cleared)
    {
        if (is_cleared == true)
        {
            cleared = true;
            //we set correct bool variable true in GM
            Game_Manager.manager.GetType().GetField(level_to_load).SetValue(Game_Manager.manager, true);
            
            // display lvl clear sign
            transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
            // because the level is passed we want to disable collider
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
