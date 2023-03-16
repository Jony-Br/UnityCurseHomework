using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DetectCollisionType
{
    Bullet,
    Enemy,
    Wall
}


public class DetectionCollision : MonoBehaviour
{
    [SerializeField] private DetectCollisionType _detectCollisionType;
    public DetectCollisionType Type => _detectCollisionType;

   
}
