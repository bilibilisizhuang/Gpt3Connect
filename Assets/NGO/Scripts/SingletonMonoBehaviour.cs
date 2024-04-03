using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
    private static T _instance;

    // 获取单例实例的属性
    public static T Instance {
        get {
            // 如果尚未创建实例，则查找现有实例
            if (_instance == null) {
                _instance = FindObjectOfType<T>();

                // 如果找不到现有实例，则创建一个新的实例
                if (_instance == null) {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    // 防止通过new关键字创建实例
    protected SingletonMonoBehaviour() { }

    // 确保实例在场景切换时不会被销毁
    protected virtual void Awake() {
        if (_instance == null) {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
