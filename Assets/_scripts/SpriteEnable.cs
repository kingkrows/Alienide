using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEnable : MonoBehaviour
{
    [Header("Assign Sprites Here")]
    [SerializeField]
    private GameObject big, medium, small;

    private void Start()
    {
        EnableSprite();
    }


    #region Checking & Making sprites to show
    public void EnableSprite()
    {
        if (GameManager.Instance.bigSpriteSelected)
        {
            big.SetActive(true);
        }
        else if (GameManager.Instance.mediumSpriteSelected)
        {
            medium.SetActive(true);
        }
        else if (GameManager.Instance.smallSpriteSelected)
        {
            small.SetActive(true);
        }

    }
    #endregion




}
