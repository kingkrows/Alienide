using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    [HideInInspector]
    public bool isMoveToward = false;

    private void Update()
    {
        //checking if the sprite start moving
        if (isMoveToward)
        {
            transform.position = Vector2.MoveTowards(transform.position,Vector2.zero,5f*Time.deltaTime);
        }
    }


}
