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

    public AudioSource heart_FX;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AudioSource found: " + heart_FX.name);
        heart_FX.Play();
        Debug.Log("+20 health");
        this.gameObject.SetActive(false);
    }
}