using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstLevel", 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
}
