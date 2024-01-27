using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    //public Button button;
    // Start is called before the first frame update
    void Start()
    {
        //Button btn = button.GetComponent<Button>();
        //btn.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
   void Update()
    {

    }
    public void OnButtonClick()
    {
        SceneManager.LoadScene("TestStage", LoadSceneMode.Single);
        //このスクリプトは必ずTestBrowserの方に
        //https://umistudioblog.com/scenetransitionbutton/ 
    }
}
