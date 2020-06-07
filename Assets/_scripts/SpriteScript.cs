using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{

    public bool isMoveToward = false;

    private void Update()
    {
        if (isMoveToward)
        {
            transform.position = Vector2.MoveTowards(transform.position,Vector2.zero,5*Time.deltaTime);
        }
    }


}
