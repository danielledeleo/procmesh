using Godot;

[Tool]
public partial class my_mesh : Node3D
{
	[Export]
	private float rotationSpeed = 1.0f;
	public float RotationSpeed {
		get => rotationSpeed / 2.0f;
		set => rotationSpeed = value;
	}
	private double _elapsedTime = 0.0f;

	public MeshInstance3D MeshRender { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MeshRender = new MeshInstance3D
		{
			Mesh = new BoxMesh()
		};

		AddChild(MeshRender);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_elapsedTime += delta;
		RotateY((float)delta * RotationSpeed * (Mathf.Sin((float)_elapsedTime * 1.0f * Mathf.Pi)+2.0f));
	}
}
