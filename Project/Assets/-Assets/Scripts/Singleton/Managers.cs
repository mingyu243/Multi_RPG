using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : SingletonMono<Managers>
{
    DataManager _data = new DataManager();
    ResourceManager _resource = new ResourceManager();
    [SerializeField] NetworkManager _network;

    public static DataManager Data { get { return Instance._data; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static NetworkManager Network { get { return Instance._network; } }

    private void Awake()
    {
        if (Instance != null)
        {
            _network = Instance.gameObject.AddComponent<NetworkManager>();

            //_data.Init();
            _network.Init();
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        _input.OnUpdate();
    }
}
