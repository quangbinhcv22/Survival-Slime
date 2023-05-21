using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMesh : MonoBehaviour
{
    public Sprite instanceSprite;
    public Material instanceMaterial;
    public int instanceCount = 1;

    private Matrix4x4[] matrices;
    private MaterialPropertyBlock properties;
    
    public Mesh mesh;

    void Start()
    {
        matrices = new Matrix4x4[instanceCount];
        properties = new MaterialPropertyBlock();

        var quadMesh = new Mesh();
            
        // // Tạo ma trận biến đổi và thuộc tính cho các phiên bản nhân vật
        // for (int i = 0; i < instanceCount; i++)
        // {
        //     matrices[i] =  // Tính toán ma trận biến đổi
        //     // Set các thuộc tính (nếu cần)
        // }
    }

    void Update()
    {
        Graphics.DrawMeshInstanced(mesh, 0, instanceMaterial, matrices, instanceCount, properties);
    }
}