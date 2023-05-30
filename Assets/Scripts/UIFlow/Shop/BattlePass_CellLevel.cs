using TMPro;
using UnityEngine;

public class BattlePass_CellLevel : MonoBehaviour
{
    public TMP_Text text;
    public GameObject lockSignal;

    public void SetLevel(int level)
    {
        text.SetText($"{level:N0}");
    }

    public void SetUnlock(bool unLock)
    {
        lockSignal.SetActive(!unLock);
    }
}