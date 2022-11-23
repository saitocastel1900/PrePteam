using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransiion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_=>Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_=>LoadScene(_scene)).AddTo(this);
    }

    [SerializeField] private string _scene;
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
