using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Icon : MonoBehaviour
{
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            //We hit level_trigger, fetch the llevel name from the trigger's component
            SceneManager.LoadScene(collision.GetComponent<Load_Level>().level_to_load);
        }
    }
}
