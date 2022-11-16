#version 330 core
layout(triangles) in ;
layout(triangle_strip, max_vertices = 3) out ;
vec3 getNormal() ;

in vec3 normES [];
in vec3 fragPosFS[] ;

in vec3 tessNormals[];
in vec3 eyePos[];
in float visibility[];
uniform mat4 view;
uniform mat4 model;
uniform mat4 projection;
uniform vec4 plane;

in gl_PerVertex
{
  vec4 gl_Position;
  float gl_PointSize;
  float gl_ClipDistance[];
} gl_in[];

out vec2 texES;
out vec3 fragPosGS ;
out vec3 tessNormalsGs;
out vec3 eyePosGS;
out float visibilityGs;


out vec3 gNormals ;
out vec3 gWorldPos_FS_in ;
//out vec3 gFrag ;





void main()
{

   for(int i = 0 ; i < 3; i++)
   {

   gl_Position = gl_in[i].gl_Position ;

  


    vec4 vertexPositions =  vec4(fragPosFS[i],1.0) ;
        gl_ClipDistance[0] = dot(vec4(vertexPositions), plane);
  

      fragPosGS = fragPosFS[i] ;

      visibilityGs = visibility[i] ;
      eyePosGS = eyePos[i] ;
	 tessNormalsGs = tessNormals[i];

      tessNormalsGs = getNormal() ;    
	  //look at
       
      EmitVertex() ;
       
  }

     EndPrimitive() ;

}


vec3 getNormal()
{
    vec3 a = vec3(gl_in[1].gl_Position) - vec3(gl_in[0].gl_Position);
    vec3 b = vec3(gl_in[2].gl_Position) - vec3(gl_in[0].gl_Position);
    return normalize(cross(a, b));
}