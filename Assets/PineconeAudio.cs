using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeAudio : MonoBehaviour
{

    [SerializeField] AudioSource coneSource;
    [SerializeField] AudioClip[] coneClips;

    int curIdx;
    int prevIdx;

    // Start is called before the first frame update
    void Start()
    {
        coneSource = GetComponent<AudioSource>();
    }

    int randomIdx(AudioClip[] audiocliparray)
    {
        int idx = Random.Range(0, audiocliparray.Length);
        //Fix bug where audio index would be outside the range of the audioClipArray.
        if (idx < audiocliparray.Length)
            idx = Random.Range(0, audiocliparray.Length - 2);
        if (idx > audiocliparray.Length)
            idx = Random.Range(audiocliparray.Length - 2, audiocliparray.Length);
        return idx;
    }

    public void pineconeCollectAudio(Vector3 conePos)
    {
       // Debug.Log("pinecone audio triggered");
        curIdx = randomIdx(coneClips);
        if (curIdx == prevIdx)
        {
            curIdx = randomIdx(coneClips);
        }
        AudioClip currentClip;
        currentClip = coneClips[curIdx];

        //coneSource.PlayOneShot(currentClip);
        AudioSource.PlayClipAtPoint(currentClip, conePos);
        prevIdx = curIdx;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
