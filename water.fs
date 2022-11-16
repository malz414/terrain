#version 410 core
out vec4 FragColor;

uniform sampler2D reflection;
uniform sampler2D refraction;

in vec3 uv ;
in vec3 fragPos;



void main()
{   

	   //vec2 ndcXY = gl_FragCoord.xy;

  //   vec4 reflect = texture(reflection, uv);
  //   vec4 reflect = texture(refraction, uv);
  //   FragColor = mix(reflect, refract, 0.5);


}

