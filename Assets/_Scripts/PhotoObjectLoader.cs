using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PhotoObjectLoader : MonoBehaviour
{
    [SerializeField] string[] foldersToSearch = { "Assets/_Input" };

    int _index;
    GameObject _photoObject;
    List<GameObject> _allPrefabs;

    void Awake()
    {
        _allPrefabs = GetAssets<GameObject>(foldersToSearch, "t:prefab");
    }

    private IEnumerator Start()
    {
        EventsManager.instance.onPhotoObjectChange += PhotoObjectChange;
        yield return new WaitForSeconds(0.01f);
        GetNewPhotoObject();
    }

    private void OnDestroy()
    {
        EventsManager.instance.onPhotoObjectChange -= PhotoObjectChange;
    }

    private void PhotoObjectChange(bool isNext)
    {
        GetNewIndex(isNext);
        GetNewPhotoObject();
    }

    void GetNewIndex(bool isNext)
    {
        if (isNext)
        {
            _index++;
            if (_index > _allPrefabs.Count - 1) _index = 0;
        }
        else
        {
            _index++;
            if (_index < 0) _index = _allPrefabs.Count - 1;
        }
    }

    void GetNewPhotoObject()
    {
        if (_photoObject != null) Destroy(_photoObject);

        GameObject obj = Instantiate(_allPrefabs[_index], transform.position, Quaternion.identity) as GameObject;
        _photoObject = obj;
        EventsManager.instance.NewPhotoObjectCreated(obj);
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
