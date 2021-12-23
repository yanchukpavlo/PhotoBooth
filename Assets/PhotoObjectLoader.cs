using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PhotoObjectLoader : MonoBehaviour
{
    [SerializeField] string[] foldersToSearch = { "Assets/_Input" };

    List<GameObject> allPrefabs;

    void Awake()
    {
        allPrefabs = GetAssets<GameObject>(foldersToSearch, "t:prefab");
    }

    private void Start()
    {
        GetNewPhotoObject(0);
    }

    void GetNewPhotoObject(int index)
    {
        GameObject newRoom = Instantiate(allPrefabs[index], transform.position, Quaternion.identity) as GameObject;
    }

    List<T> GetAssets<T>(string[] _foldersToSearch, string _filter) where T : Object
    {
        string[] guids = AssetDatabase.FindAssets(_filter, _foldersToSearch);
        List<T> list = new List<T>();
        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            list.Add(AssetDatabase.LoadAssetAtPath<T>(path));
        }
        return list;
    }
}
