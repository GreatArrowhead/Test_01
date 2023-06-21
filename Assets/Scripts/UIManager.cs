using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    ItemObj itemObj;

    float currentScore;

    private void Awake()
    {
        itemObj = GetComponent<ItemObj>();
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        itemObj.itemArray = null;
        //scoreCountText.text = "TestTest";
    }

    public void AddScore(float scoreToAdd)
    {
        currentScore += scoreToAdd;
        //scoreCountText.text = currentScore.ToString();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
