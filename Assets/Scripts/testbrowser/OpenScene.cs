using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void LoadScene(string TestStage)
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(TestStage);
        }
    }
}
