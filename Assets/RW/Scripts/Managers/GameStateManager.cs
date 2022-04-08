using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int SheepSaved = 0;

    [HideInInspector]
    public int SheepDropped = 0;

    public int SheepDroppedBeforeGameOver;
    public SheepSpawner SPRefrence;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
   
    public void SavedSheep()
    {
        SheepSaved++;
        UIManager.Instance.UpdateSheepSavedText();
    }

    public void GameOver()
    {
        SPRefrence.bCanSpawn = false;
        SPRefrence.DestroyAllSheep();

        UIManager.Instance.ShowGameOverWindow();
    }

    public void DroppedSheep()
    {
        SheepDropped ++;
        UIManager.Instance.UpdateSheepDroppedText();
         
        if (SheepDropped == SheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }
}
