#version 330 core
out vec4 FragColor ;

in vec3 tessNormalsGs ;
in vec2 texES ;
in mat3 TBN;
in vec3 fragPosGS ;
in vec3 eyePosGS;
in float visibilityGs;

in vec3 gNormals ;

uniform vec3 lightCol;
uniform vec3 lightPos;  
uniform vec3 object;  
uniform vec3 viewPos;
uniform int scale;
uniform vec3 sky;

uniform sampler2D reflection;
uniform sampler2D refraction;
uniform float screenW;
uniform float screenH;


void main()
{


	float specularStrength = 0.4;
    float ambientStrength = 0.2;
    vec3 ambient = ambientStrength * object *lightCol;

	vec3 norm = normalize(tessNormalsGs);
	vec3 lightDir = normalize(fragPosGS - lightPos );  
	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * lightCol;


	vec3 viewDir = normalize(eyePosGS - fragPosGS);
	vec3 reflectDir = reflect(-lightDir, tessNormalsGs);  
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), 16);
	vec3 specular = specularStrength * spec * lightCol;  
	//	shader.setVec3("sky", vec3(RED, GREEN, BLUE));

	vec3 result = (ambient + diffuse + specular) * object ;

	FragColor = vec4(result, 1.0);

	FragColor = mix(vec4(sky, 1.0), FragColor, visibilityGs);


	float height = fragPosGS.y/scale;
	vec4 green = vec4(0.3, 0.35, 0.15, 0.0);
	vec4 white = vec4(0.9, 0.9, 0.9, 0.0);

	//if (height > 0.6)
	//FragColor = vec3(mix(green, white,smoothstep(0.3,0.1,height)).rgb);
	
}
	
