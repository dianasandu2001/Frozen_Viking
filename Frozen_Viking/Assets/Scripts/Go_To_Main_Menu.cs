using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_To_Main_Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("Main_Menu"); 
    }

}
