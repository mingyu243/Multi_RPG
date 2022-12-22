using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : SingletonMono<Managers>
{
    DataManager _data = new DataManager();
    ResourceManager _resource = new ResourceManager();
    
    InputManager _input = new InputManager();
    SceneManagerEx _scene = new SceneManagerEx();
    UIManager _ui = new UIManager();

    LocalPlayerManager _localPlayer = new LocalPlayerManager();
    GamePlayManager _gamePlay = new GamePlayManager();

    [SerializeField] CameraManager _camera; // 코루틴 쓸려고 Monobehaviour 상속받음.
    [SerializeField] NetworkManager _network;


    public static DataManager Data { get { return Instance._data; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    public static InputManager Input { get { return Instance._input; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static UIManager UI { get { return Instance._ui; } }

    public static CameraManager Camera { get { return Instance._camera; } }
    public static LocalPlayerManager LocalPlayer { get { return Instance._localPlayer; } }
    public static GamePlayManager GamePlay { get { return Instance._gamePlay; } }

    public static NetworkManager Network { get { return Instance._network; } }



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance != null)
        {
            _network = this.gameObject.AddComponent<NetworkManager>();
            _camera = this.gameObject.AddComponent<CameraManager>();

            //_data.Init();
        }
    }

    private void Start()
    {
        //_camera.Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }
}
