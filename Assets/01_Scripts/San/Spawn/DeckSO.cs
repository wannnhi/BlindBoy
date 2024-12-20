using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "SO/Deck")]
public class DeckSO : ScriptableObject
{
    public List<EntityStatusSO> agentDeckList = new List<EntityStatusSO>();

    private const string SaveFileName = "DeckData.json";

    public void InitDeck()
    {
        agentDeckList.Clear();
    }

    public void SaveDeck()
    {
        DeckData data = new DeckData();

        foreach (var agent in agentDeckList)
        {
            data.agentNames.Add(agent.name); // 필요한 데이터 추가
        }

        SaveManager.Save(SaveFileName, data);
    }

    public void LoadDeck()
    {
        DeckData data = SaveManager.Load<DeckData>(SaveFileName);

        // 기존 데이터를 초기화하고 새 데이터 추가
        agentDeckList.Clear();

        foreach (var agentName in data.agentNames)
        {
            // 이름으로 EnityStatusSO를 찾아서 리스트에 추가
            EntityStatusSO foundAgent = Resources.Load<EntityStatusSO>($"Path/To/Agents/{agentName}");
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
