using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("Map");
    }
}
