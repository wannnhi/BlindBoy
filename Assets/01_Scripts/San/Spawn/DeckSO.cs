using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "SO/Deck")]
public class DeckSO : ScriptableObject
{
    public List<EnityStatusSO> agentDeckList = new List<EnityStatusSO>();

    private const string SaveFileName = "DeckData.json";

    public void SaveDeck()
    {
        DeckData data = new DeckData();

        foreach (var agent in agentDeckList)
        {
            data.agentNames.Add(agent.name); // �ʿ��� ������ �߰�
        }

        SaveManager.Save(SaveFileName, data);
    }

    public void LoadDeck()
    {
        DeckData data = SaveManager.Load<DeckData>(SaveFileName);

        // ���� �����͸� �ʱ�ȭ�ϰ� �� ������ �߰�
        agentDeckList.Clear();

        foreach (var agentName in data.agentNames)
        {
            // �̸����� EnityStatusSO�� ã�Ƽ� ����Ʈ�� �߰�
            EnityStatusSO foundAgent = Resources.Load<EnityStatusSO>($"Path/To/Agents/{agentName}");
            if (foundAgent != null)
            {
                agentDeckList.Add(foundAgent);
            }
            else
            {
                Debug.LogWarning($"Agent '{agentName}' not found in Resources.");
            }
        }
    }
}



[System.Serializable]
public class DeckData
{
    public List<string> agentNames = new List<string>();
}
