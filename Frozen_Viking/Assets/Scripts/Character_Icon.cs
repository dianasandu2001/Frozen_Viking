using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Icon : MonoBehaviour
{
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // when map is loaded, we ask game manager if it has some info about current level
        // if it has, we know we are coming back from some level
        // so we can fetch the object and its spawn point. We move the mapchat to that location
        if(Game_Manager.manager.current_level != "")
        {
            //we move the player to the spawn point location
            transform.position = GameObject.Find(Game_Manager.manager.current_level).transform.GetChild(1).transform.position;
            GameObject.Find(Game_Manager.manager.current_level).GetComponent<Load_Level>().Cleared(true);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontalMove, verticalMove,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Level_Trigger"))
        {
            // We tell game manager that we are entering a level. GM will keep the info
            // the info is the name of the object we hit
            Game_Manager.manager.current_level = collision.gameObject.name;
            
            //We hit level_trigger, fetch the llevel name from the trigger's component
            SceneManager.LoadScene(collision.GetComponent<Load_Level>().level_to_load);
        }
    }
}
