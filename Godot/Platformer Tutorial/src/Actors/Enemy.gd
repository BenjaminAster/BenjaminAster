extends "res://src/Actors/Actor.gd"

func _ready() -> void:
	_velocity.x = -speed.x

func _physics_process(delta: float) -> void:
	_velocity.y += gravity * delta
	if is_on_wall():
		_velocity.x *= -1
	_velocity.y = move_and_slide(_velocity, FLOOR_NORMAL).y




# Declare member variables here. Examples:
# var a: int = 2
# var b: String = "text"


# Called when the node enters the scene tree for the first time.
# func _ready() -> void:
#	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta: float) -> void:
#	pass
