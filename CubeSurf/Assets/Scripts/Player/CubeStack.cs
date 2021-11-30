using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeStack : MonoBehaviour
{
    public event Action OnDead; //событие поражения

    [SerializeField]
    private List<CubeCollision> cubes; //собранные кубы игрока
    [SerializeField]
    private GameObject cubePrefab; //префаб куба
    [SerializeField]
    private float offset = 1.1f; //расстояние между кубами

    [SerializeField]
    private int startSize; //начальный размер башни из кубов
    [SerializeField]
    private int maxSize; //максимальный размер

    private void Start()
    {
        for (int i = 0; i < startSize - 1; i++)
        {
            AddCube();
        }
    }

    private void OnEnable()
    {
        foreach (CubeCollision col in cubes)
        {
            SubscribeToEvents(col);
        }
    }
    private void OnDisable()
    {
        foreach (CubeCollision col in cubes)
        {
            UnsubscribeFromEvents(col);
        }
    }

    private void SubscribeToEvents(CubeCollision cube)
    {
        UnsubscribeFromEvents(cube);
        cube.OnRightHit += AddCube;
        cube.OnWrongHit += RemoveCube;
        cube.OnLavaHit += DeleteCube;
    }

    private void UnsubscribeFromEvents(CubeCollision cube)
    {
        cube.OnRightHit -= AddCube;
        cube.OnWrongHit -= RemoveCube;
        cube.OnLavaHit -= DeleteCube;
    }

    /// <summary>
    /// Увеличение башни из кубов
    /// </summary>
    private void AddCube()
    {
        if (cubes.Count < maxSize)
        {
            Transform tempCube = cubes[cubes.Count - 1].transform;
            Transform newpart = (Instantiate(cubePrefab,
                new Vector3(tempCube.position.x, tempCube.position.y - offset, tempCube.position.z),
                tempCube.rotation)).transform;
            newpart.SetParent(transform);
            cubes.Add(newpart.GetComponent<CubeCollision>());
            transform.Translate(Vector3.up * offset);
            SubscribeToEvents(cubes[cubes.Count - 1]);
        }
    }

    /// <summary>
    /// Убрать куб
    /// </summary>
    private void RemoveCube(CubeCollision cube)
    {
        UnsubscribeFromEvents(cube);
        cubes.Remove(cube);
        cube.transform.parent = null;
        cube.enabled = false;
        CheckForCubes();
    }

    /// <summary>
    /// Уничтожить куб
    /// </summary>
    private void DeleteCube(CubeCollision cube)
    {
        UnsubscribeFromEvents(cube);
        cubes.Remove(cube);
        Destroy(cube.gameObject);
        CheckForCubes();

    }

    /// <summary>
    /// Проверка на наличие кубов
    /// </summary>
    private void CheckForCubes()
    {
        if (cubes.Count > 0)
            return;
        OnDead?.Invoke();
    }
}
