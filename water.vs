#version 450 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormals;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec4 plane;


out vec3 eye ;
//out vec3 fragPos; 
out vec3 normVS ;
out vec3 posVS;


void main()
{
        //normals = aNormals ; 
		normVS = aNormals ;
		posVS = (model * vec4(aPos, 1.0)).xyz; //fragPos = pos\VS
		//	eye = viewPos ;

		//gl_Position = model *vec4(aPos, 1.0); 
}

