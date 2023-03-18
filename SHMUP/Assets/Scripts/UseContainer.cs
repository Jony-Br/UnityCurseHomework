using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseContainer : MonoBehaviour
{
    [SerializeField] private ContainerEnemy _containerExample;
    [SerializeField] private ShipType _shipToUse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Use Container")]
    private void TestUseContainer()
    {
        var shipData = _containerExample.GetShip(_shipToUse);
        Debug.Log($"[{GetType().Name}][TestUseContainer] ShipData: {shipData}");
        
    }

    [ContextMenu("Use Container Dictionary")]
    private void TestUseContainerDictionary()
    {
        var shipData = _containerExample.GetShipDictionary(_shipToUse);
        Debug.Log($"[{GetType().Name}][TestUseContainer] ShipData: {shipData}");
    }
}