using UnityEngine;

namespace Script.DialogueManager
{
    public class DialogueTrigger : MonoBehaviour
    {
        public DialogueManager dialogueManager;
        [SerializeField] private GameObject player;

        public string sceneNamePath;
        public int conversationNumPath;
        
        private bool _inTrigger;
        private bool _dialogueLoaded;
        private void Awake()
        {
            if (!(dialogueManager == null)) return;

            dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!(other.gameObject == player)) return;

            _inTrigger = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!(other.gameObject == player)) return;

            _inTrigger = false;
        }

        private void RunDialogue(bool keyTrigger)
        {
            if (!keyTrigger) return;

            if (_inTrigger && !_dialogueLoaded)
                _dialogueLoaded = dialogueManager.LoadDialogue(sceneNamePath, conversationNumPath);
            
            if (_dialogueLoaded)
                _dialogueLoaded = dialogueManager.PrintLine();
        }

        private void Update()
        {
            RunDialogue(Input.GetKeyDown(KeyCode.C));
        }
    }
}