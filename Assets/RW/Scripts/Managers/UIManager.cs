using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text SheepSavedText;
    public Text SheepDroppedText;

    public GameObject GameOverWindow;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSheepSavedText()
    {
        SheepSavedText.text = GameStateManager.Instance.SheepSaved.ToString();
    }

    public void UpdateSheepDroppedText()
    {
        SheepDroppedText.text = GameStateManager.Instance.SheepDropped.ToString();
    }

    public void ShowGameOverWindow()
    {
        GameOverWindow.SetActive(true);
    }
}
