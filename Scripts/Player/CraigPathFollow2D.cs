using Godot;

public class CraigPathFollow2D : PathFollow2D
{
    public void Move(float delta)
    {
        Offset += 250 * delta;
    }

    public void Reset()
    {
        Offset = 0;
    }
}
