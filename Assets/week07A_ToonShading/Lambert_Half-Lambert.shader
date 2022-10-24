Shader "My/Lambert/Half-Lambert"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf MyCustom noambient

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

        float4 LightingMyCustom(SurfaceOutput s, float3 lightDir, float atten){
            // dot operation with Normal and lightDir
            float ndotl = dot(s.Normal, lightDir) * 0.5 + 0.5; 

            return ndotl;
            //return pow(ndotl, 3);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
