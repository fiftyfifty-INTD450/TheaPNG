using UnityEngine;
using System;

[Serializable]
public class FSPasswordInfo
{
    [SerializeField]
    private string password;
    [SerializeField]
    private string hint;

    public static FSPasswordInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<FSPasswordInfo>(jsonString);
    }

    public FSPasswordInfo(string password, string hint)
    {
        this.password = password;
        this.hint = hint;
    }

    public void SetPassword(string password)
    {
        this.password = password;
    }

    public void SetHint(string hint)
    {
        this.hint = hint;
    }

    public string GetPassword()
    {
        return password;
    }

    public string GetHint()
    {
        return hint;
    }
}
