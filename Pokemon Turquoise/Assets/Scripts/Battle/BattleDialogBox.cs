using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int lettersPerSecond;

    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    // animate dialog letter by letter
    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
    }
}
