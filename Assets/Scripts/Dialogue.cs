using UnityEngine;
using System.Collections;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public OnDialogueEnd dialogueEndEvent;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool restarted = false;
    private bool finished = false;
    [SerializeField] GameObject started;
   
    void Start()
    {
       textComponent.text=string.Empty;
       StartDialogue();
   }
    void Update()
    {
        if (restarted && started.activeSelf == false)
        {
            textComponent.text = string.Empty;
            StartDialogue();
            restarted = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        Debug.Log("started coroutine"+gameObject.tag);
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (started.activeSelf == true)
            {
                started.SetActive(false);
            }
            finished = true;
            InputManager.instance.SetAble();
            gameObject.SetActive(false);
            if (dialogueEndEvent!=null)
            {
               
                if (!dialogueEndEvent.OnDialogueEndDoEnable)
                {
                    
                    dialogueEndEvent.close_curtain();
                }
                else
                {
                    dialogueEndEvent.Transit();
                }
                    

            }
        }
    }

    private void OnDisable()
    {
        textComponent.text = string.Empty;
        index = 0;
        restarted = true;
        finished = false;
    }
    public bool isDialogueFinished()
    {
        return finished;
    }
    
}