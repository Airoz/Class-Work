using UnityEngine;
using System.Collections;

public class EnemyAIScripts : MonoBehaviour
{

    public Transform player;
    public float playerDistance;
    public float rotationDamping;
    public float moveSpeed = 2;

	// Use this for initialization
	void Start ()
    {
	


	}
	
	// Update is called once per frame
	void Update ()
    {

        playerDistance = Vector3.Distance(player.position, transform.position);
        // have the enemy look at the player
        if (playerDistance < 15.0f)
        {

            lookAtPlayer();

        }
        if (playerDistance < 12.0f)
        {

            chasePlayer();
            if (playerDistance <= 7.0f)
            {

                moveSpeed = 0;

            }
            else { moveSpeed = 2; }
        }
        

	}

    void lookAtPlayer()
    {

        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        //rotate the enemy

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);

    }

    void chasePlayer()
    {

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }

}
