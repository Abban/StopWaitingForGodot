namespace ClumsyCraig.Interactables
{
    public interface IInteractableView
    {
        public void Reset();
        public void Select();
        public void Deselect();
        public void Nullify();
    }
}