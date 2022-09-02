using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : SingletonMono<Managers>
{
    DataManager _data = new DataManager();
    ResourceManager _resource = new ResourceManager();
    
    InputManager _input = new InputManager();
    SceneManagerEx _scene = new SceneManagerEx();

    CameraManager _camera = new CameraManager();
    LocalPlayerManager _localPlayer = new LocalPlayerManager();
    GamePlayManager _gamePlay = new GamePlayManager();


    [SerializeField] NetworkManager _network;

    public static DataManager Data { get { return Instance._data; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static InputManager Input { get { return Instance._input; } }
    public static NetworkManager Network { get { return Instance._network; } }
    public static CameraManager Camera { get { return Instance._camera; } }
    public static LocalPlayerManager LocalPlayer { get { return Instance._localPlayer; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static GamePlayManager GamePlay { get { return Instance._gamePlay; } }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance != null)
        {
            _network = this.gameObject.AddComponent<NetworkManager>();

            //_data.Init();
        }
    }

    private void Start()
    {
        _network.Init();
        _localPlayer.Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }
}
