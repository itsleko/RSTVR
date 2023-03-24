using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Action
{
    public string Purpose;
    public string Mistake;
    public string Right;

    public Action(string purpose, string mistake, string right)
    {
        Purpose = purpose;
        Mistake = mistake;
        Right = right;
    }
}

[System.Serializable]
public class Message
{
    public string Text;
    public Color Color;
    public MessageType Type;

    public Message(string text, Color color, MessageType type)
    {
        Text = text;
        Color = color;
        Type = type;
    }
}

public enum MessageType
{
    PURPOSE,
    MISTAKE,
    RIGHT
}

public class ConsoleController : MonoBehaviour
{
    [SerializeField] private List<Action> actions = new List<Action>();

    [SerializeField] private Vector2 MessageSpawnPoint;
    [SerializeField] private GameObject MessagePref;

    [SerializeField] public static List<TextMeshProUGUI> GeneratedMessages = new List<TextMeshProUGUI>();

    private void Start()
    {
        
    }

    public void SpawnMessage(MessageType messageType, Action action)
    {
        GameObject SpawnedMessage = Instantiate(MessagePref, MessageSpawnPoint, Quaternion.identity, GameObject.Find("Console").transform.GetChild(0).transform);
        SpawnedMessage.transform.Rotate(90, 0, 0);

        switch (messageType)
        {
                case MessageType.PURPOSE:
                {
                    SpawnedMessage.GetComponent<TextMeshProUGUI>().color = Color.grey;
                    SpawnedMessage.GetComponent<TextMeshProUGUI>().text = action.Purpose;
                }
                break;

                case MessageType.MISTAKE:
                {
                    SpawnedMessage.GetComponent<TextMeshProUGUI>().color = Color.red;
                    SpawnedMessage.GetComponent<TextMeshProUGUI>().text = action.Mistake;
                }
                break;

                case MessageType.RIGHT:
                {
                    SpawnedMessage.GetComponent<TextMeshProUGUI>().color = Color.green;
                    SpawnedMessage.GetComponent<TextMeshProUGUI>().text = action.Right;
                }
                break;
        }
        GeneratedMessages.Add(SpawnedMessage.GetComponent<TextMeshProUGUI>());

        if(GeneratedMessages.Count > 5)
        {
            Destroy(GeneratedMessages[0].gameObject);
            GeneratedMessages.RemoveAt(0);
            actions.RemoveAt(0);
        }
    }
}
