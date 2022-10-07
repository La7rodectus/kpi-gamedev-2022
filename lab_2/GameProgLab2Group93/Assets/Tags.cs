using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    
    [SerializeField]
    private List<string> tags = new List<string>();

    public bool Has(string tag)
    {
        return tags.Contains(tag);
    }

    public IEnumerable<string> Get()
    {
        return tags;
    }

    public void Rename(int index, string tagName)
    {
        tags[index] = tagName;
    }

    public string At(int index)
    {
        return tags[index];
    }

    public int Size
    {
        get { return tags.Count; }
    }
    
}
