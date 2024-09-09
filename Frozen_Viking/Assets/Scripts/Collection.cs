using UnityEngine;

public class Collection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource health_FX;
    public AudioSource health_extra_FX;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //health_FX.Play();
        //Game_Manager.manager.health += 20;

        if (gameObject.CompareTag("Health"))
        {
            health_FX.Play();
            Game_Manager.manager.health += 20;
        }
        
        if (gameObject.CompareTag("Health_Bar"))
        {
            health_extra_FX.Play();
            Game_Manager.manager.max_health += 20;
        }
        this.gameObject.SetActive(false);
    }
}
