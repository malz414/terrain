
#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 Position;

uniform vec3 viewPos;

uniform sampler2D refraction;


void main()
{             
vec3 col = texture(refraction, Normal).rgb;
    FragColor = vec4(col, 1.0);
}