Shader "Custom/TestECSShader"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1,0.5,0.2,1)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }

        Pass
        {
            Name "ForwardBase"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            // vertex/frag
            #pragma vertex vert
            #pragma fragment frag

            #pragma target 4.5
            #pragma multi_compile _ DOTS_INSTANCING_ON
            #pragma enable_cbuffer

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
           
            // Затем подключаем DOTS instancing helpers из SRP core:

            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityDOTSInstancing.hlsl"

            
            CBUFFER_START(UnityPerMaterial)
               float4 _BaseColor; 
            CBUFFER_END
            
            
            struct Attributes
            {
                float4 positionOS : POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                UNITY_SETUP_INSTANCE_ID(IN);
                UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(IN);
                return _BaseColor;
                //float4 col  = UNITY_ACCESS_INSTANCED_PROP(float4, _BaseColor);
                //return col;
            }
            ENDHLSL
        }
    }
}