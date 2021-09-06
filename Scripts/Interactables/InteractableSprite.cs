using Godot;

namespace ClumsyCraig.Interactables
{
    public class InteractableSprite : Sprite, IInteractableView
    {
        private ShaderMaterial _material;
        private const string LineThicknessParamName = "line_thickness";

        public override void _Ready()
        {
            base._Ready();
            _material = Material as ShaderMaterial;
        }

        public void Reset()
        {
            Visible = true;
            Deselect();
        }

        public void Select()
        {
            _material.SetShaderParam(LineThicknessParamName, 4);       
        }

        public void Deselect()
        {
            _material.SetShaderParam(LineThicknessParamName, 0);       
        }

        public void Nullify()
        {
            // TODO: This should do an animation or something
            Visible = false;
        }
    }
}
