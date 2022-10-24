Shader "My/NPR/2Pass_Outline+Discontinuous"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        // 1st pass

        cull front

        CGPROGRAM

        #pragma surface surf Nolight vertex:vert noshadow  noambient

        //sampler2D _MainTex;

        struct Input
        {
            float4 color:COLOR;
        };

        void vert(inout appdata_full v){
            v.vertex.xyz += v.normal.xyz*1;
        }

        void surf (Input IN, inout SurfaceOutput o) 
        {
        }

        float4 LightingNolight (SurfaceOutput s, float3 lightDir, float atten){
            return float4(0,0,0,1);
        }
        ENDCG

        // 2nd pass

        cull back        

        CGPROGRAM
        #pragma surface surf Toon noambient 

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
        
        float4 LightingToon (SurfaceOutput s, float3 lightDir, float atten){
            float ndotl = dot(s.Normal, lightDir) * 0.5 + 0.5;
            ndotl = ndotl * 5;
            ndotl = ceil(ndotl)/5;

            return ndotl; 
        }
        
        ENDCG

        
    }
    FallBack "Diffuse"
}
