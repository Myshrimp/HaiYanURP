
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class OnDialogueEnd : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] GameObject loading;
    [SerializeField] GameObject enable_dialogue;
    public Light2D global_light;
    public bool OnDialogueEndDoEnable = false;
    public void Transit()
    {
        Debug.Log("OnDialoue");
        if(!OnDialogueEndDoEnable)
        SceneManager.LoadScene(sceneName);
        if(OnDialogueEndDoEnable)
        {
            enable_dialogue.SetActive(true);
            Debug.Log("Gun visible");
        }
    }
    public void close_curtain()
    {
        global_light.intensity = 0;
        loading.SetActive(true);
        Invoke(nameof(Transit), 0.2f);
    }
}
