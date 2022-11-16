
#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;

out vec3 Normal;
out vec3 Position;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec4 plane;

in gl_PerVertex
{
  vec4 gl_Position;
  float gl_PointSize;
  float gl_ClipDistance[];
} gl_in[];

void main()
{
    Normal = mat3(transpose(inverse(model))) * aNormal;
    Position = vec3(model *  vec4(aPos, 1.0));

	
  // gl_ClipDistance[0] = dot(vec4(Position), plane);
      gl_Position = projection * view * vec4(Position, 1.0);
}  