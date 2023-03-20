using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyShipTypes
{
    Keeper,
    Destroyer,
    Himera

}

public class EnemyShipType : MonoBehaviour
{
    [SerializeField] private EnemyShipTypes _enemyShipTypes;
    public EnemyShipTypes Type => _enemyShipTypes;
}
