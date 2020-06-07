using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Interactable,
    Notinteractable
}

public class GameController : MonoBehaviour
{

    [Header("Give the rotation amount here")]
    [SerializeField]
    private float rotationAngle = 30f;

    [Header("Game State")]
    [SerializeField]
    private GameState gameState = GameState.Notinteractable;

    
    private SceneLoader sceneLoader;

    [Header("Assign sprites prefab")]
    [SerializeField]
    private List<GameObject> spriteList;

    [Header("Parent of all the sprites")]
    [SerializeField]
    private GameObject parent;

    private void Start()
    {
        //setting the game state
        gameState = GameState.Interactable;
        //finding Scene Loader Script
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void Update()
    {
        if (gameState==GameState.Interactable)
        {
            HandleMovement();
            HandleInput();
        }
        
        

    }

    #region Handling the Sprite Orbiting movement
    private void HandleMovement()
    {
        spriteList[1].transform.RotateAround(spriteList[0].transform.position, new Vector3(0f, 0f, 1f), rotationAngle * Time.deltaTime);
        spriteList[2].transform.RotateAround(spriteList[1].transform.position, new Vector3(0f, 0f, 1f), (rotationAngle+50f) * Time.deltaTime);
    }
    #endregion

    #region Handling the Touch/Mouse Input
    private void HandleInput()
    {
        if (gameState==GameState.Interactable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 screenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(screenPosition, Vector2.zero);
                if (hit)
                {
                    //making game state non intractable
                    gameState = GameState.Notinteractable;

                    //small sprite parent disconnecting
                    spriteList[2].transform.parent = parent.transform;

                    //will set the blink trigger for non selected sprites
                    SetBlinkTrigger(hit.collider.gameObject.tag);

                    //will set the selected sprite for the next scene
                    SetGameManagerSprite(hit.collider.gameObject.tag);

                    //will set the selected sprite value to move towards center
                    MoveToCentre(hit.collider.gameObject);

                    //will load next scene
                    sceneLoader.SpriteClicked();
                }
            }
        }
    }

#endregion

    #region Setting Value for the Sprite to Move 
    private void MoveToCentre(GameObject sprite)
    {
        sprite.GetComponent<SpriteScript>().isMoveToward = true;
    }
    #endregion

    #region Animation Trigger for non selected sprites
    private void SetBlinkTrigger(string tagName)
    {
        for (int i = 0; i < spriteList.Count; i++)
        {
            if (!spriteList[i].CompareTag(tagName))
            {
                spriteList[i].GetComponent<Animator>().SetTrigger("fade");
            }
           
        }
    }
    #endregion

    #region Game Manager vale setting

    private void SetGameManagerSprite(string tagName)
    {
        if (spriteList[0].CompareTag(tagName))
        {
            GameManager.Instance.bigSpriteSelected = true;
        }
        else if (spriteList[1].CompareTag(tagName))
        {
            GameManager.Instance.mediumSpriteSelected = true;
        }
        else if (spriteList[2].CompareTag(tagName))
        {
            GameManager.Instance.smallSpriteSelected = true;
        }
    }
    #endregion



}
