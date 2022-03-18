using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Header("Parameters Spawner")]
    [SerializeField] private GameObject SpawnPoint;
    [SerializeField] private GameObject SpawnPrefab;
    [SerializeField] private GameObject ParentPrefab;

    [SerializeField] private float _timeSpawnObject;
    [SerializeField] private float _currentTimeSpawnObject = 0f;

    [Header("Parameters Cube")]
    [SerializeField] private float _cubeSpeed;
    [SerializeField] private float _cubeDistance;

    [Header("Parameters Cube")]
    [SerializeField] private InputField InterfaceSpeed;
    [SerializeField] private InputField InterfaceTimeSpawn;
    [SerializeField] private InputField InterfaceDistance;


    private void Update()
    {
        if (CheckInterfaceParameterNull()) return;
        SetParameter();
        ÑalculatingTime();

        if(_currentTimeSpawnObject >= _timeSpawnObject)
        {
            SpawnObject();
            ResetTime();
        }
    }


    private void ÑalculatingTime()
    {
        _currentTimeSpawnObject += Time.deltaTime;
    }

    private void ResetTime()
    {
        _currentTimeSpawnObject = 0;
    }

    private void SpawnObject()
    {
        GameObject SpawnObject = Instantiate(SpawnPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation, ParentPrefab.transform);
        ChangeParameterMoveObject(SpawnObject);
    }

    private void ChangeParameterMoveObject(GameObject Object)
    {
        var componentObject = Object.GetComponent<MoveObject>();

        if(float.TryParse(InterfaceSpeed.text, out float speed)) 
            componentObject._speed = float.Parse(InterfaceSpeed.text);

        if (float.TryParse(InterfaceSpeed.text, out float distance)) 
            componentObject._maxDistance = float.Parse(InterfaceDistance.text); ;
    }

    private void SetParameter()
    {
        if (float.TryParse(InterfaceTimeSpawn.text, out float time))
            _timeSpawnObject = float.Parse(InterfaceTimeSpawn.text);
    }

    private bool CheckInterfaceParameterNull()
    {
        if (InterfaceSpeed.text == "") return true;
        if (InterfaceTimeSpawn.text == "") return true;
        if (InterfaceDistance.text == "") return true;
        return false;
    }
}
