using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoObjectLoader : MonoBehaviour
{
    [SerializeField] string foldersToSearch = "Input";

    int _index;
    GameObject _photoObject;
    Object[] _allPrefabs;

    void Awake()
    {
        _allPrefabs = Resources.LoadAll(foldersToSearch, typeof(GameObject));
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
            if (_index > _allPrefabs.Length - 1) _index = 0;
        }
        else
        {
            _index--;
            if (_index < 0) _index = _allPrefabs.Length - 1;
        }
    }

    void GetNewPhotoObject()
    {
        if (_photoObject != null) Destroy(_photoObject);

        GameObject obj = Instantiate(_allPrefabs[_index], transform.position, Quaternion.identity) as GameObject;
        _photoObject = obj;
        EventsManager.instance.NewPhotoObjectCreated(obj);
    }
}
