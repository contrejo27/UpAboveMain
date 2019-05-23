using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //Player
    public GameObject itemHeld;
    public enum PlayerState { Grabbing, Idle};

    public PlayerState currentPlayerState;
    
    //inventory
    public enum ItemType { Upgrade, Research};

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        currentPlayerState = PlayerState.Idle;
    }

    // Update is called once per frame
    public void LoadPlanet(string PlanetName)
    {
        SceneManager.LoadScene(PlanetName);
    }

    
}
