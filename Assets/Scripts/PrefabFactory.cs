using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Zenject;

public abstract class PrefabFactory<T> where T: MonoBehaviour
{
    [Inject] private DiContainer _container;
    private JArray configJArray;
    
    private Dictionary<string, T> _instantiatedDictionary;
    private Dictionary<string, JToken> _tokensDictionary;

    public PrefabFactory(TextAsset config)
    {
        //_prefabsDictionary = new Dictionary<string, T>();
        _instantiatedDictionary = new Dictionary<string, T>();
        _tokensDictionary = new Dictionary<string, JToken>();
        
        configJArray = JArray.Parse(config.text);
        foreach (var token in configJArray)
        {
            _tokensDictionary.Add(token["Id"].ToString(), token);
        }
    }
    
    /*private T Load(string name)
    {
        var screenView = Resources.Load<T>($"Screens/{name}");
        return screenView;
    }

    public T GetObject(string id)
    {
        if (_instantiatedDictionary.ContainsKey(id))
        {
            return _instantiatedDictionary[id];
        }
        else if(_tokensDictionary.ContainsKey(id))
        {
            T obj = GetObject(_tokensDictionary[id]);
            _prefabsDictionary.Add(id, obj);
        }
    }

    private T Create(string id)
    {
        JToken token = _tokensDictionary[id];
        
        var name = token["Name"].ToString();
        
        
        var instantiated = _container.InstantiatePrefabForComponent<T>(obj);
        _instantiatedDictionary.Add(id,instantiated);

        return instantiated;
    }
    
    protected abstract T GetObject(JToken jToken);*/

}