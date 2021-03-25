using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject hairballPrefab;
    public SpriteRenderer playerSprite;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
        	Shoot();
        }
    }

    void Shoot()
    {
    	//Instantiate(hairballPrefab,Firepoint.position,Firepoint.rotation);
    	if (playerSprite.flipX == true)
    	{
    		Instantiate(hairballPrefab,Firepoint.position,Quaternion.Euler(new Vector3(0,180,0)));	
    	}
    	else if (playerSprite.flipX == false)
    	{
    		Instantiate(hairballPrefab,Firepoint.position,Firepoint.rotation);
    	
    	}

    	
    }

   // private void Flip()
    //{
    //	if (playerSprite.flipX == true) //for facing left
    //	{
    		//Firepoint.transform.Rotate(0,180,0);
    //	}

    //	else if (playerSprite.flipX == false) //for facing right
    //	{
    		//Firepoint.transform.Rotate(0,0,0);
    //	}
    //}
}