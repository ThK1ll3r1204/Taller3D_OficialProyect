using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFloorID : MonoBehaviour
{
    public enum BlockName
    {
        Grass,
        Slippery,
        Slow
    }

    public class PowerUpID : MonoBehaviour
    {
        public BlockName BlockIdentification;
    }

}
