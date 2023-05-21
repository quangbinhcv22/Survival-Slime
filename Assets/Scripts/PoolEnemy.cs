using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class PoolEnemy : MonoBehaviour
{
    public static PoolEnemy Main;

    private void OnEnable()
    {
        Main = this;
    }

    private void OnDisable()
    {
        Release();
    }


    private static readonly Dictionary<string, List<GameObject>> Pool = new();

    public static void Get(string key, Action<GameObject> completed)
    {
        if (!Pool.ContainsKey(key)) Pool.Add(key, new());
        var result = Pool[key].FirstOrDefault(e => !e.activeSelf);

        if (result)
        {
            result.gameObject.SetActive(true);
            completed?.Invoke(result);
        }
        else
        {
            Instantiate(key, iResult =>
            {
                Pool[key].Add(iResult);
                completed?.Invoke(iResult);
            });
        }
    }

    private static void Instantiate(string key, Action<GameObject> completed)
    {
        var position = new Vector3(999, 999);
        Addressables.InstantiateAsync(key,position, Quaternion.identity, Main.transform).Completed += handle => completed?.Invoke(handle.Result);
    }

    private static void Release()
    {
        foreach (var value in Pool.Values.SelectMany(values => values))
        {
            Destroy(value);
        }

        Pool.Clear();
    }
}