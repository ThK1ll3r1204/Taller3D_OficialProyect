using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockName
{
    Grass,
    Slippery,
    Slow
}

public class BlockFloorID : MonoBehaviour
{
    public BlockName BlockIdentification;
    PlayerMove playerMoveScript;

    void Start()
    {
        playerMoveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (BlockIdentification)
            {
                case BlockName.Grass:
                    break;

                case BlockName.Slippery:
                    playerMoveScript.isCollidingWithSlippery = true;
                    break;

                case BlockName.Slow:
                    playerMoveScript.isCollidingWithSlow = true;
                    break;

                default:
                    break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (BlockIdentification)
            {
                case BlockName.Grass:
                    break;

                case BlockName.Slippery:
                    playerMoveScript.isCollidingWithSlippery = false;
                    break;

                case BlockName.Slow:
                    playerMoveScript.isCollidingWithSlow = false;
                    break;

                default:
                    break;
            }
        }
    }
}
