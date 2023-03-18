using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerEnemy : MonoBehaviour
{
    [SerializeField] private List<ShipData> _shipDatas = new List<ShipData>();
    private Dictionary<ShipType, ShipData> _shipDataDictionary = new Dictionary<ShipType, ShipData>();
    public ShipData GetShip(ShipType type)
    {
        var result = _shipDatas.Find(shipData => shipData.Type == type);
        return result;
    }

    public ShipData GetShipDictionary(ShipType type)
    {
        if (_shipDataDictionary.ContainsKey(type))
        {
            return _shipDataDictionary[type];
        }

        return null;
    }

    private void Awake()
    {
        PrepareDictionary();
    }

    private void PrepareDictionary()
    {
        foreach (var data in _shipDatas)
        {
            _shipDataDictionary[data.Type] = data;
        }
    }

}

public enum ShipType
{
    Destroyer,
    Himera,
    Keeper
}

[System.Serializable]
public class ShipData
{
    [SerializeField] private ShipType _type;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _healthPoint;
    [SerializeField] private int _scorePoint;
    [SerializeField] private int _damage;
    [SerializeField] private int _price;

    public ShipType Type => _type;
    public float MovementSpeed => _movementSpeed;
    public int HealthPoint => _healthPoint;
    public int ScorePoint => _scorePoint;
    public int Damage => _damage;
    public int Price => _price;

    public override string ToString()
    {
        return $"Type: {Type}, Speed: {_movementSpeed}, HP: {_healthPoint}, Score: {_scorePoint}, Damage: {_damage}, Price: {_price}";
    }

}