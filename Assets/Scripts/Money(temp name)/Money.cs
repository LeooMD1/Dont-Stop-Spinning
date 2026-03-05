using UnityEngine;

public class Money : MonoBehaviour
{
    [Header("--------VARIABLES--------")]
    public static float money
    {
        get
        {
            return instance._money;
        }
        set
        {
            instance._money = value;
        }

    }
    [SerializeField] float _money;
    public static Money instance;



    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
