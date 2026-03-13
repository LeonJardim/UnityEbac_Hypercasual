using Leon.Core.Singleton;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : Singleton<ColorManager>
{
    public Material skyMaterial;
    public Material objectsMaterial;
    public Material floorMaterial;
    public List<SO_MapColors> soMapColors;

    public void ChangeMapColors()
    {
        var i = Random.Range(0, soMapColors.Count);

        skyMaterial.color = soMapColors[i].skyColor;
        objectsMaterial.color = soMapColors[i].objectsColor;
        floorMaterial.color = soMapColors[i].floorColor;
    }
}
