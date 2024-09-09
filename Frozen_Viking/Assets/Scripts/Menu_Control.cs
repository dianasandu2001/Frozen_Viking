using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("Map");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Save()
    {
        Debug.Log("Save pressed");
        Game_Manager.manager.Save();
    }    

    public void Load_b()
    {
        Debug.Log("Load pressed");
        Game_Manager.manager.Load();
        SceneManager.LoadScene("Map");
    }
}
