["#version 100\n\nuniform \tvec4 _ScreenParams;\nuniform \tvec4 hlslcc_mtx4x4unity_ObjectToWorld[4];\nuniform \tvec4 hlslcc_mtx4x4glstate_matrix_projection[4];\nuniform \tvec4 hlslcc_mtx4x4unity_MatrixVP[4];\nuniform \tmediump vec4 _Color;\nuniform \tvec4 _ClipRect;\nuniform \tvec4 _MainTex_ST;\nuniform \tfloat _UIMaskSoftnessX;\nuniform \tfloat _UIMaskSoftnessY;\nattribute highp vec4 in_POSITION0;\nattribute highp vec4 in_COLOR0;\nattribute highp vec2 in_TEXCOORD0;\nvarying mediump vec4 vs_COLOR0;\nvarying highp vec2 vs_TEXCOORD0;\nvarying highp vec4 vs_TEXCOORD1;\nvarying highp vec4 vs_TEXCOORD2;\nvec4 u_xlat0;\nvec4 u_xlat1;\nvoid main()\n{\n    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];\n    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;\n    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;\n    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];\n    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];\n    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;\n    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;\n    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;\n    gl_Position = u_xlat0;\n    u_xlat1 = in_COLOR0 * _Color;\n    vs_COLOR0 = u_xlat1;\n    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;\n    vs_TEXCOORD1 = in_POSITION0;\n    u_xlat0.xy = _ScreenParams.yy * hlslcc_mtx4x4glstate_matrix_projection[1].xy;\n    u_xlat0.xy = hlslcc_mtx4x4glstate_matrix_projection[0].xy * _ScreenParams.xx + u_xlat0.xy;\n    u_xlat0.xy = u_xlat0.ww / abs(u_xlat0.xy);\n    u_xlat0.xy = vec2(_UIMaskSoftnessX, _UIMaskSoftnessY) * vec2(0.25, 0.25) + abs(u_xlat0.xy);\n    vs_TEXCOORD2.zw = vec2(0.25, 0.25) / u_xlat0.xy;\n    u_xlat0 = max(_ClipRect, vec4(-2e+10, -2e+10, -2e+10, -2e+10));\n    u_xlat0 = min(u_xlat0, vec4(2e+10, 2e+10, 2e+10, 2e+10));\n    u_xlat0.xy = in_POSITION0.xy * vec2(2.0, 2.0) + (-u_xlat0.xy);\n    vs_TEXCOORD2.xy = (-u_xlat0.zw) + u_xlat0.xy;\n    return;\n}\n\n","#version 100\n\n#ifdef GL_FRAGMENT_PRECISION_HIGH\n    precision highp float;\n#else\n    precision mediump float;\n#endif\nprecision highp int;\nuniform \tmediump vec4 _TextureSampleAdd;\nuniform lowp sampler2D _MainTex;\nvarying mediump vec4 vs_COLOR0;\nvarying highp vec2 vs_TEXCOORD0;\n#define SV_Target0 gl_FragData[0]\nvec4 u_xlat0;\nmediump vec4 u_xlat16_0;\nvec4 u_xlat1;\nlowp vec4 u_xlat10_1;\nfloat unity_roundEven(float x) { float y = floor(x + 0.5); return (y - x == 0.5) ? floor(0.5*y) * 2.0 : y; }\nvec2 unity_roundEven(vec2 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); return a; }\nvec3 unity_roundEven(vec3 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); a.z = unity_roundEven(a.z); return a; }\nvec4 unity_roundEven(vec4 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); a.z = unity_roundEven(a.z); a.w = unity_roundEven(a.w); return a; }\n\nvoid main()\n{\n    u_xlat16_0.x = vs_COLOR0.w * 255.0;\n    u_xlat16_0.x = unity_roundEven(u_xlat16_0.x);\n    u_xlat16_0.w = u_xlat16_0.x * 0.00392156886;\n    u_xlat10_1 = texture2D(_MainTex, vs_TEXCOORD0.xy);\n    u_xlat1 = u_xlat10_1 + _TextureSampleAdd;\n    u_xlat16_0.xyz = vs_COLOR0.xyz;\n    u_xlat0 = u_xlat16_0 * u_xlat1;\n    SV_Target0.xyz = u_xlat0.www * u_xlat0.xyz;\n    SV_Target0.w = u_xlat0.w;\n    return;\n}\n\n","#version 100\n\nuniform \tvec4 _ScreenParams;\nuniform \tvec4 hlslcc_mtx4x4unity_ObjectToWorld[4];\nuniform \tvec4 hlslcc_mtx4x4glstate_matrix_projection[4];\nuniform \tvec4 hlslcc_mtx4x4unity_MatrixVP[4];\nuniform \tmediump vec4 _Color;\nuniform \tvec4 _ClipRect;\nuniform \tvec4 _MainTex_ST;\nuniform \tfloat _UIMaskSoftnessX;\nuniform \tfloat _UIMaskSoftnessY;\nattribute highp vec4 in_POSITION0;\nattribute highp vec4 in_COLOR0;\nattribute highp vec2 in_TEXCOORD0;\nvarying mediump vec4 vs_COLOR0;\nvarying highp vec2 vs_TEXCOORD0;\nvarying highp vec4 vs_TEXCOORD1;\nvarying highp vec4 vs_TEXCOORD2;\nvec4 u_xlat0;\nvec4 u_xlat1;\nvoid main()\n{\n    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];\n    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;\n    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;\n    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];\n    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];\n    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;\n    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;\n    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;\n    gl_Position = u_xlat0;\n    u_xlat1 = in_COLOR0 * _Color;\n    vs_COLOR0 = u_xlat1;\n    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;\n    vs_TEXCOORD1 = in_POSITION0;\n    u_xlat0.xy = _ScreenParams.yy * hlslcc_mtx4x4glstate_matrix_projection[1].xy;\n    u_xlat0.xy = hlslcc_mtx4x4glstate_matrix_projection[0].xy * _ScreenParams.xx + u_xlat0.xy;\n    u_xlat0.xy = u_xlat0.ww / abs(u_xlat0.xy);\n    u_xlat0.xy = vec2(_UIMaskSoftnessX, _UIMaskSoftnessY) * vec2(0.25, 0.25) + abs(u_xlat0.xy);\n    vs_TEXCOORD2.zw = vec2(0.25, 0.25) / u_xlat0.xy;\n    u_xlat0 = max(_ClipRect, vec4(-2e+10, -2e+10, -2e+10, -2e+10));\n    u_xlat0 = min(u_xlat0, vec4(2e+10, 2e+10, 2e+10, 2e+10));\n    u_xlat0.xy = in_POSITION0.xy * vec2(2.0, 2.0) + (-u_xlat0.xy);\n    vs_TEXCOORD2.xy = (-u_xlat0.zw) + u_xlat0.xy;\n    return;\n}\n\n","#version 100\n\n#ifdef GL_FRAGMENT_PRECISION_HIGH\n    precision highp float;\n#else\n    precision mediump float;\n#endif\nprecision highp int;\nuniform \tmediump vec4 _TextureSampleAdd;\nuniform lowp sampler2D _MainTex;\nvarying mediump vec4 vs_COLOR0;\nvarying highp vec2 vs_TEXCOORD0;\n#define SV_Target0 gl_FragData[0]\nvec4 u_xlat0;\nmediump vec4 u_xlat16_0;\nvec4 u_xlat1;\nlowp vec4 u_xlat10_1;\nmediump float u_xlat16_2;\nbool u_xlatb3;\nfloat unity_roundEven(float x) { float y = floor(x + 0.5); return (y - x == 0.5) ? floor(0.5*y) * 2.0 : y; }\nvec2 unity_roundEven(vec2 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); return a; }\nvec3 unity_roundEven(vec3 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); a.z = unity_roundEven(a.z); return a; }\nvec4 unity_roundEven(vec4 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); a.z = unity_roundEven(a.z); a.w = unity_roundEven(a.w); return a; }\n\nvoid main()\n{\n    u_xlat16_0.x = vs_COLOR0.w * 255.0;\n    u_xlat16_0.x = unity_roundEven(u_xlat16_0.x);\n    u_xlat16_0.w = u_xlat16_0.x * 0.00392156886;\n    u_xlat10_1 = texture2D(_MainTex, vs_TEXCOORD0.xy);\n    u_xlat1 = u_xlat10_1 + _TextureSampleAdd;\n    u_xlat16_2 = u_xlat16_0.w * u_xlat1.w + -0.00100000005;\n    u_xlatb3 = u_xlat16_2<0.0;\n    if(u_xlatb3){discard;}\n    u_xlat16_0.xyz = vs_COLOR0.xyz;\n    u_xlat0 = u_xlat16_0 * u_xlat1;\n    SV_Target0.xyz = u_xlat0.www * u_xlat0.xyz;\n    SV_Target0.w = u_xlat0.w;\n    return;\n}\n\n","#version 100\n\nuniform \tvec4 _ScreenParams;\nuniform \tvec4 hlslcc_mtx4x4unity_ObjectToWorld[4];\nuniform \tvec4 hlslcc_mtx4x4glstate_matrix_projection[4];\nuniform \tvec4 hlslcc_mtx4x4unity_MatrixVP[4];\nuniform \tmediump vec4 _Color;\nuniform \tvec4 _ClipRect;\nuniform \tvec4 _MainTex_ST;\nuniform \tfloat _UIMaskSoftnessX;\nuniform \tfloat _UIMaskSoftnessY;\nattribute highp vec4 in_POSITION0;\nattribute highp vec4 in_COLOR0;\nattribute highp vec2 in_TEXCOORD0;\nvarying mediump vec4 vs_COLOR0;\nvarying highp vec2 vs_TEXCOORD0;\nvarying highp vec4 vs_TEXCOORD1;\nvarying highp vec4 vs_TEXCOORD2;\nvec4 u_xlat0;\nvec4 u_xlat1;\nvoid main()\n{\n    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];\n    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;\n    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;\n    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];\n    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];\n    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;\n    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;\n    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;\n    gl_Position = u_xlat0;\n    u_xlat1 = in_COLOR0 * _Color;\n    vs_COLOR0 = u_xlat1;\n    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;\n    vs_TEXCOORD1 = in_POSITION0;\n    u_xlat0.xy = _ScreenParams.yy * hlslcc_mtx4x4glstate_matrix_projection[1].xy;\n    u_xlat0.xy = hlslcc_mtx4x4glstate_matrix_projection[0].xy * _ScreenParams.xx + u_xlat0.xy;\n    u_xlat0.xy = u_xlat0.ww / abs(u_xlat0.xy);\n    u_xlat0.xy = vec2(_UIMaskSoftnessX, _UIMaskSoftnessY) * vec2(0.25, 0.25) + abs(u_xlat0.xy);\n    vs_TEXCOORD2.zw = vec2(0.25, 0.25) / u_xlat0.xy;\n    u_xlat0 = max(_ClipRect, vec4(-2e+10, -2e+10, -2e+10, -2e+10));\n    u_xlat0 = min(u_xlat0, vec4(2e+10, 2e+10, 2e+10, 2e+10));\n    u_xlat0.xy = in_POSITION0.xy * vec2(2.0, 2.0) + (-u_xlat0.xy);\n    vs_TEXCOORD2.xy = (-u_xlat0.zw) + u_xlat0.xy;\n    return;\n}\n\n","#version 100\n\n#ifdef GL_FRAGMENT_PRECISION_HIGH\n    precision highp float;\n#else\n    precision mediump float;\n#endif\nprecision highp int;\nuniform \tmediump vec4 _TextureSampleAdd;\nuniform \tvec4 _ClipRect;\nuniform lowp sampler2D _MainTex;\nvarying mediump vec4 vs_COLOR0;\nvarying highp vec2 vs_TEXCOORD0;\nvarying highp vec4 vs_TEXCOORD2;\n#define SV_Target0 gl_FragData[0]\nvec4 u_xlat0;\nmediump vec4 u_xlat16_0;\nmediump float u_xlat16_1;\nvec4 u_xlat2;\nlowp vec4 u_xlat10_2;\nmediump float u_xlat16_4;\nfloat unity_roundEven(float x) { float y = floor(x + 0.5); return (y - x == 0.5) ? floor(0.5*y) * 2.0 : y; }\nvec2 unity_roundEven(vec2 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); return a; }\nvec3 unity_roundEven(vec3 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); a.z = unity_roundEven(a.z); return a; }\nvec4 unity_roundEven(vec4 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); a.z = unity_roundEven(a.z); a.w = unity_roundEven(a.w); return a; }\n\nvoid main()\n{\n    u_xlat0.xy = (-_ClipRect.xy) + _ClipRect.zw;\n    u_xlat0.xy = u_xlat0.xy + -abs(vs_TEXCOORD2.xy);\n    u_xlat0.xy = u_xlat0.xy * vs_TEXCOORD2.zw;\n    u_xlat0.xy = clamp(u_xlat0.xy, 0.0, 1.0);\n    u_xlat16_1 = u_xlat0.y * u_xlat0.x;\n    u_xlat16_4 = vs_COLOR0.w * 255.0;\n    u_xlat16_4 = unity_roundEven(u_xlat16_4);\n    u_xlat16_0.w = u_xlat16_4 * 0.00392156886;\n    u_xlat10_2 = texture2D(_MainTex, vs_TEXCOORD0.xy);\n    u_xlat2 = u_xlat10_2 + _TextureSampleAdd;\n    u_xlat16_0.xyz = vs_COLOR0.xyz;\n    u_xlat0 = u_xlat16_0 * u_xlat2;\n    u_xlat16_1 = u_xlat16_1 * u_xlat0.w;\n    SV_Target0.xyz = u_xlat0.xyz * vec3(u_xlat16_1);\n    SV_Target0.w = u_xlat16_1;\n    return;\n}\n\n","#version 100\n\nuniform \tvec4 _ScreenParams;\nuniform \tvec4 hlslcc_mtx4x4unity_ObjectToWorld[4];\nuniform \tvec4 hlslcc_mtx4x4glstate_matrix_projection[4];\nuniform \tvec4 hlslcc_mtx4x4unity_MatrixVP[4];\nuniform \tmediump vec4 _Color;\nuniform \tvec4 _ClipRect;\nuniform \tvec4 _MainTex_ST;\nuniform \tfloat _UIMaskSoftnessX;\nuniform \tfloat _UIMaskSoftnessY;\nattribute highp vec4 in_POSITION0;\nattribute highp vec4 in_COLOR0;\nattribute highp vec2 in_TEXCOORD0;\nvarying mediump vec4 vs_COLOR0;\nvarying highp vec2 vs_TEXCOORD0;\nvarying highp vec4 vs_TEXCOORD1;\nvarying highp vec4 vs_TEXCOORD2;\nvec4 u_xlat0;\nvec4 u_xlat1;\nvoid main()\n{\n    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];\n    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;\n    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;\n    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];\n    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];\n    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;\n    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;\n    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;\n    gl_Position = u_xlat0;\n    u_xlat1 = in_COLOR0 * _Color;\n    vs_COLOR0 = u_xlat1;\n    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;\n    vs_TEXCOORD1 = in_POSITION0;\n    u_xlat0.xy = _ScreenParams.yy * hlslcc_mtx4x4glstate_matrix_projection[1].xy;\n    u_xlat0.xy = hlslcc_mtx4x4glstate_matrix_projection[0].xy * _ScreenParams.xx + u_xlat0.xy;\n    u_xlat0.xy = u_xlat0.ww / abs(u_xlat0.xy);\n    u_xlat0.xy = vec2(_UIMaskSoftnessX, _UIMaskSoftnessY) * vec2(0.25, 0.25) + abs(u_xlat0.xy);\n    vs_TEXCOORD2.zw = vec2(0.25, 0.25) / u_xlat0.xy;\n    u_xlat0 = max(_ClipRect, vec4(-2e+10, -2e+10, -2e+10, -2e+10));\n    u_xlat0 = min(u_xlat0, vec4(2e+10, 2e+10, 2e+10, 2e+10));\n    u_xlat0.xy = in_POSITION0.xy * vec2(2.0, 2.0) + (-u_xlat0.xy);\n    vs_TEXCOORD2.xy = (-u_xlat0.zw) + u_xlat0.xy;\n    return;\n}\n\n","#version 100\n\n#ifdef GL_FRAGMENT_PRECISION_HIGH\n    precision highp float;\n#else\n    precision mediump float;\n#endif\nprecision highp int;\nuniform \tmediump vec4 _TextureSampleAdd;\nuniform \tvec4 _ClipRect;\nuniform lowp sampler2D _MainTex;\nvarying mediump vec4 vs_COLOR0;\nvarying highp vec2 vs_TEXCOORD0;\nvarying highp vec4 vs_TEXCOORD2;\n#define SV_Target0 gl_FragData[0]\nvec4 u_xlat0;\nmediump vec4 u_xlat16_0;\nvec4 u_xlat1;\nlowp vec4 u_xlat10_1;\nbool u_xlatb1;\nmediump float u_xlat16_2;\nmediump float u_xlat16_5;\nfloat unity_roundEven(float x) { float y = floor(x + 0.5); return (y - x == 0.5) ? floor(0.5*y) * 2.0 : y; }\nvec2 unity_roundEven(vec2 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); return a; }\nvec3 unity_roundEven(vec3 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); a.z = unity_roundEven(a.z); return a; }\nvec4 unity_roundEven(vec4 a) { a.x = unity_roundEven(a.x); a.y = unity_roundEven(a.y); a.z = unity_roundEven(a.z); a.w = unity_roundEven(a.w); return a; }\n\nvoid main()\n{\n    u_xlat16_0.x = vs_COLOR0.w * 255.0;\n    u_xlat16_0.x = unity_roundEven(u_xlat16_0.x);\n    u_xlat16_0.w = u_xlat16_0.x * 0.00392156886;\n    u_xlat10_1 = texture2D(_MainTex, vs_TEXCOORD0.xy);\n    u_xlat1 = u_xlat10_1 + _TextureSampleAdd;\n    u_xlat16_0.xyz = vs_COLOR0.xyz;\n    u_xlat0 = u_xlat16_0 * u_xlat1;\n    u_xlat1.xy = (-_ClipRect.xy) + _ClipRect.zw;\n    u_xlat1.xy = u_xlat1.xy + -abs(vs_TEXCOORD2.xy);\n    u_xlat1.xy = u_xlat1.xy * vs_TEXCOORD2.zw;\n    u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);\n    u_xlat16_2 = u_xlat1.y * u_xlat1.x;\n    u_xlat16_5 = u_xlat0.w * u_xlat16_2 + -0.00100000005;\n    u_xlat16_2 = u_xlat0.w * u_xlat16_2;\n    SV_Target0.xyz = u_xlat0.xyz * vec3(u_xlat16_2);\n    SV_Target0.w = u_xlat16_2;\n    u_xlatb1 = u_xlat16_5<0.0;\n    if(u_xlatb1){discard;}\n    return;\n}\n\n"]