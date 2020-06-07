using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton declaration
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    #region Sprite Enable Variable
    [HideInInspector]
    public bool bigSpriteSelected;
    [HideInInspector]
    public bool mediumSpriteSelected;
    [HideInInspector]
    public bool smallSpriteSelected;
    #endregion



    #region Reseting the Game
    public void GameReset()
    {
        bigSpriteSelected =false;
        smallSpriteSelected =false;
        mediumSpriteSelected = false;
    }
    #endregion






}
