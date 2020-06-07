using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [Header("type scene transition duration time")]
    [SerializeField]
    private float sceneTransitionTime = 1f;

    [Header("Type which scene to go")]
    [SerializeField]
    private string sceneName;

    [Header("Check if the scene is Title scene")]
    [SerializeField]
    private bool isTitleScene = false;

    private Animator animator;

   

    private void Start()
    {      
        //here we getting the animator component from children
        animator = GetComponentInChildren<Animator>();

        //checking if this is the startScene
        if (isTitleScene)
        {
            StartCoroutine(LoadSceneCo(sceneName));
        }
    }


    //calling the loading scene function
    public void LoadScene()
    {
        //starting the coroutine
        StartCoroutine(LoadSceneCo(sceneName));
    }


    private IEnumerator LoadSceneCo(string name)
    {
       
       
        //will wait till given time
        yield return new WaitForSeconds(sceneTransitionTime);

        if (isTitleScene)
        {
            animator.SetTrigger("end");
            yield return new WaitForSeconds(sceneTransitionTime);
        }
        

        //loading given scene
        SceneManager.LoadScene(name);
    }


    //get called when a sprite is clicked
    public void SpriteClicked()
    {
        animator.SetTrigger("end");
        LoadScene();
    }
    


    //when restart button pressed this will be called
   public void RestartButtonClicked()
   {
        GameManager.Instance.GameReset();
        animator.SetTrigger("end");
        LoadScene();

   }

}
