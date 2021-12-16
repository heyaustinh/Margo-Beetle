using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WiggleText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    // Start is called before the first frame update
    void Awake()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _text.ForceMeshUpdate();

        var textInfo = _text.textInfo;

        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            var charInfo = textInfo.characterInfo[i];
            i++;

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] =
                    orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 4f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            _text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
