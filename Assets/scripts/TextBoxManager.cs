using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;

    public Text myText;

    public TextAsset textfile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerController player;

    public bool isActive;

    public bool stopPlayerMovement;

    public bool isTyping = false;
    public bool cancelTyping = false;

    public float typingSpeed;

    public AudioSource dialogTickSound;

    public AudioSource music;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (textfile != null)
        {
            textLines = textfile.text.Split('\n');
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if(isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(!isTyping)
            {
                currentLine += 1;

                if(currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(isTyping && cancelTyping)
            {
                cancelTyping = true;
            }
        }

        if(currentLine > endAtLine)
        {
            DisableTextBox();
        }
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int soundCue = 0;
        int letter = 0;
        myText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            myText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typingSpeed);
            soundCue += 1;
            if(soundCue == 4)
            {
                dialogTickSound.Play();
                soundCue = 0;
            }
        }
        myText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;

    }

    public IEnumerator MusicVolumeDown()
    {
        while(music.volume >= 0.05f) {
            music.volume -= 0.001f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator MusicVolumeUp()
    {
        while (music.volume <= 0.2f)
        {
            music.volume += 0.001f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if(stopPlayerMovement)
        {
            player.canMove = false;
        }
        StartCoroutine(TextScroll(textLines[currentLine]));
        StartCoroutine(MusicVolumeDown());
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        player.canMove = true;
        StartCoroutine(MusicVolumeUp());
    }

    public void ReloadScript(TextAsset myText)
    {
        if(myText !=  null)
        {
            textLines = new string[1];
            textLines = myText.text.Split('\n');
        }
    }
}