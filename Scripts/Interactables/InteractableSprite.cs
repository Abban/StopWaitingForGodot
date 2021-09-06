using Godot;

public class InteractableSprite : Sprite
{
    private ShaderMaterial _material;
    private const string LineThicknessParamName = "line_thickness";

    public override void _Ready()
    {
        base._Ready();
        _material = Material as ShaderMaterial;
    }

    public void Select()
    {
        _material.SetShaderParam(LineThicknessParamName, 4);       
    }

    public void Deselect()
    {
        _material.SetShaderParam(LineThicknessParamName, 0);       
    }
}
