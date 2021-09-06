using Godot;

public class CraigCollider : Area2D
{
    [Signal] public delegate void WinSignal();

    private const string WinArea = "WinArea";
    
    
    public override void _Ready()
    {
        
    }

    public void OnAreaEnter(KinematicBody2D body)
    {
        GD.Print("I entered a thingy");
        GD.Print(body.Name);

        // switch (body.Name)
        // {
        //     case WinArea:
        //         EmitSignal(nameof(WinSignal));
        //         break;
        // }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}