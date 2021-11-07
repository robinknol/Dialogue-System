using System;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

namespace Script.DialogueManager
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private Text textDisplay;
        [SerializeField] private GameObject[] buttons;
        
        private JsonData _dialogue;
        private JsonData _currentLayer;
        
        private int _index;
        private bool _inDialogue;
        private string _speaker;

        public bool LoadDialogue(string sceneNamePath, int conversationNumPath)
        {
            if (_inDialogue) return false;
            
            _index = 0;
            var jsonTextFile = Resources.Load<TextAsset>("Dialogues/" + sceneNamePath + "/JSON/Dialogue" + conversationNumPath.ToString());
            _dialogue = JsonMapper.ToObject(jsonTextFile.text);
            _currentLayer = _dialogue;
            _inDialogue = true;
            return true;
        }

        public bool PrintLine()
        {
            if (_inDialogue)
            {
                var line = _currentLayer[_index];

                foreach (JsonData key in line.Keys)
                {
                    _speaker = key.ToString();
                }

                Debug.Log(_speaker);

                switch (_speaker)
                {
                    case "EOD":
                        _inDialogue = false;
                        textDisplay.text = "";
                        return false;
                    
                    case "?":
                        var options = line[0];
                        textDisplay.text = "";
                        for (var optionsNumber = 0; optionsNumber < options.Count; optionsNumber++)
                        {
                            ActivateButton(buttons[optionsNumber], options[optionsNumber]);
                        }
                        break; 
                    
                    default:
                        textDisplay.text = _speaker + ": " + line[0];
                        _index++;
                        break;
                }
            }
            return true;
        }

        private void DeactivateButtons()
        {
            foreach (var button in buttons)
            {
                button.SetActive(false);
                button.GetComponentInChildren<Text>().text = "";
                button.GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }

        private void ActivateButton(GameObject button, JsonData choice)
        {
            button.SetActive(true);
            button.GetComponentInChildren<Text>().text = choice[0][0].ToString();
            button.GetComponent<Button>().onClick.AddListener(delegate { ToDoOnClick(choice); });
        }

        private void ToDoOnClick(JsonData choice)
        {
            _currentLayer = choice[0];
            _index = 1;
            PrintLine();
            DeactivateButtons();
        }

        private void Awake()
        {
            DeactivateButtons();
        }
    }
}
