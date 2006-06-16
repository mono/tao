#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
http://www.taoframework.com
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Tao.Cg {
    #region Class Documentation
    /// <summary>
    ///     Cg core runtime binding for .NET, implementing Cg 1.2.1.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in cg.dll or libcg.so.
    /// </remarks>
    #endregion Class Documentation
    public sealed class Cg {
        #region Private Constants
        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Cdecl" /> for Windows and Linux.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region BindLocations
        #region CG_TEXUINT0
        /// <summary>
        ///     Texture unit.
        /// </summary>
        // CG_TEXUINT0 = 2048
        public const int CG_TEXUINT0 = 2048;
        #endregion CG_TEXUINT0

        #region CG_TEXUINT1
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT1 = 2049
        public const int CG_TEXUINT1 = 2049;
        #endregion CG_TEXUINT1

        #region CG_TEXUINT2
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT2 = 2050
        public const int CG_TEXUINT2 = 2050;
        #endregion CG_TEXUINT2

        #region CG_TEXUINT3
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT3 = 2051
        public const int CG_TEXUINT3 = 2051;
        #endregion CG_TEXUINT3

        #region CG_TEXUINT4
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT4 = 2052
        public const int CG_TEXUINT4 = 2052;
        #endregion CG_TEXUINT4

        #region CG_TEXUINT5
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT5 = 2053
        public const int CG_TEXUINT5 = 2053;
        #endregion CG_TEXUINT5

        #region CG_TEXUINT6
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT6 = 2054
        public const int CG_TEXUINT6 = 2054;
        #endregion CG_TEXUINT6

        #region CG_TEXUINT7
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT7 = 2055
        public const int CG_TEXUINT7 = 2055;
        #endregion CG_TEXUINT7

        #region CG_TEXUINT8
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT8 = 2056
        public const int CG_TEXUINT8 = 2056;
        #endregion CG_TEXUINT8

        #region CG_TEXUINT9
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT9 = 2057
        public const int CG_TEXUINT9 = 2057;
        #endregion CG_TEXUINT9

        #region CG_TEXUINT10
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT10 = 2058
        public const int CG_TEXUINT10 = 2058;
        #endregion CG_TEXUINT10

        #region CG_TEXUINT11
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT11 = 2059
        public const int CG_TEXUINT11 = 2059;
        #endregion CG_TEXUINT11

        #region CG_TEXUINT12
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT12 = 2060
        public const int CG_TEXUINT12 = 2060;
        #endregion CG_TEXUINT12

        #region CG_TEXUINT13
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT13 = 2061
        public const int CG_TEXUINT13 = 2061;
        #endregion CG_TEXUINT13

        #region CG_TEXUINT14
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT14 = 2062
        public const int CG_TEXUINT14 = 2062;
        #endregion CG_TEXUINT14

        #region CG_TEXUINT15
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXUINT15 = 2063
        public const int CG_TEXUINT15 = 2063;
        #endregion CG_TEXUINT15

        #region CG_ATTR0
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR0 = 2113
        public const int CG_ATTR0 = 2113;
        #endregion CG_ATTR0

        #region CG_ATTR1
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR1 = 2114
        public const int CG_ATTR1 = 2114;
        #endregion CG_ATTR1

        #region CG_ATTR2
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR2 = 2115
        public const int CG_ATTR2 = 2115;
        #endregion CG_ATTR2

        #region CG_ATTR3
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR3 = 2116
        public const int CG_ATTR3 = 2116;
        #endregion CG_ATTR3

        #region CG_ATTR4
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR4 = 2117
        public const int CG_ATTR4 = 2117;
        #endregion CG_ATTR4

        #region CG_ATTR5
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR5 = 2118
        public const int CG_ATTR5 = 2118;
        #endregion CG_ATTR5

        #region CG_ATTR6
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR6 = 2119
        public const int CG_ATTR6 = 2119;
        #endregion CG_ATTR6

        #region CG_ATTR7
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR7 = 2120
        public const int CG_ATTR7 = 2120;
        #endregion CG_ATTR7

        #region CG_ATTR8
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR8 = 2121
        public const int CG_ATTR8 = 2121;
        #endregion CG_ATTR8

        #region CG_ATTR9
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR9 = 2122
        public const int CG_ATTR9 = 2122;
        #endregion CG_ATTR9

        #region CG_ATTR10
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR10 = 2123
        public const int CG_ATTR10 = 2123;
        #endregion CG_ATTR10

        #region CG_ATTR11
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR11 = 2124
        public const int CG_ATTR11 = 2124;
        #endregion CG_ATTR11

        #region CG_ATTR12
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR12 = 2125
        public const int CG_ATTR12 = 2125;
        #endregion CG_ATTR12

        #region CG_ATTR13
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR13 = 2126
        public const int CG_ATTR13 = 2126;
        #endregion CG_ATTR13

        #region CG_ATTR14
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR14 = 2127
        public const int CG_ATTR14 = 2127;
        #endregion CG_ATTR14

        #region CG_ATTR15
        /// <summary>
        ///     
        /// </summary>
        // CG_ATTR15 = 2128
        public const int CG_ATTR15 = 2128;
        #endregion CG_ATTR15

        #region CG_C
        /// <summary>
        ///     
        /// </summary>
        // CG_C = 2178
        public const int CG_C = 2178;
        #endregion CG_C

        #region CG_TEX0
        /// <summary>
        ///     
        /// </summary>
        // CG_TEX0 = 2179
        public const int CG_TEX0 = 2179;
        #endregion CG_TEX0

        #region CG_TEX1
        /// <summary>
        ///     
        /// </summary>
        // CG_TEX1 = 2180
        public const int CG_TEX1 = 2180;
        #endregion CG_TEX1

        #region CG_TEX2
        /// <summary>
        ///     
        /// </summary>
        // CG_TEX2 = 2181
        public const int CG_TEX2 = 2181;
        #endregion CG_TEX2

        #region CG_TEX3
        /// <summary>
        ///     
        /// </summary>
        // CG_TEX3 = 2192
        public const int CG_TEX3 = 2192;
        #endregion CG_TEX3

        #region CG_TEX4
        /// <summary>
        ///     
        /// </summary>
        // CG_TEX4 = 2193
        public const int CG_TEX4 = 2193;
        #endregion CG_TEX4

        #region CG_TEX5
        /// <summary>
        ///     
        /// </summary>
        // CG_TEX5 = 2194
        public const int CG_TEX5 = 2194;
        #endregion CG_TEX5

        #region CG_TEX6
        /// <summary>
        ///     
        /// </summary>
        // CG_TEX6 = 2195
        public const int CG_TEX6 = 2195;
        #endregion CG_TEX6

        #region CG_TEX7
        /// <summary>
        ///     
        /// </summary>
        // CG_TEX7 = 2196
        public const int CG_TEX7 = 2196;
        #endregion CG_TEX7

        #region CG_HPOS
        /// <summary>
        ///     
        /// </summary>
        // CG_HPOS = 2243
        public const int CG_HPOS = 2243;
        #endregion CG_HPOS

        #region CG_COL0
        /// <summary>
        ///     
        /// </summary>
        // CG_COL0 = 2245
        public const int CG_COL0 = 2245;
        #endregion CG_COL0

        #region CG_COL1
        /// <summary>
        ///     
        /// </summary>
        // CG_COL1 = 2246
        public const int CG_COL1 = 2246;
        #endregion CG_COL1

        #region CG_COL2
        /// <summary>
        ///     
        /// </summary>
        // CG_COL2 = 2247
        public const int CG_COL2 = 2247;
        #endregion CG_COL2

        #region CG_COL3
        /// <summary>
        ///     
        /// </summary>
        // CG_COL3 = 2248
        public const int CG_COL3 = 2248;
        #endregion CG_COL3

        #region CG_PSIZ
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZ = 2309
        public const int CG_PSIZ = 2309;
        #endregion CG_PSIZ

        #region CG_WPOS
        /// <summary>
        ///     
        /// </summary>
        // CG_WPOS = 2373
        public const int CG_WPOS = 2373;
        #endregion CG_WPOS

        #region CG_POSITION0
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION0 = 2437
        public const int CG_POSITION0 = 2437;
        #endregion CG_POSITION0

        #region CG_POSITION1
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION1 = 2438
        public const int CG_POSITION1 = 2438;
        #endregion CG_POSITION1

        #region CG_POSITION2
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION2 = 2439
        public const int CG_POSITION2 = 2439;
        #endregion CG_POSITION2

        #region CG_POSITION3
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION3 = 2440
        public const int CG_POSITION3 = 2440;
        #endregion CG_POSITION3

        #region CG_POSITION4
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION4 = 2441
        public const int CG_POSITION4 = 2441;
        #endregion CG_POSITION4

        #region CG_POSITION5
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION5 = 2442
        public const int CG_POSITION5 = 2442;
        #endregion CG_POSITION5

        #region CG_POSITION6
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION6 = 2443
        public const int CG_POSITION6 = 2443;
        #endregion CG_POSITION6

        #region CG_POSITION7
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION7 = 2444
        public const int CG_POSITION7 = 2444;
        #endregion CG_POSITION7

        #region CG_POSITION8
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION8 = 2445
        public const int CG_POSITION8 = 2445;
        #endregion CG_POSITION8

        #region CG_POSITION9
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION9 = 2446
        public const int CG_POSITION9 = 2446;
        #endregion CG_POSITION9

        #region CG_POSITION10
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION10 = 2447
        public const int CG_POSITION10 = 2447;
        #endregion CG_POSITION10

        #region CG_POSITION11
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION11 = 2448
        public const int CG_POSITION11 = 2448;
        #endregion CG_POSITION11

        #region CG_POSITION12
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION12 = 2449
        public const int CG_POSITION12 = 2449;
        #endregion CG_POSITION12

        #region CG_POSITION13
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION13 = 2450
        public const int CG_POSITION13 = 2450;
        #endregion CG_POSITION13

        #region CG_POSITION14
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION14 = 2451
        public const int CG_POSITION14 = 2451;
        #endregion CG_POSITION14

        #region CG_POSITION15
        /// <summary>
        ///     
        /// </summary>
        // CG_POSITION15 = 2452
        public const int CG_POSITION15 = 2452;
        #endregion CG_POSITION15

        #region CG_DIFFUSE0
        /// <summary>
        ///     
        /// </summary>
        // CG_DIFFUSE0 = 2501
        public const int CG_DIFFUSE0 = 2501;
        #endregion CG_DIFFUSE0

        #region CG_TANGENT0
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT0 = 2565
        public const int CG_TANGENT0 = 2565;
        #endregion CG_TANGENT0

        #region CG_TANGENT1
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT1 = 2566
        public const int CG_TANGENT1 = 2566;
        #endregion CG_TANGENT1

        #region CG_TANGENT2
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT2 = 2567
        public const int CG_TANGENT2 = 2567;
        #endregion CG_TANGENT2

        #region CG_TANGENT3
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT3 = 2568
        public const int CG_TANGENT3 = 2568;
        #endregion CG_TANGENT3

        #region CG_TANGENT4
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT4 = 2569
        public const int CG_TANGENT4 = 2569;
        #endregion CG_TANGENT4

        #region CG_TANGENT5
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT5 = 2570
        public const int CG_TANGENT5 = 2570;
        #endregion CG_TANGENT5

        #region CG_TANGENT6
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT6 = 2571
        public const int CG_TANGENT6 = 2571;
        #endregion CG_TANGENT6

        #region CG_TANGENT7
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT7 = 2572
        public const int CG_TANGENT7 = 2572;
        #endregion CG_TANGENT7

        #region CG_TANGENT8
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT8 = 2573
        public const int CG_TANGENT8 = 2573;
        #endregion CG_TANGENT8

        #region CG_TANGENT9
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT9 = 2574
        public const int CG_TANGENT9 = 2574;
        #endregion CG_TANGENT9

        #region CG_TANGENT10
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT10 = 2575
        public const int CG_TANGENT10 = 2575;
        #endregion CG_TANGENT10

        #region CG_TANGENT11
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT11 = 2576
        public const int CG_TANGENT11 = 2576;
        #endregion CG_TANGENT11

        #region CG_TANGENT12
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT12 = 2577
        public const int CG_TANGENT12 = 2577;
        #endregion CG_TANGENT12

        #region CG_TANGENT13
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT13 = 2578
        public const int CG_TANGENT13 = 2578;
        #endregion CG_TANGENT13

        #region CG_TANGENT14
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT14 = 2579
        public const int CG_TANGENT14 = 2579;
        #endregion CG_TANGENT14

        #region CG_TANGENT15
        /// <summary>
        ///     
        /// </summary>
        // CG_TANGENT15 = 2580
        public const int CG_TANGENT15 = 2580;
        #endregion CG_TANGENT15

        #region CG_SPECULAR0
        /// <summary>
        ///     
        /// </summary>
        // CG_SPECULAR0 = 2629
        public const int CG_SPECULAR0 = 2629;
        #endregion CG_SPECULAR0

        #region CG_BLENDINDICES0
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES0 = 2693
        public const int CG_BLENDINDICES0 = 2693;
        #endregion CG_BLENDINDICES0

        #region CG_BLENDINDICES1
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES1 = 2694
        public const int CG_BLENDINDICES1 = 2694;
        #endregion CG_BLENDINDICES1

        #region CG_BLENDINDICES2
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES2 = 2695
        public const int CG_BLENDINDICES2 = 2695;
        #endregion CG_BLENDINDICES2

        #region CG_BLENDINDICES3
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES3 = 2696
        public const int CG_BLENDINDICES3 = 2696;
        #endregion CG_BLENDINDICES3

        #region CG_BLENDINDICES4
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES4 = 2697
        public const int CG_BLENDINDICES4 = 2697;
        #endregion CG_BLENDINDICES4

        #region CG_BLENDINDICES5
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES5 = 2698
        public const int CG_BLENDINDICES5 = 2698;
        #endregion CG_BLENDINDICES5

        #region CG_BLENDINDICES6
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES6 = 2699
        public const int CG_BLENDINDICES6 = 2699;
        #endregion CG_BLENDINDICES6

        #region CG_BLENDINDICES7
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES7 = 2700
        public const int CG_BLENDINDICES7 = 2700;
        #endregion CG_BLENDINDICES7

        #region CG_BLENDINDICES8
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES8 = 2701
        public const int CG_BLENDINDICES8 = 2701;
        #endregion CG_BLENDINDICES8

        #region CG_BLENDINDICES9
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES9 = 2702
        public const int CG_BLENDINDICES9 = 2702;
        #endregion CG_BLENDINDICES9

        #region CG_BLENDINDICES10
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES10 = 2703
        public const int CG_BLENDINDICES10 = 2703;
        #endregion CG_BLENDINDICES10

        #region CG_BLENDINDICES11
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES11 = 2704
        public const int CG_BLENDINDICES11 = 2704;
        #endregion CG_BLENDINDICES11

        #region CG_BLENDINDICES12
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES12 = 2705
        public const int CG_BLENDINDICES12 = 2705;
        #endregion CG_BLENDINDICES12

        #region CG_BLENDINDICES13
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES13 = 2706
        public const int CG_BLENDINDICES13 = 2706;
        #endregion CG_BLENDINDICES13

        #region CG_BLENDINDICES14
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES14 = 2707
        public const int CG_BLENDINDICES14 = 2707;
        #endregion CG_BLENDINDICES14

        #region CG_BLENDINDICES15
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDINDICES15 = 2708
        public const int CG_BLENDINDICES15 = 2708;
        #endregion CG_BLENDINDICES15

        #region CG_COLOR0
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR0 = 2757
        public const int CG_COLOR0 = 2757;
        #endregion CG_COLOR0

        #region CG_COLOR1
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR1 = 2758
        public const int CG_COLOR1 = 2758;
        #endregion CG_COLOR1

        #region CG_COLOR2
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR2 = 2759
        public const int CG_COLOR2 = 2759;
        #endregion CG_COLOR2

        #region CG_COLOR3
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR3 = 2760
        public const int CG_COLOR3 = 2760;
        #endregion CG_COLOR3

        #region CG_COLOR4
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR4 = 2761
        public const int CG_COLOR4 = 2761;
        #endregion CG_COLOR4

        #region CG_COLOR5
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR5 = 2762
        public const int CG_COLOR5 = 2762;
        #endregion CG_COLOR5

        #region CG_COLOR6
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR6 = 2763
        public const int CG_COLOR6 = 2763;
        #endregion CG_COLOR6

        #region CG_COLOR7
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR7 = 2764
        public const int CG_COLOR7 = 2764;
        #endregion CG_COLOR7

        #region CG_COLOR8
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR8 = 2765
        public const int CG_COLOR8 = 2765;
        #endregion CG_COLOR8

        #region CG_COLOR9
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR9 = 2766
        public const int CG_COLOR9 = 2766;
        #endregion CG_COLOR9

        #region CG_COLOR10
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR10 = 2767
        public const int CG_COLOR10 = 2767;
        #endregion CG_COLOR10

        #region CG_COLOR11
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR11 = 2768
        public const int CG_COLOR11 = 2768;
        #endregion CG_COLOR11

        #region CG_COLOR12
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR12 = 2769
        public const int CG_COLOR12 = 2769;
        #endregion CG_COLOR12

        #region CG_COLOR13
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR13 = 2770
        public const int CG_COLOR13 = 2770;
        #endregion CG_COLOR13

        #region CG_COLOR14
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR14 = 2771
        public const int CG_COLOR14 = 2771;
        #endregion CG_COLOR14

        #region CG_COLOR15
        /// <summary>
        ///     
        /// </summary>
        // CG_COLOR15 = 2772
        public const int CG_COLOR15 = 2772;
        #endregion CG_COLOR15

        #region CG_PSIZE0
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE0 = 2821
        public const int CG_PSIZE0 = 2821;
        #endregion CG_PSIZE0

        #region CG_PSIZE1
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE1 = 2822
        public const int CG_PSIZE1 = 2822;
        #endregion CG_PSIZE1

        #region CG_PSIZE2
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE2 = 2823
        public const int CG_PSIZE2 = 2823;
        #endregion CG_PSIZE2

        #region CG_PSIZE3
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE3 = 2824
        public const int CG_PSIZE3 = 2824;
        #endregion CG_PSIZE3

        #region CG_PSIZE4
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE4 = 2825
        public const int CG_PSIZE4 = 2825;
        #endregion CG_PSIZE4

        #region CG_PSIZE5
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE5 = 2826
        public const int CG_PSIZE5 = 2826;
        #endregion CG_PSIZE5

        #region CG_PSIZE6
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE6 = 2827
        public const int CG_PSIZE6 = 2827;
        #endregion CG_PSIZE6

        #region CG_PSIZE7
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE7 = 2828
        public const int CG_PSIZE7 = 2828;
        #endregion CG_PSIZE7

        #region CG_PSIZE8
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE8 = 2829
        public const int CG_PSIZE8 = 2829;
        #endregion CG_PSIZE8

        #region CG_PSIZE9
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE9 = 2830
        public const int CG_PSIZE9 = 2830;
        #endregion CG_PSIZE9

        #region CG_PSIZE10
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE10 = 2831
        public const int CG_PSIZE10 = 2831;
        #endregion CG_PSIZE10

        #region CG_PSIZE11
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE11 = 2832
        public const int CG_PSIZE11 = 2832;
        #endregion CG_PSIZE11

        #region CG_PSIZE12
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE12 = 2833
        public const int CG_PSIZE12 = 2833;
        #endregion CG_PSIZE12

        #region CG_PSIZE13
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE13 = 2834
        public const int CG_PSIZE13 = 2834;
        #endregion CG_PSIZE13

        #region CG_PSIZE14
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE14 = 2835
        public const int CG_PSIZE14 = 2835;
        #endregion CG_PSIZE14

        #region CG_PSIZE15
        /// <summary>
        ///     
        /// </summary>
        // CG_PSIZE15 = 2836
        public const int CG_PSIZE15 = 2836;
        #endregion CG_PSIZE15

        #region CG_BINORMAL0
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL0 = 2885
        public const int CG_BINORMAL0 = 2885;
        #endregion CG_BINORMAL0

        #region CG_BINORMAL1
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL1 = 2886
        public const int CG_BINORMAL1 = 2886;
        #endregion CG_BINORMAL1

        #region CG_BINORMAL2
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL2 = 2887
        public const int CG_BINORMAL2 = 2887;
        #endregion CG_BINORMAL2

        #region CG_BINORMAL3
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL3 = 2888
        public const int CG_BINORMAL3 = 2888;
        #endregion CG_BINORMAL3

        #region CG_BINORMAL4
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL4 = 2889
        public const int CG_BINORMAL4 = 2889;
        #endregion CG_BINORMAL4

        #region CG_BINORMAL5
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL5 = 2890
        public const int CG_BINORMAL5 = 2890;
        #endregion CG_BINORMAL5

        #region CG_BINORMAL6
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL6 = 2891
        public const int CG_BINORMAL6 = 2891;
        #endregion CG_BINORMAL6

        #region CG_BINORMAL7
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL7 = 2892
        public const int CG_BINORMAL7 = 2892;
        #endregion CG_BINORMAL7

        #region CG_BINORMAL8
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL8 = 2893
        public const int CG_BINORMAL8 = 2893;
        #endregion CG_BINORMAL8

        #region CG_BINORMAL9
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL9 = 2894
        public const int CG_BINORMAL9 = 2894;
        #endregion CG_BINORMAL9

        #region CG_BINORMAL10
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL10 = 2895
        public const int CG_BINORMAL10 = 2895;
        #endregion CG_BINORMAL10

        #region CG_BINORMAL11
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL11 = 2896
        public const int CG_BINORMAL11 = 2896;
        #endregion CG_BINORMAL11

        #region CG_BINORMAL12
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL12 = 2897
        public const int CG_BINORMAL12 = 2897;
        #endregion CG_BINORMAL12

        #region CG_BINORMAL13
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL13 = 2898
        public const int CG_BINORMAL13 = 2898;
        #endregion CG_BINORMAL13

        #region CG_BINORMAL14
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL14 = 2899
        public const int CG_BINORMAL14 = 2899;
        #endregion CG_BINORMAL14

        #region CG_BINORMAL15
        /// <summary>
        ///     
        /// </summary>
        // CG_BINORMAL15 = 2900
        public const int CG_BINORMAL15 = 2900;
        #endregion CG_BINORMAL15

        #region CG_FOG0
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG0 = 2917
        public const int CG_FOG0 = 2917;
        #endregion CG_FOG0

        #region CG_FOG1
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG1 = 2918
        public const int CG_FOG1 = 2918;
        #endregion CG_FOG1

        #region CG_FOG2
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG2 = 2919
        public const int CG_FOG2 = 2919;
        #endregion CG_FOG2

        #region CG_FOG3
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG3 = 2920
        public const int CG_FOG3 = 2920;
        #endregion CG_FOG3

        #region CG_FOG4
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG4 = 2921
        public const int CG_FOG4 = 2921;
        #endregion CG_FOG4

        #region CG_FOG5
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG5 = 2922
        public const int CG_FOG5 = 2922;
        #endregion CG_FOG5

        #region CG_FOG6
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG6 = 2923
        public const int CG_FOG6 = 2923;
        #endregion CG_FOG6

        #region CG_FOG7
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG7 = 2924
        public const int CG_FOG7 = 2924;
        #endregion CG_FOG7

        #region CG_FOG8
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG8 = 2925
        public const int CG_FOG8 = 2925;
        #endregion CG_FOG8

        #region CG_FOG9
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG9 = 2926
        public const int CG_FOG9 = 2926;
        #endregion CG_FOG9

        #region CG_FOG10
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG10 = 2927
        public const int CG_FOG10 = 2927;
        #endregion CG_FOG10

        #region CG_FOG11
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG11 = 2928
        public const int CG_FOG11 = 2928;
        #endregion CG_FOG1

        #region CG_FOG12
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG12 = 2929
        public const int CG_FOG12 = 2929;
        #endregion CG_FOG1

        #region CG_FOG13
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG13 = 2930
        public const int CG_FOG13 = 2930;
        #endregion CG_FOG13

        #region CG_FOG14
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG14 = 2931
        public const int CG_FOG14 = 2931;
        #endregion CG_FOG14

        #region CG_FOG15
        /// <summary>
        ///     
        /// </summary>
        // CG_FOG1 = 2932
        public const int CG_FOG15 = 2932;
        #endregion CG_FOG15

        #region CG_DEPTH0
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH0 = 2933
        public const int CG_DEPTH0 = 2933;
        #endregion CG_DEPTH0

        #region CG_DEPTH1
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH1 = 2934
        public const int CG_DEPTH1 = 2934;
        #endregion CG_DEPTH1

        #region CG_DEPTH2
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH2 = 2935
        public const int CG_DEPTH2 = 2935;
        #endregion CG_DEPTH2

        #region CG_DEPTH3
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH3 = 2936
        public const int CG_DEPTH3 = 2936;
        #endregion CG_DEPTH3

        #region CG_DEPTH4
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH4 = 2937
        public const int CG_DEPTH4 = 2937;
        #endregion CG_DEPTH4

        #region CG_DEPTH5
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH5 = 2938
        public const int CG_DEPTH5 = 2938;
        #endregion CG_DEPTH5

        #region CG_DEPTH6
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH6 = 2939
        public const int CG_DEPTH6 = 2939;
        #endregion CG_DEPTH6

        #region CG_DEPTH7
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH7 = 2940
        public const int CG_DEPTH7 = 2940;
        #endregion CG_DEPTH7

        #region CG_DEPTH8
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH8 = 2941
        public const int CG_DEPTH8 = 2941;
        #endregion CG_DEPTH8

        #region CG_DEPTH9
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH9 = 29542;
        // TODO: Watch this value, it looks like an error, but that's how Nvidia defined it.
        public const int CG_DEPTH9 = 29542;
        #endregion CG_DEPTH9

        #region CG_DEPTH10
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH10 = 2943
        public const int CG_DEPTH10 = 2943;
        #endregion CG_DEPTH10

        #region CG_DEPTH11
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH11 = 2944
        public const int CG_DEPTH11 = 2944;
        #endregion CG_DEPTH11

        #region CG_DEPTH12
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH12 = 2945
        public const int CG_DEPTH12 = 2945;
        #endregion CG_DEPTH12

        #region CG_DEPTH13
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH13 = 2946
        public const int CG_DEPTH13 = 2946;
        #endregion CG_DEPTH13

        #region CG_DEPTH14
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH14 = 2947
        public const int CG_DEPTH14 = 2947;
        #endregion CG_DEPTH14

        #region CG_DEPTH15
        /// <summary>
        ///     
        /// </summary>
        // CG_DEPTH15 = 2948
        public const int CG_DEPTH15 = 2948;
        #endregion CG_DEPTH15

        #region CG_SAMPLE0
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE0 = 2949
        public const int CG_SAMPLE0 = 2949;
        #endregion CG_SAMPLE0

        #region CG_SAMPLE1
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE1 = 2950
        public const int CG_SAMPLE1 = 2950;
        #endregion CG_SAMPLE1

        #region CG_SAMPLE2
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE2 = 2951
        public const int CG_SAMPLE2 = 2951;
        #endregion CG_SAMPLE2

        #region CG_SAMPLE3
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE3 = 2952
        public const int CG_SAMPLE3 = 2952;
        #endregion CG_SAMPLE3

        #region CG_SAMPLE4
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE4 = 2953
        public const int CG_SAMPLE4 = 2953;
        #endregion CG_SAMPLE4

        #region CG_SAMPLE5
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE5 = 2954
        public const int CG_SAMPLE5 = 2954;
        #endregion CG_SAMPLE5

        #region CG_SAMPLE6
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE6 = 2955
        public const int CG_SAMPLE6 = 2955;
        #endregion CG_SAMPLE6

        #region CG_SAMPLE7
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE7 = 2956
        public const int CG_SAMPLE7 = 2956;
        #endregion CG_SAMPLE7

        #region CG_SAMPLE8
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE8 = 2957
        public const int CG_SAMPLE8 = 2957;
        #endregion CG_SAMPLE8

        #region CG_SAMPLE9
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE9 = 2958
        public const int CG_SAMPLE9 = 2958;
        #endregion CG_SAMPLE9

        #region CG_SAMPLE10
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE10 = 2959
        public const int CG_SAMPLE10 = 2959;
        #endregion CG_SAMPLE10

        #region CG_SAMPLE11
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE11 = 2960
        public const int CG_SAMPLE11 = 2960;
        #endregion CG_SAMPLE11

        #region CG_SAMPLE12
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE12 = 2961
        public const int CG_SAMPLE12 = 2961;
        #endregion CG_SAMPLE12

        #region CG_SAMPLE13
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE13 = 2962
        public const int CG_SAMPLE13 = 2962;
        #endregion CG_SAMPLE13

        #region CG_SAMPLE14
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE14 = 2963
        public const int CG_SAMPLE14 = 2963;
        #endregion CG_SAMPLE14

        #region CG_SAMPLE15
        /// <summary>
        ///     
        /// </summary>
        // CG_SAMPLE15 = 2964
        public const int CG_SAMPLE15 = 2964;
        #endregion CG_SAMPLE15

        #region CG_BLENDWEIGHT0
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT0 = 3028
        public const int CG_BLENDWEIGHT0 = 3028;
        #endregion CG_BLENDWEIGHT0

        #region CG_BLENDWEIGHT1
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT1 = 3029
        public const int CG_BLENDWEIGHT1 = 3029;
        #endregion CG_BLENDWEIGHT1

        #region CG_BLENDWEIGHT2
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT2 = 3030
        public const int CG_BLENDWEIGHT2 = 3030;
        #endregion CG_BLENDWEIGHT2

        #region CG_BLENDWEIGHT3
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT3 = 3031
        public const int CG_BLENDWEIGHT3 = 3031;
        #endregion CG_BLENDWEIGHT3

        #region CG_BLENDWEIGHT4
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT4 = 3032
        public const int CG_BLENDWEIGHT4 = 3032;
        #endregion CG_BLENDWEIGHT4

        #region CG_BLENDWEIGHT5
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT5 = 3033
        public const int CG_BLENDWEIGHT5 = 3033;
        #endregion CG_BLENDWEIGHT5

        #region CG_BLENDWEIGHT6
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT6 = 3034
        public const int CG_BLENDWEIGHT6 = 3034;
        #endregion CG_BLENDWEIGHT6

        #region CG_BLENDWEIGHT7
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT7 = 3035
        public const int CG_BLENDWEIGHT7 = 3035;
        #endregion CG_BLENDWEIGHT7

        #region CG_BLENDWEIGHT8
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT8 = 3036
        public const int CG_BLENDWEIGHT8 = 3036;
        #endregion CG_BLENDWEIGHT8

        #region CG_BLENDWEIGHT9
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT9 = 3037
        public const int CG_BLENDWEIGHT9 = 3037;
        #endregion CG_BLENDWEIGHT9

        #region CG_BLENDWEIGHT10
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT10 = 3038
        public const int CG_BLENDWEIGHT10 = 3038;
        #endregion CG_BLENDWEIGHT10

        #region CG_BLENDWEIGHT11
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT11 = 3039
        public const int CG_BLENDWEIGHT11 = 3039;
        #endregion CG_BLENDWEIGHT11

        #region CG_BLENDWEIGHT12
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT12 = 3040
        public const int CG_BLENDWEIGHT12 = 3040;
        #endregion CG_BLENDWEIGHT12

        #region CG_BLENDWEIGHT13
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT13 = 3041
        public const int CG_BLENDWEIGHT13 = 3041;
        #endregion CG_BLENDWEIGHT13

        #region CG_BLENDWEIGHT14
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT14 = 3042
        public const int CG_BLENDWEIGHT14 = 3042;
        #endregion CG_BLENDWEIGHT14

        #region CG_BLENDWEIGHT15
        /// <summary>
        ///     
        /// </summary>
        // CG_BLENDWEIGHT15 = 3043
        public const int CG_BLENDWEIGHT15 = 3043;
        #endregion CG_BLENDWEIGHT15

        #region CG_NORMAL0
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL0 = 3092
        public const int CG_NORMAL0 = 3092;
        #endregion CG_NORMAL0

        #region CG_NORMAL1
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL1 = 3093
        public const int CG_NORMAL1 = 3093;
        #endregion CG_NORMAL1

        #region CG_NORMAL2
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL2 = 3094
        public const int CG_NORMAL2 = 3094;
        #endregion CG_NORMAL2

        #region CG_NORMAL3
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL3 = 3095
        public const int CG_NORMAL3 = 3095;
        #endregion CG_NORMAL3

        #region CG_NORMAL4
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL4 = 3096
        public const int CG_NORMAL4 = 3096;
        #endregion CG_NORMAL4

        #region CG_NORMAL5
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL5 = 3097
        public const int CG_NORMAL5 = 3097;
        #endregion CG_NORMAL5

        #region CG_NORMAL6
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL6 = 3098
        public const int CG_NORMAL6 = 3098;
        #endregion CG_NORMAL6

        #region CG_NORMAL7
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL7 = 3099
        public const int CG_NORMAL7 = 3099;
        #endregion CG_NORMAL7

        #region CG_NORMAL8
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL8 = 3100
        public const int CG_NORMAL8 = 3100;
        #endregion CG_NORMAL8

        #region CG_NORMAL9
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL9 = 3101
        public const int CG_NORMAL9 = 3101;
        #endregion CG_NORMAL9

        #region CG_NORMAL10
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL10 = 3102
        public const int CG_NORMAL10 = 3102;
        #endregion CG_NORMAL10

        #region CG_NORMAL11
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL11 = 3103
        public const int CG_NORMAL11 = 3103;
        #endregion CG_NORMAL11

        #region CG_NORMAL12
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL12 = 3104
        public const int CG_NORMAL12 = 3104;
        #endregion CG_NORMAL12

        #region CG_NORMAL13
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL13 = 3105
        public const int CG_NORMAL13 = 3105;
        #endregion CG_NORMAL13

        #region CG_NORMAL14
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL14 = 3106
        public const int CG_NORMAL14 = 3106;
        #endregion CG_NORMAL14

        #region CG_NORMAL15
        /// <summary>
        ///     
        /// </summary>
        // CG_NORMAL15 = 3107
        public const int CG_NORMAL15 = 3107;
        #endregion CG_NORMAL15

        #region CG_FOGCOORD
        /// <summary>
        ///     
        /// </summary>
        // CG_FOGCOORD = 3156
        public const int CG_FOGCOORD = 3156;
        #endregion CG_FOGCOORD

        #region CG_TEXCOORD0
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD0 = 3220
        public const int CG_TEXCOORD0 = 3220;
        #endregion CG_TEXCOORD0

        #region CG_TEXCOORD1
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD1 = 3221
        public const int CG_TEXCOORD1 = 3221;
        #endregion CG_TEXCOORD1

        #region CG_TEXCOORD2
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD2 = 3222
        public const int CG_TEXCOORD2 = 3222;
        #endregion CG_TEXCOORD2

        #region CG_TEXCOORD3
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD3 = 3223
        public const int CG_TEXCOORD3 = 3223;
        #endregion CG_TEXCOORD3

        #region CG_TEXCOORD4
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD4 = 3224
        public const int CG_TEXCOORD4 = 3224;
        #endregion CG_TEXCOORD4

        #region CG_TEXCOORD5
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD5 = 3225
        public const int CG_TEXCOORD5 = 3225;
        #endregion CG_TEXCOORD5

        #region CG_TEXCOORD6
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD6 = 3226
        public const int CG_TEXCOORD6 = 3226;
        #endregion CG_TEXCOORD6

        #region CG_TEXCOORD7
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD7 = 3227
        public const int CG_TEXCOORD7 = 3227;
        #endregion CG_TEXCOORD7

        #region CG_TEXCOORD8
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD8 = 3228
        public const int CG_TEXCOORD8 = 3228;
        #endregion CG_TEXCOORD8

        #region CG_TEXCOORD9
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD9 = 3229
        public const int CG_TEXCOORD9 = 3229;
        #endregion CG_TEXCOORD9

        #region CG_TEXCOORD10
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD10 = 3230
        public const int CG_TEXCOORD10 = 3230;
        #endregion CG_TEXCOORD10

        #region CG_TEXCOORD11
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD11 = 3231
        public const int CG_TEXCOORD11 = 3231;
        #endregion CG_TEXCOORD11

        #region CG_TEXCOORD12
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD12 = 3232
        public const int CG_TEXCOORD12 = 3232;
        #endregion CG_TEXCOORD12

        #region CG_TEXCOORD13
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD13 = 3233
        public const int CG_TEXCOORD13 = 3233;
        #endregion CG_TEXCOORD13

        #region CG_TEXCOORD14
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD14 = 3234
        public const int CG_TEXCOORD14 = 3234;
        #endregion CG_TEXCOORD14

        #region CG_TEXCOORD15
        /// <summary>
        ///     
        /// </summary>
        // CG_TEXCOORD15 = 3235
        public const int CG_TEXCOORD15 = 3235;
        #endregion CG_TEXCOORD15

        #region CG_TESSFACTOR
        /// <summary>
        ///     
        /// </summary>
        // CG_TESSFACTOR = 3255
        public const int CG_TESSFACTOR = 3255;
        #endregion CG_TESSFACTOR

        #region CG_COMBINER_CONST0
        /// <summary>
        ///     
        /// </summary>
        // CG_COMBINER_CONST0 = 3284
        public const int CG_COMBINER_CONST0 = 3284;
        #endregion CG_COMBINER_CONST0

        #region CG_COMBINER_CONST1
        /// <summary>
        ///     
        /// </summary>
        // CG_COMBINER_CONST1 = 3285
        public const int CG_COMBINER_CONST1 = 3285;
        #endregion CG_COMBINER_CONST1

        #region CG_COMBINER_STAGE_CONST0
        /// <summary>
        ///     
        /// </summary>
        // CG_COMBINER_STAGE_CONST0 = 3286
        public const int CG_COMBINER_STAGE_CONST0 = 3286;
        #endregion CG_COMBINER_STAGE_CONST0

        #region CG_COMBINER_STAGE_CONST1
        /// <summary>
        ///     
        /// </summary>
        // CG_COMBINER_STAGE_CONST1 = 3287
        public const int CG_COMBINER_STAGE_CONST1 = 3287;
        #endregion CG_COMBINER_STAGE_CONST1

        #region CG_OFFSET_TEXTURE_MATRIX
        /// <summary>
        ///     
        /// </summary>
        // CG_OFFSET_TEXTURE_MATRIX = 3288
        public const int CG_OFFSET_TEXTURE_MATRIX = 3288;
        #endregion CG_OFFSET_TEXTURE_MATRIX

        #region CG_OFFSET_TEXTURE_SCALE
        /// <summary>
        ///     
        /// </summary>
        // CG_OFFSET_TEXTURE_SCALE = 3289
        public const int CG_OFFSET_TEXTURE_SCALE = 3289;
        #endregion CG_OFFSET_TEXTURE_SCALE

        #region CG_OFFSET_TEXTURE_BIAS
        /// <summary>
        ///     
        /// </summary>
        // CG_OFFSET_TEXTURE_BIAS = 3290
        public const int CG_OFFSET_TEXTURE_BIAS = 3290;
        #endregion CG_OFFSET_TEXTURE_BIAS

        #region CG_CONST_EYE
        /// <summary>
        ///     
        /// </summary>
        // CG_CONST_EYE = 3291
        public const int CG_CONST_EYE = 3291;
        #endregion CG_CONST_EYE
        #endregion BindLocations

        #region Data Types
        #region CG_FALSE
        /// <summary>
        ///     False.
        /// </summary>
        // #define CG_FALSE ((CGbool)0)
        public const int CG_FALSE = 0;
        #endregion CG_FALSE

        #region CG_TRUE
        /// <summary>
        ///     True.
        /// </summary>
        // #define CG_TRUE ((CGbool)1)
        public const int CG_TRUE = 1;
        #endregion CG_TRUE

        #region CG_UNKNOWN_TYPE
        /// <summary>
        ///     An unknown data type.
        /// </summary>
        // CG_UNKNOWN_TYPE = 0
        public const int CG_UNKNOWN_TYPE = 0;
        #endregion CG_UNKNOWN_TYPE

        #region CG_STRUCT
        /// <summary>
        ///     A collection of one or more members of possibly different types.
        /// </summary>
        // CG_STRUCT = 1
        public const int CG_STRUCT = 1;
        #endregion CG_STRUCT

        #region CG_ARRAY
        /// <summary>
        ///     A collection of one or more elements of the same type.
        /// </summary>
        // CG_ARRAY = 2
        public const int CG_ARRAY = 2;
        #endregion CG_ARRAY

        #region CG_TYPE_START_ENUM
        /// <summary>
        ///     Start of the Cg data type definitions.
        /// </summary>
        // CG_TYPE_START_ENUM = 1024
        public const int CG_TYPE_START_ENUM = 1024;
        #endregion CG_TYPE_START_ENUM

        #region CG_HALF
        /// <summary>
        ///     The half type is lower-precision IEEE-like floating point.  Profiles must
        ///     support the half type, but may choose to implement it with the same precision
        ///     as the float type.
        /// </summary>
        // CG_HALF = 1025
        public const int CG_HALF = 1025;
        #endregion CG_HALF

        #region CG_HALF2
        /// <summary>
        ///     Two-element, packed, half array (vector type).
        /// </summary>
        // CG_HALF2 = 1026
        public const int CG_HALF2 = 1026;
        #endregion CG_HALF2

        #region CG_HALF3
        /// <summary>
        ///     Three-element, packed, half array (vector type).
        /// </summary>
        // CG_HALF3 = 1027
        public const int CG_HALF3 = 1027;
        #endregion CG_HALF3

        #region CG_HALF4
        /// <summary>
        ///     Four-element, packed, half array (vector type).
        /// </summary>
        // CG_HALF4 = 1028
        public const int CG_HALF4 = 1028;
        #endregion CG_HALF4

        #region CG_HALF1x1
        /// <summary>
        ///     1x1, packed, half array (matrix type).
        /// </summary>
        // CG_HALF1x1 = 1029
        public const int CG_HALF1x1 = 1029;
        #endregion CG_HALF1x1

        #region CG_HALF1x2
        /// <summary>
        ///     1x2, packed, half array (matrix type).
        /// </summary>
        // CG_HALF1x2 = 1030
        public const int CG_HALF1x2 = 1030;
        #endregion CG_HALF1x2

        #region CG_HALF1x3
        /// <summary>
        ///     1x3, packed, half array (matrix type).
        /// </summary>
        // CG_HALF1x3 = 1031
        public const int CG_HALF1x3 = 1031;
        #endregion CG_HALF1x3

        #region CG_HALF1x4
        /// <summary>
        ///     1x4, packed, half array (matrix type).
        /// </summary>
        // CG_HALF1x4 = 1032
        public const int CG_HALF1x4 = 1032;
        #endregion CG_HALF1x4

        #region CG_HALF2x1
        /// <summary>
        ///     2x1, packed, half array (matrix type).
        /// </summary>
        // CG_HALF2x1 = 1033
        public const int CG_HALF2x1 = 1033;
        #endregion CG_HALF2x1

        #region CG_HALF2x2
        /// <summary>
        ///     2x2, packed, half array (matrix type).
        /// </summary>
        // CG_HALF2x2 = 1034
        public const int CG_HALF2x2 = 1034;
        #endregion CG_HALF2x2

        #region CG_HALF2x3
        /// <summary>
        ///     2x3, packed, half array (matrix type).
        /// </summary>
        // CG_HALF2x3 = 1035
        public const int CG_HALF2x3 = 1035;
        #endregion CG_HALF2x3

        #region CG_HALF2x4
        /// <summary>
        ///     2x4, packed, half array (matrix type).
        /// </summary>
        // CG_HALF2x4 = 1036
        public const int CG_HALF2x4 = 1036;
        #endregion CG_HALF2x4

        #region CG_HALF3x1
        /// <summary>
        ///     3x1, packed, half array (matrix type).
        /// </summary>
        // CG_HALF3x1 = 1037
        public const int CG_HALF3x1 = 1037;
        #endregion CG_HALF3x1

        #region CG_HALF3x2
        /// <summary>
        ///     3x2, packed, half array (matrix type).
        /// </summary>
        // CG_HALF3x2 = 1038
        public const int CG_HALF3x2 = 1038;
        #endregion CG_HALF3x2

        #region CG_HALF3x3
        /// <summary>
        ///     3x3, packed, half array (matrix type).
        /// </summary>
        // CG_HALF3x3 = 1039
        public const int CG_HALF3x3 = 1039;
        #endregion CG_HALF3x3

        #region CG_HALF3x4
        /// <summary>
        ///     3x4, packed, half array (matrix type).
        /// </summary>
        // CG_HALF3x4 = 1040
        public const int CG_HALF3x4 = 1040;
        #endregion CG_HALF3x4

        #region CG_HALF4x1
        /// <summary>
        ///     4x1, packed, half array (matrix type).
        /// </summary>
        // CG_HALF4x1 = 1041
        public const int CG_HALF4x1 = 1041;
        #endregion CG_HALF4x1

        #region CG_HALF4x2
        /// <summary>
        ///     4x2, packed, half array (matrix type).
        /// </summary>
        // CG_HALF4x2 = 1042
        public const int CG_HALF4x2 = 1042;
        #endregion CG_HALF4x2

        #region CG_HALF4x3
        /// <summary>
        ///     4x3, packed, half array (matrix type).
        /// </summary>
        // CG_HALF4x3 = 1043
        public const int CG_HALF4x3 = 1043;
        #endregion CG_HALF4x3

        #region CG_HALF4x4
        /// <summary>
        ///     4x4, packed, half array (matrix type).
        /// </summary>
        // CG_HALF4x4 = 1044
        public const int CG_HALF4x4 = 1044;
        #endregion CG_HALF4x4

        #region CG_FLOAT
        /// <summary>
        ///     The float type is as close as possible to the IEEE single precision (32-bit)
        ///     floating point.  Profiles must support the float data type.
        /// </summary>
        // CG_FLOAT = 1045
        public const int CG_FLOAT = 1045;
        #endregion CG_FLOAT

        #region CG_FLOAT2
        /// <summary>
        ///     Two-element, packed, float array (vector type).
        /// </summary>
        // CG_FLOAT2 = 1046
        public const int CG_FLOAT2 = 1046;
        #endregion CG_FLOAT2

        #region CG_FLOAT3
        /// <summary>
        ///     Three-element, packed, float array (vector type).
        /// </summary>
        // CG_FLOAT3 = 1047
        public const int CG_FLOAT3 = 1047;
        #endregion CG_FLOAT3

        #region CG_FLOAT4
        /// <summary>
        ///     Four-element, packed, float array (vector type).
        /// </summary>
        // CG_FLOAT4 = 1048
        public const int CG_FLOAT4 = 1048;
        #endregion CG_FLOAT4

        #region CG_FLOAT1x1
        /// <summary>
        ///     1x1, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT1x1 = 1049
        public const int CG_FLOAT1x1 = 1049;
        #endregion CG_FLOAT1x1

        #region CG_FLOAT1x2
        /// <summary>
        ///     1x2, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT1x2 = 1050
        public const int CG_FLOAT1x2 = 1050;
        #endregion CG_FLOAT1x2

        #region CG_FLOAT1x3
        /// <summary>
        ///     1x3, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT1x3 = 1051
        public const int CG_FLOAT1x3 = 1051;
        #endregion CG_FLOAT1x3

        #region CG_FLOAT1x4
        /// <summary>
        ///     1x4, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT1x4 = 1052
        public const int CG_FLOAT1x4 = 1052;
        #endregion CG_FLOAT1x4

        #region CG_FLOAT2x1
        /// <summary>
        ///     2x1, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT2x1 = 1053
        public const int CG_FLOAT2x1 = 1053;
        #endregion CG_FLOAT2x1

        #region CG_FLOAT2x2
        /// <summary>
        ///     2x2, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT2x2 = 1054
        public const int CG_FLOAT2x2 = 1054;
        #endregion CG_FLOAT2x2

        #region CG_FLOAT2x3
        /// <summary>
        ///     2x3, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT2x3 = 1055
        public const int CG_FLOAT2x3 = 1055;
        #endregion CG_FLOAT2x3

        #region CG_FLOAT2x4
        /// <summary>
        ///     2x4, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT2x4 = 1056
        public const int CG_FLOAT2x4 = 1056;
        #endregion CG_FLOAT2x4

        #region CG_FLOAT3x1
        /// <summary>
        ///     3x1, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT3x1 = 1057
        public const int CG_FLOAT3x1 = 1057;
        #endregion CG_FLOAT3x1

        #region CG_FLOAT3x2
        /// <summary>
        ///     3x2, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT3x2 = 1058
        public const int CG_FLOAT3x2 = 1058;
        #endregion CG_FLOAT3x2

        #region CG_FLOAT3x3
        /// <summary>
        ///     3x3, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT3x3 = 1059
        public const int CG_FLOAT3x3 = 1059;
        #endregion CG_FLOAT3x3

        #region CG_FLOAT3x4
        /// <summary>
        ///     3x4, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT3x4 = 1060
        public const int CG_FLOAT3x4 = 1060;
        #endregion CG_FLOAT3x4

        #region CG_FLOAT4x1
        /// <summary>
        ///     4x1, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT4x1 = 1061
        public const int CG_FLOAT4x1 = 1061;
        #endregion CG_FLOAT4x1

        #region CG_FLOAT4x2
        /// <summary>
        ///     4x2, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT4x2 = 1062
        public const int CG_FLOAT4x2 = 1062;
        #endregion CG_FLOAT4x2

        #region CG_FLOAT4x3
        /// <summary>
        ///     4x3, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT4x3 = 1063
        public const int CG_FLOAT4x3 = 1063;
        #endregion CG_FLOAT4x3

        #region CG_FLOAT4x4
        /// <summary>
        ///     4x4, packed, float array (matrix type).
        /// </summary>
        // CG_FLOAT4x4 = 1064
        public const int CG_FLOAT4x4 = 1064;
        #endregion CG_FLOAT4x4

        #region CG_SAMPLER1D
        /// <summary>
        ///     A handle to a 1-dimensional texture object.
        /// </summary>
        // CG_SAMPLER1D = 1065
        public const int CG_SAMPLER1D = 1065;
        #endregion CG_SAMPLER1D

        #region CG_SAMPLER2D
        /// <summary>
        ///     A handle to a 2-dimensional texture object.
        /// </summary>
        // CG_SAMPLER2D = 1066
        public const int CG_SAMPLER2D = 1066;
        #endregion CG_SAMPLER2D

        #region CG_SAMPLER3D
        /// <summary>
        ///     A handle to a 3-dimensional texture object.
        /// </summary>
        // CG_SAMPLER3D = 1067
        public const int CG_SAMPLER3D = 1067;
        #endregion CG_SAMPLER3D

        #region CG_SAMPLERRECT
        /// <summary>
        ///     A handle to a texture object rectangle.
        /// </summary>
        // CG_SAMPLERRECT = 1068
        public const int CG_SAMPLERRECT = 1068;
        #endregion CG_SAMPLERRECT

        #region CG_SAMPLERCUBE
        /// <summary>
        ///     A handle to a texture object cube map.
        /// </summary>
        // CG_SAMPLERCUBE = 1069
        public const int CG_SAMPLERCUBE = 1069;
        #endregion CG_SAMPLERCUBE

        #region CG_FIXED
        /// <summary>
        ///     The fixed type is a signed type with a range of at least [-2,2) and with at
        ///     least 10 bits of fractional precision.  Overflow operations on the data type
        ///     clamp rather than wrap.  Fragment profiles must support the fixed type, but
        ///     may implement it with the same precision as the half or float types.
        ///     Vertex profiles are required to provide partial support for the fixed type.
        ///     Vertex profiles have the option to provide full support for the fixed type or
        ///     to implement the fixed type with the same precision as the half or float types.
        /// </summary>
        // CG_FIXED = 1070
        public const int CG_FIXED = 1070;
        #endregion CG_FIXED

        #region CG_FIXED2
        /// <summary>
        ///     Two-element, packed, fixed array (vector type).
        /// </summary>
        // CG_FIXED2 = 1071
        public const int CG_FIXED2 = 1071;
        #endregion CG_FIXED2

        #region CG_FIXED3
        /// <summary>
        ///     Three-element, packed, fixed array (vector type).
        /// </summary>
        // CG_FIXED3 = 1072
        public const int CG_FIXED3 = 1072;
        #endregion CG_FIXED3

        #region CG_FIXED4
        /// <summary>
        ///     Four-element, packed, fixed array (vector type).
        /// </summary>
        // CG_FIXED4 = 1073
        public const int CG_FIXED4 = 1073;
        #endregion CG_FIXED4

        #region CG_FIXED1x1
        /// <summary>
        ///     1x1, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED1x1 = 1074
        public const int CG_FIXED1x1 = 1074;
        #endregion CG_FIXED1x1

        #region CG_FIXED1x2
        /// <summary>
        ///     1x2, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED1x2 = 1075
        public const int CG_FIXED1x2 = 1075;
        #endregion CG_FIXED1x2

        #region CG_FIXED1x3
        /// <summary>
        ///     1x3, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED1x3 = 1076
        public const int CG_FIXED1x3 = 1076;
        #endregion CG_FIXED1x3

        #region CG_FIXED1x4
        /// <summary>
        ///     1x4, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED1x4 = 1077
        public const int CG_FIXED1x4 = 1077;
        #endregion CG_FIXED1x4

        #region CG_FIXED2x1
        /// <summary>
        ///     2x1, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED2x1 = 1078
        public const int CG_FIXED2x1 = 1078;
        #endregion CG_FIXED2x1

        #region CG_FIXED2x2
        /// <summary>
        ///     2x2, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED2x2 = 1079
        public const int CG_FIXED2x2 = 1079;
        #endregion CG_FIXED2x2

        #region CG_FIXED2x3
        /// <summary>
        ///     2x3, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED2x3 = 1080
        public const int CG_FIXED2x3 = 1080;
        #endregion CG_FIXED2x3

        #region CG_FIXED2x4
        /// <summary>
        ///     2x4, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED2x4 = 1081
        public const int CG_FIXED2x4 = 1081;
        #endregion CG_FIXED2x4

        #region CG_FIXED3x1
        /// <summary>
        ///     3x1, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED3x1 = 1082
        public const int CG_FIXED3x1 = 1082;
        #endregion CG_FIXED3x1

        #region CG_FIXED3x2
        /// <summary>
        ///     3x2, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED3x2 = 1083
        public const int CG_FIXED3x2 = 1083;
        #endregion CG_FIXED3x2

        #region CG_FIXED3x3
        /// <summary>
        ///     3x3, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED3x3 = 1084
        public const int CG_FIXED3x3 = 1084;
        #endregion CG_FIXED3x3

        #region CG_FIXED3x4
        /// <summary>
        ///     3x4, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED3x4 = 1085
        public const int CG_FIXED3x4 = 1085;
        #endregion CG_FIXED3x4

        #region CG_FIXED4x1
        /// <summary>
        ///     4x1, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED4x1 = 1086
        public const int CG_FIXED4x1 = 1086;
        #endregion CG_FIXED4x1

        #region CG_FIXED4x2
        /// <summary>
        ///     4x2, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED4x2 = 1087
        public const int CG_FIXED4x2 = 1087;
        #endregion CG_FIXED4x2

        #region CG_FIXED4x3
        /// <summary>
        ///     4x3, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED4x3 = 1088
        public const int CG_FIXED4x3 = 1088;
        #endregion CG_FIXED4x3

        #region CG_FIXED4x4
        /// <summary>
        ///     4x4, packed, fixed array (matrix type).
        /// </summary>
        // CG_FIXED4x4 = 1089
        public const int CG_FIXED4x4 = 1089;
        #endregion CG_FIXED4x4

        #region CG_HALF1
        /// <summary>
        ///     Single-element, packed, half array (vector type).
        /// </summary>
        // CG_HALF1 = 1090
        public const int CG_HALF1 = 1090;
        #endregion CG_HALF1

        #region CG_FLOAT1
        /// <summary>
        ///     Single-element, packed, float array (vector type).
        /// </summary>
        // CG_FLOAT1 = 1091
        public const int CG_FLOAT1 = 1091;
        #endregion CG_FLOAT1

        #region CG_FIXED1
        /// <summary>
        ///     Single-element, packed, fixed array (vector type).
        /// </summary>
        // CG_FIXED1 = 1092
        public const int CG_FIXED1 = 1092;
        #endregion CG_FIXED1

        #region CG_INT
        /// <summary>
        ///     The int type is preferably 32-bit two’s complement.  Profiles may
        ///     optionally treat int as float.
        /// </summary>
        // CG_INT = 1093
        public const int CG_INT = 1093;
        #endregion CG_INT

        #region CG_INT1
        /// <summary>
        ///     Single-element, packed, int array (vector type).
        /// </summary>
        // CG_INT2 = 1094
        public const int CG_INT1 = 1094;
        #endregion CG_INT1

        #region CG_INT2
        /// <summary>
        ///     Two-element, packed, int array (vector type).
        /// </summary>
        // CG_INT2 = 1095
        public const int CG_INT2 = 1095;
        #endregion CG_INT2

        #region CG_INT3
        /// <summary>
        ///     Three-element, packed, int array (vector type).
        /// </summary>
        // CG_INT3 = 1096
        public const int CG_INT3 = 1096;
        #endregion CG_INT3

        #region CG_INT4
        /// <summary>
        ///     Four-element, packed, int array (vector type).
        /// </summary>
        // CG_INT4 = 1097
        public const int CG_INT4 = 1097;
        #endregion CG_INT4

        #region CG_INT1x1
        /// <summary>
        ///     1x1, packed, int array (matrix type).
        /// </summary>
        // CG_INT1x1 = 1098
        public const int CG_INT1x1 = 1098;
        #endregion CG_INT1x1

        #region CG_INT1x2
        /// <summary>
        ///     1x2, packed, int array (matrix type).
        /// </summary>
        // CG_INT1x2 = 1099
        public const int CG_INT1x2 = 1099;
        #endregion CG_INT1x2

        #region CG_INT1x3
        /// <summary>
        ///     1x3, packed, int array (matrix type).
        /// </summary>
        // CG_INT1x3 = 1100
        public const int CG_INT1x3 = 1100;
        #endregion CG_INT1x3

        #region CG_INT1x4
        /// <summary>
        ///     1x4, packed, int array (matrix type).
        /// </summary>
        // CG_INT1x4 = 1101
        public const int CG_INT1x4 = 1101;
        #endregion CG_INT1x4

        #region CG_INT2x1
        /// <summary>
        ///     2x1, packed, int array (matrix type).
        /// </summary>
        // CG_INT2x1 = 1102
        public const int CG_INT2x1 = 1102;
        #endregion CG_INT2x1

        #region CG_INT2x2
        /// <summary>
        ///     2x2, packed, int array (matrix type).
        /// </summary>
        // CG_INT2x2 = 1103
        public const int CG_INT2x2 = 1103;
        #endregion CG_INT2x2

        #region CG_INT2x3
        /// <summary>
        ///     2x3, packed, int array (matrix type).
        /// </summary>
        // CG_INT2x3 = 1104
        public const int CG_INT2x3 = 1104;
        #endregion CG_INT2x3

        #region CG_INT2x4
        /// <summary>
        ///     2x4, packed, int array (matrix type).
        /// </summary>
        // CG_INT2x4 = 1105
        public const int CG_INT2x4 = 1105;
        #endregion CG_INT2x4

        #region CG_INT3x1
        /// <summary>
        ///     3x1, packed, int array (matrix type).
        /// </summary>
        // CG_INT3x1 = 1106
        public const int CG_INT3x1 = 1106;
        #endregion CG_INT3x1

        #region CG_INT3x2
        /// <summary>
        ///     3x2, packed, int array (matrix type).
        /// </summary>
        // CG_INT3x2 = 1107
        public const int CG_INT3x2 = 1107;
        #endregion CG_INT3x2

        #region CG_INT3x3
        /// <summary>
        ///     3x3, packed, int array (matrix type).
        /// </summary>
        // CG_INT3x3 = 1108
        public const int CG_INT3x3 = 1108;
        #endregion CG_INT3x3

        #region CG_INT3x4
        /// <summary>
        ///     3x4, packed, int array (matrix type).
        /// </summary>
        // CG_INT3x4 = 1109
        public const int CG_INT3x4 = 1109;
        #endregion CG_INT3x4

        #region CG_INT4x1
        /// <summary>
        ///     4x1, packed, int array (matrix type).
        /// </summary>
        // CG_INT4x1 = 1110
        public const int CG_INT4x1 = 1110;
        #endregion CG_INT4x1

        #region CG_INT4x2
        /// <summary>
        ///     4x2, packed, int array (matrix type).
        /// </summary>
        // CG_INT4x2 = 1111
        public const int CG_INT4x2 = 1111;
        #endregion CG_INT4x2

        #region CG_INT4x3
        /// <summary>
        ///     4x3, packed, int array (matrix type).
        /// </summary>
        // CG_INT4x3 = 1112
        public const int CG_INT4x3 = 1112;
        #endregion CG_INT4x3

        #region CG_INT4x4
        /// <summary>
        ///     4x4, packed, int array (matrix type).
        /// </summary>
        // CG_INT4x4 = 1113
        public const int CG_INT4x4 = 1113;
        #endregion CG_INT4x4

        #region CG_BOOL
        /// <summary>
        ///     The bool type represents Boolean values.  Objects of bool type are either
        ///     true or false.
        /// </summary>
        // CG_BOOL = 1114
        public const int CG_BOOL = 1114;
        #endregion CG_BOOL

        #region CG_BOOL1
        /// <summary>
        ///     Single-element, packed, bool array (vector type).
        /// </summary>
        // CG_BOOL2 = 1115
        public const int CG_BOOL1 = 1115;
        #endregion CG_BOOL1

        #region CG_BOOL2
        /// <summary>
        ///     Two-element, packed, bool array (vector type).
        /// </summary>
        // CG_BOOL2 = 1116
        public const int CG_BOOL2 = 1116;
        #endregion CG_BOOL2

        #region CG_BOOL3
        /// <summary>
        ///     Three-element, packed, bool array (vector type).
        /// </summary>
        // CG_BOOL3 = 1117
        public const int CG_BOOL3 = 1117;
        #endregion CG_BOOL3

        #region CG_BOOL4
        /// <summary>
        ///     Four-element, packed, bool array (vector type).
        /// </summary>
        // CG_BOOL4 = 1118
        public const int CG_BOOL4 = 1118;
        #endregion CG_BOOL4

        #region CG_BOOL1x1
        /// <summary>
        ///     1x1, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL1x1 = 1119
        public const int CG_BOOL1x1 = 1119;
        #endregion CG_BOOL1x1

        #region CG_BOOL1x2
        /// <summary>
        ///     1x2, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL1x2 = 1120
        public const int CG_BOOL1x2 = 1120;
        #endregion CG_BOOL1x2

        #region CG_BOOL1x3
        /// <summary>
        ///     1x3, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL1x3 = 1121
        public const int CG_BOOL1x3 = 1121;
        #endregion CG_BOOL1x3

        #region CG_BOOL1x4
        /// <summary>
        ///     1x4, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL1x4 = 1122
        public const int CG_BOOL1x4 = 1122;
        #endregion CG_BOOL1x4

        #region CG_BOOL2x1
        /// <summary>
        ///     2x1, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL2x1 = 1123
        public const int CG_BOOL2x1 = 1123;
        #endregion CG_BOOL2x1

        #region CG_BOOL2x2
        /// <summary>
        ///     2x2, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL2x2 = 1124
        public const int CG_BOOL2x2 = 1124;
        #endregion CG_BOOL2x2

        #region CG_BOOL2x3
        /// <summary>
        ///     2x3, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL2x3 = 1125
        public const int CG_BOOL2x3 = 1125;
        #endregion CG_BOOL2x3

        #region CG_BOOL2x4
        /// <summary>
        ///     2x4, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL2x4 = 1126
        public const int CG_BOOL2x4 = 1126;
        #endregion CG_BOOL2x4

        #region CG_BOOL3x1
        /// <summary>
        ///     3x1, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL3x1 = 1127
        public const int CG_BOOL3x1 = 1127;
        #endregion CG_BOOL3x1

        #region CG_BOOL3x2
        /// <summary>
        ///     3x2, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL3x2 = 1128
        public const int CG_BOOL3x2 = 1128;
        #endregion CG_BOOL3x2

        #region CG_BOOL3x3
        /// <summary>
        ///     3x3, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL3x3 = 1129
        public const int CG_BOOL3x3 = 1129;
        #endregion CG_BOOL3x3

        #region CG_BOOL3x4
        /// <summary>
        ///     3x4, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL3x4 = 1130
        public const int CG_BOOL3x4 = 1130;
        #endregion CG_BOOL3x4

        #region CG_BOOL4x1
        /// <summary>
        ///     4x1, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL4x1 = 1131
        public const int CG_BOOL4x1 = 1131;
        #endregion CG_BOOL4x1

        #region CG_BOOL4x2
        /// <summary>
        ///     4x2, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL4x2 = 1132
        public const int CG_BOOL4x2 = 1132;
        #endregion CG_BOOL4x2

        #region CG_BOOL4x3
        /// <summary>
        ///     4x3, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL4x3 = 1133
        public const int CG_BOOL4x3 = 1133;
        #endregion CG_BOOL4x3

        #region CG_BOOL4x4
        /// <summary>
        ///     4x4, packed, bool array (matrix type).
        /// </summary>
        // CG_BOOL4x4 = 1134
        public const int CG_BOOL4x4 = 1134;
        #endregion CG_BOOL4x4
        #endregion Data Types

        #region Enums
        #region CG_UNKNOWN
        /// <summary>
        ///     Unknown resource.
        /// </summary>
        // CG_UNKNOWN = 4096
        public const int CG_UNKNOWN = 4096;
        #endregion CG_UNKNOWN

        #region CG_IN
        /// <summary>
        ///     Specifies an input parameter.
        /// </summary>
        // CG_IN = 4097
        public const int CG_IN = 4097;
        #endregion CG_IN

        #region CG_OUT
        /// <summary>
        ///     Specifies an output parameter.
        /// </summary>
        // CG_OUT = 4098
        public const int CG_OUT = 4098;
        #endregion CG_OUT

        #region CG_INOUT
        /// <summary>
        ///     Specifies a parameter that is both input and output.
        /// </summary>
        // CG_INOUT = 4099
        public const int CG_INOUT = 4099;
        #endregion CG_INOUT

        #region CG_MIXED
        /// <summary>
        ///     A structure parameter that contains parameters that differ in variability.
        /// </summary>
        // CG_MIXED = 4100
        public const int CG_MIXED = 4100;
        #endregion CG_MIXED

        #region CG_VARYING
        /// <summary>
        ///     A varying parameter is one whose value changes with each invocation of the
        ///     program.
        /// </summary>
        // CG_VARYING = 4101
        public const int CG_VARYING = 4101;
        #endregion CG_VARYING

        #region CG_UNIFORM
        /// <summary>
        ///     A uniform parameter is one whose value does not chance with each invocation of a
        ///     program, but whose value can change between groups of program invocations.
        /// </summary>
        // CG_UNIFORM = 4102
        public const int CG_UNIFORM = 4102;
        #endregion CG_UNIFORM

        #region CG_CONSTANT
        /// <summary>
        ///     A constant parameter never changes for the life of a compiled program.
        ///     Modifying a constant parameter requires program recompilation.
        /// </summary>
        // CG_CONSTANT = 4103
        public const int CG_CONSTANT = 4103;
        #endregion CG_CONSTANT

        #region CG_PROGRAM_SOURCE
        /// <summary>
        ///     The original Cg source program.
        /// </summary>
        // CG_PROGRAM_SOURCE = 4104
        public const int CG_PROGRAM_SOURCE = 4104;
        #endregion CG_PROGRAM_SOURCE

        #region CG_PROGRAM_ENTRY
        /// <summary>
        ///     The main entry point for the program.
        /// </summary>
        // CG_PROGRAM_ENTRY = 4105
        public const int CG_PROGRAM_ENTRY = 4105;
        #endregion CG_PROGRAM_ENTRY

        #region CG_COMPILED_PROGRAM
        /// <summary>
        ///     The string for the compiled program.
        /// </summary>
        // CG_COMPILED_PROGRAM = 4106
        public const int CG_COMPILED_PROGRAM = 4106;
        #endregion CG_COMPILED_PROGRAM

        #region CG_PROGRAM_PROFILE
        /// <summary>
        ///     The profile for the program.
        /// </summary>
        // CG_PROGRAM_PROFILE = 4107
        public const int CG_PROGRAM_PROFILE = 4107;
        #endregion CG_PROGRAM_PROFILE

        #region CG_GLOBAL
        /// <summary>
        ///     A global.
        /// </summary>
        // CG_GLOBAL = 4108
        public const int CG_GLOBAL = 4108;
        #endregion CG_GLOBAL

        #region CG_PROGRAM
        /// <summary>
        ///     The program.
        /// </summary>
        // CG_PROGRAM = 4109
        public const int CG_PROGRAM = 4109;
        #endregion CG_PROGRAM

        #region CG_DEFAULT
        /// <summary>
        ///     The default values for a uniform parameter.
        /// </summary>
        // CG_DEFAULT = 4110
        public const int CG_DEFAULT = 4110;
        #endregion CG_DEFAULT

        #region CG_ERROR
        /// <summary>
        ///     An error.
        /// </summary>
        // CG_ERROR = 4111
        public const int CG_ERROR = 4111;
        #endregion CG_ERROR

        #region CG_SOURCE
        /// <summary>
        ///     A string that contains Cg source code.
        /// </summary>
        // CG_SOURCE = 4112
        public const int CG_SOURCE = 4112;
        #endregion CG_SOURCE

        #region CG_OBJECT
        /// <summary>
        ///     A string that contains object code that resulted from the precompilation of some
        ///     Cg source code.
        /// </summary>
        // CG_OBJECT = 4113
        public const int CG_OBJECT = 4113;
        #endregion CG_OBJECT
        #endregion Enums

        #region Errors
        #region CG_NO_ERROR
        /// <summary>
        ///     No error has occurred.
        /// </summary>
        // CG_NO_ERROR = 0
        public const int CG_NO_ERROR = 0;
        #endregion CG_NO_ERROR

        #region CG_COMPILER_ERROR
        /// <summary>
        ///     The compile returned an error.
        /// </summary>
        // CG_COMPILER_ERROR = 1
        public const int CG_COMPILER_ERROR = 1;
        #endregion CG_COMPILER_ERROR

        #region CG_INVALID_PARAMETER_ERROR
        /// <summary>
        ///     The parameter used is invalid.
        /// </summary>
        // CG_INVALID_PARAMETER_ERROR = 2
        public const int CG_INVALID_PARAMETER_ERROR = 2;
        #endregion CG_INVALID_PARAMETER_ERROR

        #region CG_INVALID_PROFILE_ERROR
        /// <summary>
        ///     The profile is not supported.
        /// </summary>
        // CG_INVALID_PROFILE_ERROR = 3
        public const int CG_INVALID_PROFILE_ERROR = 3;
        #endregion CG_INVALID_PROFILE_ERROR

        #region CG_PROGRAM_LOAD_ERROR
        /// <summary>
        ///     The program could not load.
        /// </summary>
        // CG_PROGRAM_LOAD_ERROR = 4
        public const int CG_PROGRAM_LOAD_ERROR = 4;
        #endregion CG_PROGRAM_LOAD_ERROR

        #region CG_PROGRAM_BIND_ERROR
        /// <summary>
        ///     The program could not bind.
        /// </summary>
        // CG_PROGRAM_BIND_ERROR = 5
        public const int CG_PROGRAM_BIND_ERROR = 5;
        #endregion CG_PROGRAM_BIND_ERROR

        #region CG_PROGRAM_NOT_LOADED_ERROR
        /// <summary>
        ///     The program must be loaded before this operation may be used.
        /// </summary>
        // CG_PROGRAM_NOT_LOADED_ERROR = 6
        public const int CG_PROGRAM_NOT_LOADED_ERROR = 6;
        #endregion CG_PROGRAM_NOT_LOADED_ERROR

        #region CG_UNSUPPORTED_GL_EXTENSION_ERROR
        /// <summary>
        ///     An unsupported GL extension was required to perform this operation.
        /// </summary>
        // CG_UNSUPPORTED_GL_EXTENSION_ERROR = 7
        public const int CG_UNSUPPORTED_GL_EXTENSION_ERROR = 7;
        #endregion CG_UNSUPPORTED_GL_EXTENSION_ERROR

        #region CG_INVALID_VALUE_TYPE_ERROR
        /// <summary>
        ///     An unknown value type was assigned to a parameter.
        /// </summary>
        // CG_INVALID_VALUE_TYPE_ERROR = 8
        public const int CG_INVALID_VALUE_TYPE_ERROR = 8;
        #endregion CG_INVALID_VALUE_TYPE_ERROR

        #region CG_NOT_MATRIX_PARAM_ERROR
        /// <summary>
        ///     The parameter is not of matrix type.
        /// </summary>
        // CG_NOT_MATRIX_PARAM_ERROR = 9
        public const int CG_NOT_MATRIX_PARAM_ERROR = 9;
        #endregion CG_NOT_MATRIX_PARAM_ERROR

        #region CG_INVALID_ENUMERANT_ERROR
        /// <summary>
        ///     The enumerant parameter has an invalid value.
        /// </summary>
        // CG_INVALID_ENUMERANT_ERROR = 10
        public const int CG_INVALID_ENUMERANT_ERROR = 10;
        #endregion CG_INVALID_ENUMERANT_ERROR

        #region CG_NOT_4x4_MATRIX_ERROR
        /// <summary>
        ///     The parameter must be a 4x4 matrix type.
        /// </summary>
        // CG_NOT_4x4_MATRIX_ERROR = 11
        public const int CG_NOT_4x4_MATRIX_ERROR = 11;
        #endregion CG_NOT_4x4_MATRIX_ERROR

        #region CG_FILE_READ_ERROR
        /// <summary>
        ///     The file could not be read.
        /// </summary>
        // CG_FILE_READ_ERROR = 12
        public const int CG_FILE_READ_ERROR = 12;
        #endregion CG_FILE_READ_ERROR

        #region CG_FILE_WRITE_ERROR
        /// <summary>
        ///     The file could not be written.
        /// </summary>
        // CG_FILE_WRITE_ERROR = 13
        public const int CG_FILE_WRITE_ERROR = 13;
        #endregion CG_FILE_WRITE_ERROR

        #region CG_NVPARSE_ERROR
        /// <summary>
        ///     nvparse could not successfully parse the output from the Cg compiler backend.
        /// </summary>
        // CG_NVPARSE_ERROR = 14
        public const int CG_NVPARSE_ERROR = 14;
        #endregion CG_NVPARSE_ERROR

        #region CG_MEMORY_ALLOC_ERROR
        /// <summary>
        ///     Memory allocation failed.
        /// </summary>
        // CG_MEMORY_ALLOC_ERROR = 15
        public const int CG_MEMORY_ALLOC_ERROR = 15;
        #endregion CG_MEMORY_ALLOC_ERROR

        #region CG_INVALID_CONTEXT_HANDLE_ERROR
        /// <summary>
        ///     Invalid context handle.
        /// </summary>
        // CG_INVALID_CONTEXT_HANDLE_ERROR = 16
        public const int CG_INVALID_CONTEXT_HANDLE_ERROR = 16;
        #endregion CG_INVALID_CONTEXT_HANDLE_ERROR

        #region CG_INVALID_PROGRAM_HANDLE_ERROR
        /// <summary>
        ///     Invalid program handle.
        /// </summary>
        // #region CG_INVALID_PROGRAM_HANDLE_ERROR = 17
        public const int CG_INVALID_PROGRAM_HANDLE_ERROR = 17;
        #endregion CG_INVALID_PROGRAM_HANDLE_ERROR

        #region CG_INVALID_PARAM_HANDLE_ERROR
        /// <summary>
        ///     Invalid parameter handle.
        /// </summary>
        // CG_INVALID_PARAM_HANDLE_ERROR = 18
        public const int CG_INVALID_PARAM_HANDLE_ERROR = 18;
        #endregion CG_INVALID_PARAM_HANDLE_ERROR

        #region CG_UNKNOWN_PROFILE_ERROR
        /// <summary>
        ///     The specified profile is unknown.
        /// </summary>
        // CG_UNKNOWN_PROFILE_ERROR = 19
        public const int CG_UNKNOWN_PROFILE_ERROR = 19;
        #endregion CG_UNKNOWN_PROFILE_ERROR

        #region CG_VAR_ARG_ERROR
        /// <summary>
        ///     The variable arguments were specified incorrectly.
        /// </summary>
        // CG_VAR_ARG_ERROR = 20
        public const int CG_VAR_ARG_ERROR = 20;
        #endregion CG_VAR_ARG_ERROR

        #region CG_INVALID_DIMENSION_ERROR
        /// <summary>
        ///     The dimension value is invalid.
        /// </summary>
        // CG_INVALID_DIMENSION_ERROR = 21
        public const int CG_INVALID_DIMENSION_ERROR = 21;
        #endregion CG_INVALID_DIMENSION_ERROR

        #region CG_ARRAY_PARAM_ERROR
        /// <summary>
        ///     The parameter must be an array.
        /// </summary>
        // CG_ARRAY_PARAM_ERROR = 22
        public const int CG_ARRAY_PARAM_ERROR = 22;
        #endregion CG_ARRAY_PARAM_ERROR

        #region CG_OUT_OF_ARRAY_BOUNDS_ERROR
        /// <summary>
        ///     Index into the array is out of bounds.
        /// </summary>
        // CG_OUT_OF_ARRAY_BOUNDS_ERROR = 23
        public const int CG_OUT_OF_ARRAY_BOUNDS_ERROR = 23;
        #endregion CG_OUT_OF_ARRAY_BOUNDS_ERROR
        #endregion Errors

        #region Profiles
        #region CG_PROFILE_UNKNOWN
        /// <summary>
        ///     Unknown profile.
        /// </summary>
        public const int CG_PROFILE_UNKNOWN = 6145;
        #endregion CG_PROFILE_UNKNOWN

        #region OpenGL
        #region CG_PROFILE_VP20
        /// <summary>
        ///     OpenGL NV2x vertex programs.
        /// </summary>
        public const int CG_PROFILE_VP20 = 6146;
        #endregion CG_PROFILE_VP20

        #region CG_PROFILE_FP20
        /// <summary>
        ///     OpenGL NV2x fragment programs.
        /// </summary>
        public const int CG_PROFILE_FP20 = 6147;
        #endregion CG_PROFILE_FP20

        #region CG_PROFILE_VP30
        /// <summary>
        ///     OpenGL NV30 vertex programs.
        /// </summary>
        public const int CG_PROFILE_VP30 = 6148;
        #endregion CG_PROFILE_VP30

        #region CG_PROFILE_FP30
        /// <summary>
        ///     OpenGL NV30 fragment programs.
        /// </summary>
        public const int CG_PROFILE_FP30 = 6149;
        #endregion CG_PROFILE_FP30

        #region CG_PROFILE_ARBVP1
        /// <summary>
        ///     OpenGL ARB vertex programs 1.0.
        /// </summary>
        public const int CG_PROFILE_ARBVP1 = 6150;
        #endregion CG_PROFILE_ARBVP1

        #region CG_PROFILE_ARBFP1
        /// <summary>
        ///     OpenGL ARB fragment programs 1.0.
        /// </summary>
        public const int CG_PROFILE_ARBFP1 = 7000;
        #endregion CG_PROFILE_ARBFP1
        #endregion OpenGL

        #region DirectX8
        #region CG_PROFILE_VS_1_1
        /// <summary>
        ///     DirectX 8 vertex shaders.
        /// </summary>
        public const int CG_PROFILE_VS_1_1 = 6153;
        #endregion CG_PROFILE_VS_1_1           

        #region CG_PROFILE_PS_1_1
        /// <summary>
        ///     DirectX 8 pixel shaders.
        /// </summary>
        public const int CG_PROFILE_PS_1_1 = 6159;
        #endregion CG_PROFILE_PS_1_1    

        #region CG_PROFILE_PS_1_2
        /// <summary>
        ///     DirectX 8 pixel shaders.
        /// </summary>
        public const int CG_PROFILE_PS_1_2 = 6160;
        #endregion CG_PROFILE_PS_1_2    

        #region CG_PROFILE_PS_1_3
        /// <summary>
        ///     DirectX 8 pixel shaders.
        /// </summary>
        public const int CG_PROFILE_PS_1_3 = 6161;
        #endregion CG_PROFILE_PS_1_3    
        #endregion DirectX8

        #region DirectX9
        #region CG_PROFILE_VS_2_0
        /// <summary>
        ///     DirectX 9 vertex shaders.
        /// </summary>
        public const int CG_PROFILE_VS_2_0 = 6154;
        #endregion CG_PROFILE_VS_2_0

        #region CG_PROFILE_VS_2_X
        /// <summary>
        ///     DirectX 9 vertex shaders.
        /// </summary>
        public const int CG_PROFILE_VS_2_X = 6155;
        #endregion CG_PROFILE_VS_2_X

        #region CG_PROFILE_PS_2_0
        /// <summary>
        ///     DirectX 9 pixel shaders.
        /// </summary>
        public const int CG_PROFILE_PS_2_0 = 6162;
        #endregion CG_PROFILE_PS_2_0

        #region CG_PROFILE_PS_2_X
        /// <summary>
        ///     DirectX 9 pixel shaders.
        /// </summary>
        public const int CG_PROFILE_PS_2_X = 6163;
        #endregion CG_PROFILE_PS_2_X
        #endregion DirectX9
        #endregion Profiles
        #endregion Public Constants

        // --- Constructors & Destructors ---
        #region Cg()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private Cg() {
        }
        #endregion Cg()

        // --- Public Externs ---
        #region TODO
        /* Implement remaining core functions.

        // Type Functions

        CGDLL_API const char *cgGetTypeString(CGtype type);
        CGDLL_API CGtype cgGetType(const char *type_string);

        // Error Functions
        CGDLL_API void cgSetErrorCallback(CGerrorCallbackFunc func);
        CGDLL_API CGerrorCallbackFunc cgGetErrorCallback(void);
        */
        #endregion TODO

        #region Context Functions
        #region IntPtr cgCreateContext()
        /// <summary>
        ///     Creates a new Cg context to use.
        /// </summary>
        /// <returns>
        ///     A handle to the newly created Cg context.
        /// </returns>
        // CGDLL_API CGcontext cgCreateContext(void);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateContext();
        #endregion IntPtr cgCreateContext()

        #region cgDestroyContext(IntPtr context)
        /// <summary>
        ///     Destroys the specified Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle to the Cg context to destroy.
        /// </param>
        // CGDLL_API void cgDestroyContext(CGcontext ctx);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyContext(IntPtr context);
        #endregion cgDestroyContext(IntPtr context)

        #region int cgIsContext(IntPtr context)
        /// <summary>
        ///     Given the specified context handle, returns true if it is a valid Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle of the context to check.
        /// </param>
        /// <returns>
        ///     CG_TRUE if valid, CG_FALSE otherwise.
        /// </returns>
        // CGDLL_API CGbool cgIsContext(CGcontext ctx);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgIsContext(IntPtr context);
        #endregion int cgIsContext(IntPtr context)

        #region string cgGetLastListing(IntPtr context)
        /// <summary>
        ///     Gets the compiler output from the results of the most recent program compilation for the given Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle to the context to query.
        /// </param>
        /// <returns>
        ///     String representing compiler output from last program compiled.
        /// </returns>
        public static string cgGetLastListing(IntPtr context) {
            return Marshal.PtrToStringAnsi(cgGetLastListingA(context));
        }

        /// <summary>
        ///     Gets the compiler output from the results of the most recent program compilation for the given Cg context.
        /// </summary>
        /// <param name="context">
        ///     Handle to the context to query.
        /// </param>
        /// <returns>
        ///     IntPtr that must be converted to a string with Marshal.PtrToStringAnsi.
        /// </returns>
        // CGDLL_API const char *cgGetLastListing(CGcontext ctx);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="cgGetLastListing"), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetLastListingA(IntPtr context);
        #endregion string cgGetLastListing(IntPtr context)
        #endregion Context Functions

        #region Program Functions
        #region IntPtr cgCopyProgram(IntPtr program)
        /// <summary>
        ///     Makes a copy of the specified Cg program within the same context.
        /// </summary>
        /// <param name="program">
        ///     Handle to the program to copy.
        /// </param>
        /// <returns>
        ///     Handle to a new program within the same context.
        /// </returns>
        // CGDLL_API CGprogram cgCopyProgram(CGprogram program);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCopyProgram(IntPtr program);
        #endregion IntPtr cgCopyProgram(IntPtr program)

        #region IntPtr cgCreateProgram(IntPtr context, int type, string source, int profile, string entry, string[] args)
        /// <summary>
        ///     Compiles and creates a Cg program.
        /// </summary>
        /// <param name="context">
        ///     Current Cg context.
        /// </param>
        /// <param name="type">
        ///     Type of source to use.
        /// </param>
        /// <param name="source">
        ///     Source Cg code.
        /// </param>
        /// <param name="profile">
        ///     Profile to use for compiling the program.
        /// </param>
        /// <param name="entry">
        ///     Entry point of the specified Cg source.  If null, then 'main' is assumed.
        /// </param>
        /// <param name="args">
        ///     Optional args to pass to the compiler.
        /// </param>
        /// <returns>
        ///     Handle to the newly created Cg program.
        /// </returns>
        // CGDLL_API CGprogram cgCreateProgram(CGcontext ctx, CGenum program_type, const char *program, CGprofile profile, const char *entry, const char **args);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgram(IntPtr context, int type, string source, int profile, string entry, string[] args);
        #endregion IntPtr cgCreateProgram(IntPtr context, int type, string source, int profile, string entry, string[] args)

        #region IntPtr cgCreateProgramFromFile(IntPtr context, int type, string file, int profile, string entry, string[] args)
        /// <summary>
        ///     Creates a Cg program from the specified file.
        /// </summary>
        /// <param name="context">
        ///     Current Cg context.
        /// </param>
        /// <param name="type">
        ///     Type of source to use.
        /// </param>
        /// <param name="file">
        ///     Name of the file to load and compile.
        /// </param>
        /// <param name="profile">
        ///     Profile to use for compiling the program.
        /// </param>
        /// <param name="entry">
        ///     Entry point of the specified Cg source.  If null, then 'main' is assumed.
        /// </param>
        /// <param name="args">
        ///     Optional args to pass to the compiler.
        /// </param>
        /// <returns>
        ///     Handle to the newly created Cg program.
        /// </returns>
        // CGDLL_API CGprogram cgCreateProgramFromFile(CGcontext ctx, CGenum program_type, const char *program_file, CGprofile profile, const char *entry, const char **args);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgCreateProgramFromFile(IntPtr context, int type, string file, int profile, string entry, string[] args);
        #endregion IntPtr cgCreateProgramFromFile(IntPtr context, int type, string file, int profile, string entry, string[] args)

        #region void cgDestroyProgram(IntPtr program)
        /// <summary>
        ///     Destroys the specified Cg program.
        /// </summary>
        /// <param name="program">
        ///     Handle to the program to destroy.
        /// </param>
        // CGDLL_API void cgDestroyProgram(CGprogram program);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgDestroyProgram(IntPtr program);
        #endregion void cgDestroyProgram(IntPtr program)

        #region string cgGetProgramString(IntPtr program, int sourceType)

        /// <summary>
        ///     Gets the specified source from the program.
        /// </summary>
        /// <param name="program">
        ///     Handle to the Cg program.
        /// </param>
        /// <param name="sourceType">
        ///     Type of source to pull, whether original or compiled, etc.
        /// </param>
        /// <returns>
        ///     String containing the source of the specified type from the program.
        /// </returns>
        public static string cgGetProgramString(IntPtr program, int sourceType) {
            return Marshal.PtrToStringAnsi(cgGetProgramStringA(program, sourceType));
        }

        /// <summary>
        ///     Gets the specified source from the program.
        /// </summary>
        /// <param name="program">
        ///     Handle to the Cg program.
        /// </param>
        /// <param name="sourceType">
        ///     Type of source to pull, whether original or compiled, etc.
        /// </param>
        /// <returns>
        ///     IntPtr to the string data.  Must be converted using Marshal.PtrToStringAnsi.
        /// </returns>
        // CGDLL_API const char *cgGetProgramString(CGprogram prog, CGenum pname);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="cgGetProgramString", CharSet=CharSet.Auto), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetProgramStringA(IntPtr program, int sourceType);
        #endregion string cgGetProgramString(IntPtr program, int sourceType)

        #region IntPtr cgGetFirstProgram(IntPtr context)
        /// <summary>
        ///     Gets the first program in a context.
        /// </summary>
        /// <param name="context">
        ///     The context to retreive first program from.
        /// </param>
        /// <returns>
        ///     The program or null if no programs available.
        /// </returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstProgram(IntPtr context);
        #endregion IntPtr cgGetFirstProgram(IntPtr context)

        #region IntPtr cgGetNextProgram(IntPtr current)
        /// <summary>
        ///     Iterate trough programs in a context.
        /// </summary>
        /// <param name="current">
        ///     Current program.
        /// </param>
        /// <returns>
        ///     Next program in context's internal sequence of programs.
        /// </returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextProgram(IntPtr current);
        #endregion IntPtr cgGetNextProgram(IntPtr current)

        #region IntPtr cgGetProgramContext(IntPtr prog)
        /// <summary>
        ///     Gets a programs parent context.
        /// </summary>
        /// <param name="prog">
        ///     Program to retreive context from.
        /// </param>
        /// <returns>
        ///     The context a given program belongs to.
        /// </returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetProgramContext(IntPtr prog);
        #endregion IntPtr cgGetProgramContext(IntPtr prog)

        #region bool cgIsProgram(IntPtr prog)
        /// <summary>
        ///     Determine if a program handle references a Cg program object.
        /// </summary>
        /// <param name="prog">
        ///     The program handle.
        /// </param>
        /// <returns>
        ///     CG_TRUE if prog references a valid program object.
        /// </returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern bool cgIsProgram(IntPtr prog);
        #endregion bool cgIsProgram(IntPtr prog)

        #region void cgCompileProgram(IntPtr prog)
        /// <summary>
        ///     Compile a program object.
        /// </summary>
        /// <param name="prog">
        ///     The program to be compiled or inspected.
        /// </param>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgCompileProgram(IntPtr prog);
        #endregion void cgCompileProgram(IntPtr prog)

        #region int cgGetParameterType(IntPtr param)
        /// <summary>
        ///    Gets the data type of the specified parameter.
        /// </summary>
        /// <param name="param">Id of the parameter to query.</param>
        /// <returns>Enum value representing the parameter's data type.</returns>
        // CGDLL_API CGtype cgGetParameterType(CGparameter param);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterType(IntPtr param);
        #endregion cgGetParameterType(IntPtr param)
        
        #region bool cgIsProgramCompiled(IntPtr prog)
        /// <summary>
        ///     Determines if a program has been compiled.
        /// </summary>
        /// <param name="prog">
        ///     Specifies the program.
        /// </param>
        /// <returns>
        ///     CG_TRUE if specified program has been compiled.
        /// </returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern bool cgIsProgramCompiled(IntPtr prog);
        #endregion bool cgIsProgramCompiled(IntPtr prog)

        #region int cgGetProgramProfile(IntPtr prog)
        /// <summary>
        ///     Gets the profile enumeration of the program.
        /// </summary>
        /// <param name="prog">
        ///     Specifies the program.
        /// </param>
        /// <returns>
        ///     The profile enumeration or CG_PROFILE_UNKNOWN if compilation failed.
        /// </returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetProgramProfile(IntPtr prog);
        #endregion int cgGetProgramProfile(IntPtr prog)
        #endregion Program Functions

        #region Profile Functions
        #region int cgGetProfile(string profile)
        /// <summary>
        ///     Returns a profile enum value based on the string representation of the profile.
        /// </summary>
        /// <param name="profile">
        ///     Name of the profile, i.e. arbvp1, vs_1_1, etc.
        /// </param>
        /// <returns>
        ///     Enum value containing the integral representation of the profile.
        /// </returns>
        // CGDLL_API CGprofile cgGetProfile(const char *profile_string);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetProfile(string profile);
        #endregion int cgGetProfile(string profile)
        #endregion Profile Functions

        #region Parameter Functions
        #region IntPtr cgGetNamedParameter(IntPtr program, string parameter)
        /// <summary>
        /// Gets the named parameter from the program.
        /// </summary>
        /// <param name="program">
        /// The program to get parameter from.
        /// </param>
        /// <param name="parameter">
        /// The name of the parameter to return.
        /// </param>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNamedParameter(IntPtr program, string parameter);
        #endregion IntPtr cgGetNamedParameter(IntPtr program, string parameter)

        #region IntPtr cgGetFirstLeafParameter(IntPtr program, int nameSpace)
        /// <summary>
        ///    Used to get the first leaf parameter from the specified program.
        /// </summary>
        /// <remarks>
        ///    Leaf params read into params that are structs as well, eliminating the need to explictly 
        ///    determine if the param is a struct or other type.
        /// </remarks>
        /// <param name="program">
        ///    Handle to the program to query.
        /// </param>
        /// <param name="nameSpace">
        ///    Namespace in which to query for the params (usually CG_PROGRAM).
        /// </param>
        /// <returns>
        ///    Handle to the first Cg parameter in the specified program.
        /// </returns>
        // CGDLL_API CGparameter cgGetFirstLeafParameter(CGprogram prog, CGenum name_space);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstLeafParameter(IntPtr program, int nameSpace);
        #endregion IntPtr cgGetFirstLeafParameter(IntPtr program, int nameSpace)

        #region IntPtr cgGetNextLeafParameter(IntPtr currentParam)
        /// <summary>
        ///    Gets a handle to the leaf parameter directly following the specified param.
        /// </summary>
        /// <param name="currentParam">Current Cg parameter.</param>
        /// <returns>Handle to the next param after the current program, null if the current is the last param.</returns>
        // CGDLL_API CGparameter cgGetNextLeafParameter(CGparameter current);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextLeafParameter(IntPtr currentParam);
        #endregion IntPtr cgGetNextLeafParameter(IntPtr currentParam)

        #region int cgGetParameterDirection(IntPtr param)
        /// <summary>
        ///    Gets the direction of this parameter, i.e. CG_IN, CG_OUT, CG_INOUT.
        /// </summary>
        /// <param name="param">Id of the parameter to query.</param>
        /// <returns>Enum value representing the parameter's direction.</returns>
        // CGDLL_API CGenum cgGetParameterDirection(CGparameter param);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterDirection(IntPtr param);
        #endregion cgGetParameterDirection(IntPtr param)

        #region string cgGetParameterName(IntPtr param)
        /// <summary>
        ///    Gets the name of the specified program.
        /// </summary>
        /// <param name="param">Handle to the program to query.</param>
        /// <returns>The name of the specified program as a string.</returns>
        public static string cgGetParameterName(IntPtr param) {
            return Marshal.PtrToStringAnsi(cgGetParameterNameA(param));
        }

        /// <summary>
        ///    Gets the name of the specified program.
        /// </summary>
        /// <param name="param">Handle to the program to query.</param>
        /// <returns>IntPtr that must be converted to an Ansi string via Marshal.PtrToStringAnsi.</returns>
        // CGDLL_API const char *cgGetParameterName(CGparameter param);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="cgGetParameterName"), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetParameterNameA(IntPtr param);
        #endregion string cgGetParameterName(IntPtr param)

        #region int cgGetParameterResourceIndex(IntPtr param)
        /// <summary>
        ///    Retrieves the index of the specifed parameter according to its type and variability.
        /// </summary>
        /// <remarks>
        ///    For example, if the resource for a given parameter is CG_TEXCOORD7,
        ///    cgGetParameterResourceIndex() returns 7.  Also, for uniform params, it equates
        ///    to the constant index that will be used in the resulting program.
        /// </remarks>
        /// <param name="param">
        ///    Handle of the param to query.
        /// </param>
        /// <returns>
        ///    Index of the specified parameter according to its type and variability.
        /// </returns>
        // CGDLL_API unsigned long cgGetParameterResourceIndex(CGparameter param);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterResourceIndex(IntPtr param);
        #endregion int cgGetParameterResourceIndex(IntPtr param)

        #region int cgGetParameterVariability(IntPtr param)
        /// <summary>
        ///    Gets the variability of the specified param (i.e, uniform, varying, etc).
        /// </summary>
        /// <param name="param">Handle of the program to query.</param>
        /// <returns>Enum stating the variability of the program.</returns>
        // CGDLL_API CGenum cgGetParameterVariability(CGparameter param);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterVariability(IntPtr param);
        #endregion cgGetParameterVariability(IntPtr param)

        #region int cgIsParameterReferenced(IntPtr param)
        /// <summary>
        ///    Queries whether the specified program will be used in the final compiled program.
        /// </summary>
        /// <remarks>
        ///    The compiler may ignore parameters that are not actually used within the program.
        /// </remarks>
        /// <param name="param">Handle to the Cg parameter.</param>
        /// <returns>True if the param is being used, false if not.</returns>
        // CGDLL_API CGbool cgIsParameterReferenced(CGparameter param);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgIsParameterReferenced(IntPtr param);
        #endregion int cgIsParameterReferenced(IntPtr param)

        #region int cgGetParameterResource(IntPtr param)
        /// <summary>
        /// Gets a parameter's resource.
        /// </summary>
        /// <param name="param">Parameter to retreive resource from</param>
        /// <returns>Resource of a given parameter.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterResource(IntPtr param);
        #endregion int cgGetParameterResource(IntPtr param)

        #region int cgGetParameterBaseResource(IntPtr param)
        /// <summary>
        /// Gets a parameter's base resource.
        /// </summary>
        /// <param name="param">Parameter to retreive base resource from</param>
        /// <returns>Base resource of a given parameter.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterBaseResource(IntPtr param);
        #endregion int cgGetParameterBaseResource(IntPtr param)

        #region IntPtr cgGetFirstParameter(IntPtr prog, int name_space)
        /// <summary>
        /// Gets the first parameter in specified program.
        /// </summary>
        /// <param name="prog">The program to retreive the first program from.</param>
        /// <param name="name_space">Namespace of the parameter to iterate through.</param>
        /// <returns>First parameter in specified program.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstParameter(IntPtr prog, int name_space);
        #endregion IntPtr cgGetFirstParameter(IntPtr prog, int name_space)

        #region IntPtr cgGetNextParameter(IntPtr currentParam)
        /// <summary>
        /// Iterates to next parameter in program.
        /// </summary>
        /// <param name="currentParam">The current parameter.</param>
        /// <returns>The next parameter in the program's internal sequence of parameters.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetNextParameter(IntPtr currentParam);
        #endregion IntPtr cgGetNextParameter(IntPtr currentParam)

        #region IntPtr cgGetFirstStructParameter(IntPtr param)
        /// <summary>
        /// Gets the first child parameter in a struct parameter.
        /// </summary>
        /// <param name="param">The struct parameter to get child parameter from.</param>
        /// <returns>First child parameter in specified struct parameter.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetFirstStructParameter(IntPtr param);
        #endregion IntPtr cgGetFirstStructParameter(IntPtr param)

        #region IntPtr cgGetArrayParameter(IntPtr aparam, int index)
        /// <summary>
        /// Gets the parameter from an array.
        /// </summary>
        /// <param name="aparam">Array parameter.</param>
        /// <param name="index">Index into the array.</param>
        /// <returns>Parameter of array param specified by the index.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetArrayParameter(IntPtr aparam, int index);
        #endregion IntPtr cgGetArrayParameter(IntPtr aparam, int index)

        #region int cgGetArrayDimension(IntPtr param)
        /// <summary>
        /// Gets the dimension of an array parameter.
        /// </summary>
        /// <param name="param">Parameter.</param>
        /// <returns>Dimension of the specified parameter.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArrayDimension(IntPtr param);
        #endregion int cgGetArrayDimension(IntPtr param)

        #region int cgGetArraySize(IntPtr param, int dimension)
        /// <summary>
        /// Gets the size of an array.
        /// </summary>
        /// <param name="param">Parameter.</param>
        /// <param name="dimension">The dimension whose size will be returned.</param>
        /// <returns>Size of specified parameters dimension.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetArraySize(IntPtr param, int dimension);
        #endregion int cgGetArraySize(IntPtr param, int dimension)

        #region IntPtr cgGetParameterProgram(IntPtr param)
        /// <summary>
        /// Gets program that specified parameter belongs to.
        /// </summary>
        /// <param name="param">Parameter to retreive it's parent program.</param>
        /// <returns>A program given parameter belongs to.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterProgram(IntPtr param);
        #endregion IntPtr cgGetParameterProgram(IntPtr param)

        #region bool cgIsParameter(IntPtr param)
        /// <summary>
        /// Determines if parameter is valid Cg parameter object.
        /// </summary>
        /// <param name="param">Parameter.</param>
        /// <returns>CG_TRUE ig parameter is valid Cg parameter object.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern bool cgIsParameter(IntPtr param);
        #endregion bool cgIsParameter(IntPtr param)

        #region string cgGetParameterSemantic(IntPtr param)
        /// <summary>
        /// Gets the parameter's semantic string.
        /// </summary>
        /// <param name="param">Parameter to get semantic from.</param>
        /// <returns>Parameter's semantic string.</returns>
        public static string cgGetParameterSemantic(IntPtr param) {
            return Marshal.PtrToStringAnsi(cgGetParameterSemanticA(param));
        }

        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="cgGetErrorString"), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetParameterSemanticA(IntPtr param);
        #endregion string cgGetParameterSemantic(IntPtr param)

        #region double[] cgGetParameterValues(IntPtr param, int value_type, int[] nvalues)
        #region double[] cgGetParameterValues(IntPtr param, int value_type, int[] nvalues)
        /// <summary>
        /// Gets a program parameter's values. 
        /// </summary>
        /// <param name="param">Parameter to retreive parameter's values from.</param>
        /// <param name="value_type">CG_CONSTANT or CG?DEFAULT</param>
        /// <param name="nvalues">Array of integers indicating the number of values in parameters.</param>
        /// <returns>Array of double values.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern double[] cgGetParameterValues(IntPtr param, int value_type, int[] nvalues);
        #endregion double[] cgGetParameterValues(IntPtr param, int value_type, int[] nvalues)

        #region double* cgGetParameterValues(IntPtr param, int value_type, int* nvalues)
        /// <summary>
        /// Gets a program parameter's values. 
        /// </summary>
        /// <param name="param">Parameter to retreive parameter's values from.</param>
        /// <param name="value_type">CG_CONSTANT or CG?DEFAULT</param>
        /// <param name="nvalues">Array of integers indicating the number of values in parameters.</param>
        /// <returns>Array of double values.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern double* cgGetParameterValues(IntPtr param, int value_type, int* nvalues);
        #endregion double* cgGetParameterValues(IntPtr param, int value_type, int* nvalues)

        #region IntPtr cgGetParameterValues(IntPtr param, int value_type, IntPtr nvalues)
        /// <summary>
        /// Gets a program parameter's values. 
        /// </summary>
        /// <param name="param">Parameter to retreive parameter's values from.</param>
        /// <param name="value_type">CG_CONSTANT or CG?DEFAULT</param>
        /// <param name="nvalues">Array of integers indicating the number of values in parameters.</param>
        /// <returns>Array of double values.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr cgGetParameterValues(IntPtr param, int value_type, IntPtr nvalues);
        #endregion IntPtr cgGetParameterValues(IntPtr param, int value_type, IntPtr nvalues)
        #endregion double[] cgGetParameterValues(IntPtr param, int value_type, int[] nvalues)

        #region int cgGetParameterOrdinalNumber(IntPtr param)
        /// <summary>
        /// Returns an integer that represents the position of a parameter when it was declared within the Cg program.
        /// </summary>
        /// <param name="param">Parameter to retreive it's ordinal number.</param>
        /// <returns>Parameter's ordinal number.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetParameterOrdinalNumber(IntPtr param);
        #endregion int cgGetParameterOrdinalNumber(IntPtr param)
        #endregion Parameter Functions

        #region Resource Functions

        #region string cgGetResourceString(int resource)
        /// <summary>
        /// get the resource name associated with a resource enumerant 
        /// </summary>
        /// <param name="resource">Resource ID to get name from.</param>
        /// <returns>Resource's name.</returns>
        public static string cgGetResourceString(int resource) {
            return Marshal.PtrToStringAnsi(cgGetResourceStringA(resource));
        }

        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="cgGetErrorString"), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetResourceStringA(int resource);
        #endregion string cgGetResourceString(int resource)

        #region int cgGetResource(string resource_name)
        /// <summary>
        /// Gets the resource enumerant assigned to a resource name.
        /// </summary>
        /// <param name="resource_name">Resource's name.</param>
        /// <returns>Resource enumerant.</returns>
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetResource(string resource_name);
        #endregion int cgGetResource(string resource_name)


        #endregion

        #region Error Functions

        #region int cgGetError()
        /// <summary>
        ///    Returns an error enum if an error has occured in the last Cg method call.
        /// </summary>
        /// <returns>Error enum.</returns>
        //CGDLL_API CGerror cgGetError(void);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGetError();
        #endregion int cgGetError()

        #region string cgGetErrorString(int error)

        /// <summary>
        ///    Returns an error description from the specified error enum value.
        /// </summary>
        /// <param name="error">Error enum value.</param>
        /// <returns>String description of the specified error enum value.</returns>
        public static string cgGetErrorString(int error) {
            return Marshal.PtrToStringAnsi(cgGetErrorStringA(error));
        }

        /// <summary>
        ///    Returns an error description from the specified error enum value.
        /// </summary>
        /// <param name="error">Error enum value.</param>
        /// <returns>IntPtr that must be converted to Ansi string via Marshal.PtrToStringAnsi.</returns>
        //CGDLL_API const char *cgGetErrorString(CGerror error);
        [DllImport("cg.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="cgGetErrorString"), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr cgGetErrorStringA(int error);
        #endregion string cgGetErrorString(int error)

        #endregion Error Functions
    }
}
