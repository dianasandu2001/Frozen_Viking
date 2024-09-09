using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager manager;

    public string current_level;

    public float health;  // current healt
    public float prev_health;  // health before we took dmg
    public float max_health;  // what is the max val of health

    public bool Level1;
    public bool Level2;
    public bool Level3;

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
        if (Input.GetKeyUp(KeyCode.M))
        {
            SceneManager.LoadScene("Main_Menu");
        } 
            

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Player_Data data = new Player_Data();
        //copy info from GM to Player_Data
        data.health = health;
        data.prev_health = prev_health;
        data.max_health = max_health;
        data.Level1 = Level1;
        data.Level2 = Level2;
        data.Level3 = Level3;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        //check if there is a save file in the folder
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            //We continue
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            Player_Data data = (Player_Data)bf.Deserialize(file);
            //The data is now loaded to data object
            file.Close();

            // move the info to GM
            health = data.health;
            prev_health = data.prev_health;
            max_health = data.max_health;
            Level1 = data.Level1;
            Level2 = data.Level2;
            Level3 = data.Level3;
        }    
    }
}

// Another class that we can serialize. This contains only the information we are going to store.
[Serializable]

class Player_Data
{
    public string current_level;

    public float health;  // current healt
    public float prev_health;  // health before we took dmg
    public float max_health;  // what is the max val of health

    public bool Level1;
    public bool Level2;
    public bool Level3;
}