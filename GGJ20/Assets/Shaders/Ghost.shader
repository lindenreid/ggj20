Shader "Custom/Ghost"
{
    Properties
    {
        _AbberationR ("R-Offset", Float) = 0.1
        _AbberationG ("G-Offset", Float) = -0.1
        _AbberationB ("B-Offset", Float) = 0.0
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            CGPROGRAM
            #pragma vertex SpriteVert
            #pragma fragment frag
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile_local _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA

            #include "UnitySprites.cginc"

            float _AbberationR;
            float _AbberationG;
            float _AbberationB;

            fixed4 frag (v2f i) : COLOR
            {
                fixed2 r = SampleSpriteTexture(float2(i.texcoord.x+_AbberationR, i.texcoord.y)).ra;
                fixed2 g = SampleSpriteTexture(float2(i.texcoord.x+_AbberationG, i.texcoord.y)).ga;
                fixed2 b = SampleSpriteTexture(float2(i.texcoord.x+_AbberationB, i.texcoord.y)).ba;
                fixed a = max(b.y, max(r.y, g.y));
                fixed4 color = fixed4(r.x, g.x, b.x, a);

                color.a *= i.color.a;

                return color;
            }
            ENDCG
        }
    }

Fallback "Sprites/Diffuse"
}