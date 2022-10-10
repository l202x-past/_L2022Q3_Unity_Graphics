Shader "My/Cube"
{
    Properties //게임사 그래픽
    {   //인터페이스 생성
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Red ("Red", Range(0,1))= 0
        _Green ("Green", Range(0,1)) = 0
        _Blue ("Blue", Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        CGPROGRAM //그래픽사 그래픽
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color; //같은 이름의 변수 하나 더 생성
        float _Red;
        float _Green;
        float _Blue;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color; //4개의 변수 생성 r,g,b,a
            //o.Albedo = c.rgb; //표면
            o.Albedo = float3(_Red, _Green, _Blue);
            o.Alpha = c.a; //투명도
        }
        ENDCG
    }
    FallBack "Diffuse"
}
