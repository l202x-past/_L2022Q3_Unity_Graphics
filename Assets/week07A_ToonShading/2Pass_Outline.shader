Shader "My/NPR/2Pass_Outline"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        // 1st pass
        cull front // 1.frontface culling comment 5.uncomment

        CGPROGRAM
        #pragma surface surf Nolight vertex:vert noshadow noambient

        //sampler2D _MainTex;

        struct Input
        {
            //float2 uv_MainTex;
            float4 color:COLOR;
        };

        // 3.define vert function
        /**********************************
        //https://github.com/TwoTailsGames/Unity-Built-in-Shaders/blob/master/CGIncludes/UnityCG.cginc
        struct appdata_full{
            float4 vertex : POSITION;       // vertex position 
            float4 tangent : TANGENT;       // tangent vector for normal mapping
            float3 normal : NORMAL;         // vertex normal 
            float4 texcoord : TEXCOORD0;    // the 1st uv cord.
            float4 texcoord1 : TEXCOORD1;   // the 2nd uv cord. for lightmap
            float4 texcoord2 : TEXCOORD2;   // the 3rd uv cord. for spare
            float4 texcoord3 : TEXCOORD3;   // the 4th uv cord. for spare
            fixed4 color : COLOR;           // vertex color
            UNITY_VERTEX_INPUT_INSTANCE_ID  // gpu instancing
        }
        **********************************/
        void vert(inout appdata_full v){
            v.vertex.xyz += v.normal.xyz*3;
        }

        void surf (Input IN, inout SurfaceOutput o) // SurfaceOutputStandard --> SurfaceOutput
        {
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            //o.Albedo = c.rgb;
            //o.Alpha = c.a;
        }

        float4 LightingNolight (SurfaceOutput s, float3 lightDir, float atten){
            return float4(0,0,0,1);
        }
        ENDCG

        // 2nd pass
        cull back
        
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG

        
    }
    FallBack "Diffuse"
}
