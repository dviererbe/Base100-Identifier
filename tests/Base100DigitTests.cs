using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using System.Globalization;
using System.Threading;

namespace Base100Identifier.UnitTests
{
    public class Base100DigitTests
    {
        #region Test Data

        private static CultureInfo CultureInfo_en_US => new CultureInfo("en-US");
        private static CultureInfo CultureInfo_de_DE => new CultureInfo("de-DE");
        private static CultureInfo CultureInfo_fr_FR => new CultureInfo("fr-FR");
        private static CultureInfo CultureInfo_es_ES => new CultureInfo("es-ES");

        private static object[] AsObjectArray<TSource>(TSource value) => new object[] { value };
        private static byte FirstItemAsByte(object[] array) => (byte)array[0];

        //I am aware of the existence of for loops ;) The explicit declaration is intended.
        public static IEnumerable<object[]> AllValidBase100DigitByteValues =>
            new byte[]
                {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26,
                    27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51,
                    52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
                    77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99
                }
                .Select(AsObjectArray);

        //I am aware of the existence of for loops ;) The explicit declaration is intended.
        public static IEnumerable<object[]> AllInvalidBase100DigitByteValues =>
            new byte[]
                {
                    100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119,
                    120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139,
                    140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159,
                    160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179,
                    180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199,
                    200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
                    220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239,
                    240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255
                }
                .Select(AsObjectArray);

        public static IEnumerable<object[]> AllBase100DigitValues =>
            AllValidBase100DigitByteValues
                .Select(FirstItemAsByte)
                .Select(value => new Base100Digit(value))
                .Select(AsObjectArray);

        public static IEnumerable<object[]> Base100DigitToStringRepresentationsUsingCultureInfo => new []
        {
            //             Digit                 CultureInfo        ExpectedOutput
            new object[] { new Base100Digit(00), CultureInfo_en_US, "00"           },
            new object[] { new Base100Digit(01), CultureInfo_en_US, "01"           },
            new object[] { new Base100Digit(02), CultureInfo_en_US, "02"           },
            new object[] { new Base100Digit(03), CultureInfo_en_US, "03"           },
            new object[] { new Base100Digit(04), CultureInfo_en_US, "04"           },
            new object[] { new Base100Digit(05), CultureInfo_en_US, "05"           },
            new object[] { new Base100Digit(06), CultureInfo_en_US, "06"           },
            new object[] { new Base100Digit(07), CultureInfo_en_US, "07"           },
            new object[] { new Base100Digit(08), CultureInfo_en_US, "08"           },
            new object[] { new Base100Digit(09), CultureInfo_en_US, "09"           },
            new object[] { new Base100Digit(10), CultureInfo_en_US, "10"           },
            new object[] { new Base100Digit(16), CultureInfo_en_US, "16"           },
            new object[] { new Base100Digit(42), CultureInfo_en_US, "42"           },
            new object[] { new Base100Digit(80), CultureInfo_en_US, "80"           },
            new object[] { new Base100Digit(99), CultureInfo_en_US, "99"           },
            
            //             Digit                 CultureInfo        ExpectedOutput
            new object[] { new Base100Digit(00), CultureInfo_de_DE, "00"           },
            new object[] { new Base100Digit(01), CultureInfo_de_DE, "01"           },
            new object[] { new Base100Digit(02), CultureInfo_de_DE, "02"           },
            new object[] { new Base100Digit(03), CultureInfo_de_DE, "03"           },
            new object[] { new Base100Digit(04), CultureInfo_de_DE, "04"           },
            new object[] { new Base100Digit(05), CultureInfo_de_DE, "05"           },
            new object[] { new Base100Digit(06), CultureInfo_de_DE, "06"           },
            new object[] { new Base100Digit(07), CultureInfo_de_DE, "07"           },
            new object[] { new Base100Digit(08), CultureInfo_de_DE, "08"           },
            new object[] { new Base100Digit(09), CultureInfo_de_DE, "09"           },
            new object[] { new Base100Digit(10), CultureInfo_de_DE, "10"           },
            new object[] { new Base100Digit(16), CultureInfo_de_DE, "16"           },
            new object[] { new Base100Digit(42), CultureInfo_de_DE, "42"           },
            new object[] { new Base100Digit(80), CultureInfo_de_DE, "80"           },
            new object[] { new Base100Digit(99), CultureInfo_de_DE, "99"           },
            
            //             Digit                 CultureInfo        ExpectedOutput
            new object[] { new Base100Digit(00), CultureInfo_fr_FR, "00"           },
            new object[] { new Base100Digit(01), CultureInfo_fr_FR, "01"           },
            new object[] { new Base100Digit(02), CultureInfo_fr_FR, "02"           },
            new object[] { new Base100Digit(03), CultureInfo_fr_FR, "03"           },
            new object[] { new Base100Digit(04), CultureInfo_fr_FR, "04"           },
            new object[] { new Base100Digit(05), CultureInfo_fr_FR, "05"           },
            new object[] { new Base100Digit(06), CultureInfo_fr_FR, "06"           },
            new object[] { new Base100Digit(07), CultureInfo_fr_FR, "07"           },
            new object[] { new Base100Digit(08), CultureInfo_fr_FR, "08"           },
            new object[] { new Base100Digit(09), CultureInfo_fr_FR, "09"           },
            new object[] { new Base100Digit(10), CultureInfo_fr_FR, "10"           },
            new object[] { new Base100Digit(16), CultureInfo_fr_FR, "16"           },
            new object[] { new Base100Digit(42), CultureInfo_fr_FR, "42"           },
            new object[] { new Base100Digit(80), CultureInfo_fr_FR, "80"           },
            new object[] { new Base100Digit(99), CultureInfo_fr_FR, "99"           },
            
            //             Digit                 CultureInfo        ExpectedOutput
            new object[] { new Base100Digit(00), CultureInfo_es_ES, "00"           },
            new object[] { new Base100Digit(01), CultureInfo_es_ES, "01"           },
            new object[] { new Base100Digit(02), CultureInfo_es_ES, "02"           },
            new object[] { new Base100Digit(03), CultureInfo_es_ES, "03"           },
            new object[] { new Base100Digit(04), CultureInfo_es_ES, "04"           },
            new object[] { new Base100Digit(05), CultureInfo_es_ES, "05"           },
            new object[] { new Base100Digit(06), CultureInfo_es_ES, "06"           },
            new object[] { new Base100Digit(07), CultureInfo_es_ES, "07"           },
            new object[] { new Base100Digit(08), CultureInfo_es_ES, "08"           },
            new object[] { new Base100Digit(09), CultureInfo_es_ES, "09"           },
            new object[] { new Base100Digit(10), CultureInfo_es_ES, "10"           },
            new object[] { new Base100Digit(16), CultureInfo_es_ES, "16"           },
            new object[] { new Base100Digit(42), CultureInfo_es_ES, "42"           },
            new object[] { new Base100Digit(80), CultureInfo_es_ES, "80"           },
            new object[] { new Base100Digit(99), CultureInfo_es_ES, "99"           },
        };
        
        public static IEnumerable<object?[]> Base100DigitToStringRepresentationsUsingFormatAndCultureInfo => new []
        {
            //              Digit                 Format      CultureInfo        ExpectedOutput
            new object?[] { new Base100Digit(00), null      , CultureInfo_en_US, "00"           },
            new object?[] { new Base100Digit(01), null      , CultureInfo_en_US, "01"           },
            new object?[] { new Base100Digit(02), null      , CultureInfo_en_US, "02"           },
            new object?[] { new Base100Digit(03), null      , CultureInfo_en_US, "03"           },
            new object?[] { new Base100Digit(04), null      , CultureInfo_en_US, "04"           },
            new object?[] { new Base100Digit(05), null      , CultureInfo_en_US, "05"           },
            new object?[] { new Base100Digit(06), null      , CultureInfo_en_US, "06"           },
            new object?[] { new Base100Digit(07), null      , CultureInfo_en_US, "07"           },
            new object?[] { new Base100Digit(08), null      , CultureInfo_en_US, "08"           },
            new object?[] { new Base100Digit(09), null      , CultureInfo_en_US, "09"           },
            new object?[] { new Base100Digit(10), null      , CultureInfo_en_US, "10"           },
            new object?[] { new Base100Digit(16), null      , CultureInfo_en_US, "16"           },
            new object?[] { new Base100Digit(42), null      , CultureInfo_en_US, "42"           },
            new object?[] { new Base100Digit(80), null      , CultureInfo_en_US, "80"           },
            new object?[] { new Base100Digit(99), null      , CultureInfo_en_US, "99"           },
            new object?[] { new Base100Digit(00), ""        , CultureInfo_en_US, "00"           },
            new object?[] { new Base100Digit(01), ""        , CultureInfo_en_US, "01"           },
            new object?[] { new Base100Digit(02), ""        , CultureInfo_en_US, "02"           },
            new object?[] { new Base100Digit(03), ""        , CultureInfo_en_US, "03"           },
            new object?[] { new Base100Digit(04), ""        , CultureInfo_en_US, "04"           },
            new object?[] { new Base100Digit(05), ""        , CultureInfo_en_US, "05"           },
            new object?[] { new Base100Digit(06), ""        , CultureInfo_en_US, "06"           },
            new object?[] { new Base100Digit(07), ""        , CultureInfo_en_US, "07"           },
            new object?[] { new Base100Digit(08), ""        , CultureInfo_en_US, "08"           },
            new object?[] { new Base100Digit(09), ""        , CultureInfo_en_US, "09"           },
            new object?[] { new Base100Digit(10), ""        , CultureInfo_en_US, "10"           },
            new object?[] { new Base100Digit(16), ""        , CultureInfo_en_US, "16"           },
            new object?[] { new Base100Digit(42), ""        , CultureInfo_en_US, "42"           },
            new object?[] { new Base100Digit(80), ""        , CultureInfo_en_US, "80"           },
            new object?[] { new Base100Digit(99), ""        , CultureInfo_en_US, "99"           },
            new object?[] { new Base100Digit(00), "00"      , CultureInfo_en_US, "00"           },
            new object?[] { new Base100Digit(01), "00"      , CultureInfo_en_US, "01"           },
            new object?[] { new Base100Digit(02), "00"      , CultureInfo_en_US, "02"           },
            new object?[] { new Base100Digit(03), "00"      , CultureInfo_en_US, "03"           },
            new object?[] { new Base100Digit(04), "00"      , CultureInfo_en_US, "04"           },
            new object?[] { new Base100Digit(05), "00"      , CultureInfo_en_US, "05"           },
            new object?[] { new Base100Digit(06), "00"      , CultureInfo_en_US, "06"           },
            new object?[] { new Base100Digit(07), "00"      , CultureInfo_en_US, "07"           },
            new object?[] { new Base100Digit(08), "00"      , CultureInfo_en_US, "08"           },
            new object?[] { new Base100Digit(09), "00"      , CultureInfo_en_US, "09"           },
            new object?[] { new Base100Digit(10), "00"      , CultureInfo_en_US, "10"           },
            new object?[] { new Base100Digit(16), "00"      , CultureInfo_en_US, "16"           },
            new object?[] { new Base100Digit(42), "00"      , CultureInfo_en_US, "42"           },
            new object?[] { new Base100Digit(80), "00"      , CultureInfo_en_US, "80"           },
            new object?[] { new Base100Digit(99), "00"      , CultureInfo_en_US, "99"           },
            new object?[] { new Base100Digit(00), "0"       , CultureInfo_en_US, "0"            },
            new object?[] { new Base100Digit(01), "0"       , CultureInfo_en_US, "1"            },
            new object?[] { new Base100Digit(02), "0"       , CultureInfo_en_US, "2"            },
            new object?[] { new Base100Digit(03), "0"       , CultureInfo_en_US, "3"            },
            new object?[] { new Base100Digit(04), "0"       , CultureInfo_en_US, "4"            },
            new object?[] { new Base100Digit(05), "0"       , CultureInfo_en_US, "5"            },
            new object?[] { new Base100Digit(06), "0"       , CultureInfo_en_US, "6"            },
            new object?[] { new Base100Digit(07), "0"       , CultureInfo_en_US, "7"            },
            new object?[] { new Base100Digit(08), "0"       , CultureInfo_en_US, "8"            },
            new object?[] { new Base100Digit(09), "0"       , CultureInfo_en_US, "9"            },
            new object?[] { new Base100Digit(10), "0"       , CultureInfo_en_US, "10"           },
            new object?[] { new Base100Digit(16), "0"       , CultureInfo_en_US, "16"           },
            new object?[] { new Base100Digit(42), "0"       , CultureInfo_en_US, "42"           },
            new object?[] { new Base100Digit(80), "0"       , CultureInfo_en_US, "80"           },
            new object?[] { new Base100Digit(99), "0"       , CultureInfo_en_US, "99"           },
            
            //              Digit                 Format      CultureInfo        ExpectedOutput
            new object?[] { new Base100Digit(00), null      , CultureInfo_de_DE, "00"           },
            new object?[] { new Base100Digit(01), null      , CultureInfo_de_DE, "01"           },
            new object?[] { new Base100Digit(02), null      , CultureInfo_de_DE, "02"           },
            new object?[] { new Base100Digit(03), null      , CultureInfo_de_DE, "03"           },
            new object?[] { new Base100Digit(04), null      , CultureInfo_de_DE, "04"           },
            new object?[] { new Base100Digit(05), null      , CultureInfo_de_DE, "05"           },
            new object?[] { new Base100Digit(06), null      , CultureInfo_de_DE, "06"           },
            new object?[] { new Base100Digit(07), null      , CultureInfo_de_DE, "07"           },
            new object?[] { new Base100Digit(08), null      , CultureInfo_de_DE, "08"           },
            new object?[] { new Base100Digit(09), null      , CultureInfo_de_DE, "09"           },
            new object?[] { new Base100Digit(10), null      , CultureInfo_de_DE, "10"           },
            new object?[] { new Base100Digit(16), null      , CultureInfo_de_DE, "16"           },
            new object?[] { new Base100Digit(42), null      , CultureInfo_de_DE, "42"           },
            new object?[] { new Base100Digit(80), null      , CultureInfo_de_DE, "80"           },
            new object?[] { new Base100Digit(99), null      , CultureInfo_de_DE, "99"           },
            new object?[] { new Base100Digit(00), ""        , CultureInfo_de_DE, "00"           },
            new object?[] { new Base100Digit(01), ""        , CultureInfo_de_DE, "01"           },
            new object?[] { new Base100Digit(02), ""        , CultureInfo_de_DE, "02"           },
            new object?[] { new Base100Digit(03), ""        , CultureInfo_de_DE, "03"           },
            new object?[] { new Base100Digit(04), ""        , CultureInfo_de_DE, "04"           },
            new object?[] { new Base100Digit(05), ""        , CultureInfo_de_DE, "05"           },
            new object?[] { new Base100Digit(06), ""        , CultureInfo_de_DE, "06"           },
            new object?[] { new Base100Digit(07), ""        , CultureInfo_de_DE, "07"           },
            new object?[] { new Base100Digit(08), ""        , CultureInfo_de_DE, "08"           },
            new object?[] { new Base100Digit(09), ""        , CultureInfo_de_DE, "09"           },
            new object?[] { new Base100Digit(10), ""        , CultureInfo_de_DE, "10"           },
            new object?[] { new Base100Digit(16), ""        , CultureInfo_de_DE, "16"           },
            new object?[] { new Base100Digit(42), ""        , CultureInfo_de_DE, "42"           },
            new object?[] { new Base100Digit(80), ""        , CultureInfo_de_DE, "80"           },
            new object?[] { new Base100Digit(99), ""        , CultureInfo_de_DE, "99"           },
            new object?[] { new Base100Digit(00), "00"      , CultureInfo_de_DE, "00"           },
            new object?[] { new Base100Digit(01), "00"      , CultureInfo_de_DE, "01"           },
            new object?[] { new Base100Digit(02), "00"      , CultureInfo_de_DE, "02"           },
            new object?[] { new Base100Digit(03), "00"      , CultureInfo_de_DE, "03"           },
            new object?[] { new Base100Digit(04), "00"      , CultureInfo_de_DE, "04"           },
            new object?[] { new Base100Digit(05), "00"      , CultureInfo_de_DE, "05"           },
            new object?[] { new Base100Digit(06), "00"      , CultureInfo_de_DE, "06"           },
            new object?[] { new Base100Digit(07), "00"      , CultureInfo_de_DE, "07"           },
            new object?[] { new Base100Digit(08), "00"      , CultureInfo_de_DE, "08"           },
            new object?[] { new Base100Digit(09), "00"      , CultureInfo_de_DE, "09"           },
            new object?[] { new Base100Digit(10), "00"      , CultureInfo_de_DE, "10"           },
            new object?[] { new Base100Digit(16), "00"      , CultureInfo_de_DE, "16"           },
            new object?[] { new Base100Digit(42), "00"      , CultureInfo_de_DE, "42"           },
            new object?[] { new Base100Digit(80), "00"      , CultureInfo_de_DE, "80"           },
            new object?[] { new Base100Digit(99), "00"      , CultureInfo_de_DE, "99"           },
            new object?[] { new Base100Digit(00), "0"       , CultureInfo_de_DE, "0"            },
            new object?[] { new Base100Digit(01), "0"       , CultureInfo_de_DE, "1"            },
            new object?[] { new Base100Digit(02), "0"       , CultureInfo_de_DE, "2"            },
            new object?[] { new Base100Digit(03), "0"       , CultureInfo_de_DE, "3"            },
            new object?[] { new Base100Digit(04), "0"       , CultureInfo_de_DE, "4"            },
            new object?[] { new Base100Digit(05), "0"       , CultureInfo_de_DE, "5"            },
            new object?[] { new Base100Digit(06), "0"       , CultureInfo_de_DE, "6"            },
            new object?[] { new Base100Digit(07), "0"       , CultureInfo_de_DE, "7"            },
            new object?[] { new Base100Digit(08), "0"       , CultureInfo_de_DE, "8"            },
            new object?[] { new Base100Digit(09), "0"       , CultureInfo_de_DE, "9"            },
            new object?[] { new Base100Digit(10), "0"       , CultureInfo_de_DE, "10"           },
            new object?[] { new Base100Digit(16), "0"       , CultureInfo_de_DE, "16"           },
            new object?[] { new Base100Digit(42), "0"       , CultureInfo_de_DE, "42"           },
            new object?[] { new Base100Digit(80), "0"       , CultureInfo_de_DE, "80"           },
            new object?[] { new Base100Digit(99), "0"       , CultureInfo_de_DE, "99"           },
            
            //              Digit                 Format      CultureInfo        ExpectedOutput
            new object?[] { new Base100Digit(00), null      , CultureInfo_fr_FR, "00"           },
            new object?[] { new Base100Digit(01), null      , CultureInfo_fr_FR, "01"           },
            new object?[] { new Base100Digit(02), null      , CultureInfo_fr_FR, "02"           },
            new object?[] { new Base100Digit(03), null      , CultureInfo_fr_FR, "03"           },
            new object?[] { new Base100Digit(04), null      , CultureInfo_fr_FR, "04"           },
            new object?[] { new Base100Digit(05), null      , CultureInfo_fr_FR, "05"           },
            new object?[] { new Base100Digit(06), null      , CultureInfo_fr_FR, "06"           },
            new object?[] { new Base100Digit(07), null      , CultureInfo_fr_FR, "07"           },
            new object?[] { new Base100Digit(08), null      , CultureInfo_fr_FR, "08"           },
            new object?[] { new Base100Digit(09), null      , CultureInfo_fr_FR, "09"           },
            new object?[] { new Base100Digit(10), null      , CultureInfo_fr_FR, "10"           },
            new object?[] { new Base100Digit(16), null      , CultureInfo_fr_FR, "16"           },
            new object?[] { new Base100Digit(42), null      , CultureInfo_fr_FR, "42"           },
            new object?[] { new Base100Digit(80), null      , CultureInfo_fr_FR, "80"           },
            new object?[] { new Base100Digit(99), null      , CultureInfo_fr_FR, "99"           },
            new object?[] { new Base100Digit(00), ""        , CultureInfo_fr_FR, "00"           },
            new object?[] { new Base100Digit(01), ""        , CultureInfo_fr_FR, "01"           },
            new object?[] { new Base100Digit(02), ""        , CultureInfo_fr_FR, "02"           },
            new object?[] { new Base100Digit(03), ""        , CultureInfo_fr_FR, "03"           },
            new object?[] { new Base100Digit(04), ""        , CultureInfo_fr_FR, "04"           },
            new object?[] { new Base100Digit(05), ""        , CultureInfo_fr_FR, "05"           },
            new object?[] { new Base100Digit(06), ""        , CultureInfo_fr_FR, "06"           },
            new object?[] { new Base100Digit(07), ""        , CultureInfo_fr_FR, "07"           },
            new object?[] { new Base100Digit(08), ""        , CultureInfo_fr_FR, "08"           },
            new object?[] { new Base100Digit(09), ""        , CultureInfo_fr_FR, "09"           },
            new object?[] { new Base100Digit(10), ""        , CultureInfo_fr_FR, "10"           },
            new object?[] { new Base100Digit(16), ""        , CultureInfo_fr_FR, "16"           },
            new object?[] { new Base100Digit(42), ""        , CultureInfo_fr_FR, "42"           },
            new object?[] { new Base100Digit(80), ""        , CultureInfo_fr_FR, "80"           },
            new object?[] { new Base100Digit(99), ""        , CultureInfo_fr_FR, "99"           },
            new object?[] { new Base100Digit(00), "00"      , CultureInfo_fr_FR, "00"           },
            new object?[] { new Base100Digit(01), "00"      , CultureInfo_fr_FR, "01"           },
            new object?[] { new Base100Digit(02), "00"      , CultureInfo_fr_FR, "02"           },
            new object?[] { new Base100Digit(03), "00"      , CultureInfo_fr_FR, "03"           },
            new object?[] { new Base100Digit(04), "00"      , CultureInfo_fr_FR, "04"           },
            new object?[] { new Base100Digit(05), "00"      , CultureInfo_fr_FR, "05"           },
            new object?[] { new Base100Digit(06), "00"      , CultureInfo_fr_FR, "06"           },
            new object?[] { new Base100Digit(07), "00"      , CultureInfo_fr_FR, "07"           },
            new object?[] { new Base100Digit(08), "00"      , CultureInfo_fr_FR, "08"           },
            new object?[] { new Base100Digit(09), "00"      , CultureInfo_fr_FR, "09"           },
            new object?[] { new Base100Digit(10), "00"      , CultureInfo_fr_FR, "10"           },
            new object?[] { new Base100Digit(16), "00"      , CultureInfo_fr_FR, "16"           },
            new object?[] { new Base100Digit(42), "00"      , CultureInfo_fr_FR, "42"           },
            new object?[] { new Base100Digit(80), "00"      , CultureInfo_fr_FR, "80"           },
            new object?[] { new Base100Digit(99), "00"      , CultureInfo_fr_FR, "99"           },
            new object?[] { new Base100Digit(00), "0"       , CultureInfo_fr_FR, "0"            },
            new object?[] { new Base100Digit(01), "0"       , CultureInfo_fr_FR, "1"            },
            new object?[] { new Base100Digit(02), "0"       , CultureInfo_fr_FR, "2"            },
            new object?[] { new Base100Digit(03), "0"       , CultureInfo_fr_FR, "3"            },
            new object?[] { new Base100Digit(04), "0"       , CultureInfo_fr_FR, "4"            },
            new object?[] { new Base100Digit(05), "0"       , CultureInfo_fr_FR, "5"            },
            new object?[] { new Base100Digit(06), "0"       , CultureInfo_fr_FR, "6"            },
            new object?[] { new Base100Digit(07), "0"       , CultureInfo_fr_FR, "7"            },
            new object?[] { new Base100Digit(08), "0"       , CultureInfo_fr_FR, "8"            },
            new object?[] { new Base100Digit(09), "0"       , CultureInfo_fr_FR, "9"            },
            new object?[] { new Base100Digit(10), "0"       , CultureInfo_fr_FR, "10"           },
            new object?[] { new Base100Digit(16), "0"       , CultureInfo_fr_FR, "16"           },
            new object?[] { new Base100Digit(42), "0"       , CultureInfo_fr_FR, "42"           },
            new object?[] { new Base100Digit(80), "0"       , CultureInfo_fr_FR, "80"           },
            new object?[] { new Base100Digit(99), "0"       , CultureInfo_fr_FR, "99"           },
            
            //              Digit                 Format      CultureInfo        ExpectedOutput
            new object?[] { new Base100Digit(00), null      , CultureInfo_es_ES, "00"           },
            new object?[] { new Base100Digit(01), null      , CultureInfo_es_ES, "01"           },
            new object?[] { new Base100Digit(02), null      , CultureInfo_es_ES, "02"           },
            new object?[] { new Base100Digit(03), null      , CultureInfo_es_ES, "03"           },
            new object?[] { new Base100Digit(04), null      , CultureInfo_es_ES, "04"           },
            new object?[] { new Base100Digit(05), null      , CultureInfo_es_ES, "05"           },
            new object?[] { new Base100Digit(06), null      , CultureInfo_es_ES, "06"           },
            new object?[] { new Base100Digit(07), null      , CultureInfo_es_ES, "07"           },
            new object?[] { new Base100Digit(08), null      , CultureInfo_es_ES, "08"           },
            new object?[] { new Base100Digit(09), null      , CultureInfo_es_ES, "09"           },
            new object?[] { new Base100Digit(10), null      , CultureInfo_es_ES, "10"           },
            new object?[] { new Base100Digit(16), null      , CultureInfo_es_ES, "16"           },
            new object?[] { new Base100Digit(42), null      , CultureInfo_es_ES, "42"           },
            new object?[] { new Base100Digit(80), null      , CultureInfo_es_ES, "80"           },
            new object?[] { new Base100Digit(99), null      , CultureInfo_es_ES, "99"           },
            new object?[] { new Base100Digit(00), ""        , CultureInfo_es_ES, "00"           },
            new object?[] { new Base100Digit(01), ""        , CultureInfo_es_ES, "01"           },
            new object?[] { new Base100Digit(02), ""        , CultureInfo_es_ES, "02"           },
            new object?[] { new Base100Digit(03), ""        , CultureInfo_es_ES, "03"           },
            new object?[] { new Base100Digit(04), ""        , CultureInfo_es_ES, "04"           },
            new object?[] { new Base100Digit(05), ""        , CultureInfo_es_ES, "05"           },
            new object?[] { new Base100Digit(06), ""        , CultureInfo_es_ES, "06"           },
            new object?[] { new Base100Digit(07), ""        , CultureInfo_es_ES, "07"           },
            new object?[] { new Base100Digit(08), ""        , CultureInfo_es_ES, "08"           },
            new object?[] { new Base100Digit(09), ""        , CultureInfo_es_ES, "09"           },
            new object?[] { new Base100Digit(10), ""        , CultureInfo_es_ES, "10"           },
            new object?[] { new Base100Digit(16), ""        , CultureInfo_es_ES, "16"           },
            new object?[] { new Base100Digit(42), ""        , CultureInfo_es_ES, "42"           },
            new object?[] { new Base100Digit(80), ""        , CultureInfo_es_ES, "80"           },
            new object?[] { new Base100Digit(99), ""        , CultureInfo_es_ES, "99"           },
            new object?[] { new Base100Digit(00), "00"      , CultureInfo_es_ES, "00"           },
            new object?[] { new Base100Digit(01), "00"      , CultureInfo_es_ES, "01"           },
            new object?[] { new Base100Digit(02), "00"      , CultureInfo_es_ES, "02"           },
            new object?[] { new Base100Digit(03), "00"      , CultureInfo_es_ES, "03"           },
            new object?[] { new Base100Digit(04), "00"      , CultureInfo_es_ES, "04"           },
            new object?[] { new Base100Digit(05), "00"      , CultureInfo_es_ES, "05"           },
            new object?[] { new Base100Digit(06), "00"      , CultureInfo_es_ES, "06"           },
            new object?[] { new Base100Digit(07), "00"      , CultureInfo_es_ES, "07"           },
            new object?[] { new Base100Digit(08), "00"      , CultureInfo_es_ES, "08"           },
            new object?[] { new Base100Digit(09), "00"      , CultureInfo_es_ES, "09"           },
            new object?[] { new Base100Digit(10), "00"      , CultureInfo_es_ES, "10"           },
            new object?[] { new Base100Digit(16), "00"      , CultureInfo_es_ES, "16"           },
            new object?[] { new Base100Digit(42), "00"      , CultureInfo_es_ES, "42"           },
            new object?[] { new Base100Digit(80), "00"      , CultureInfo_es_ES, "80"           },
            new object?[] { new Base100Digit(99), "00"      , CultureInfo_es_ES, "99"           },
            new object?[] { new Base100Digit(00), "0"       , CultureInfo_es_ES, "0"            },
            new object?[] { new Base100Digit(01), "0"       , CultureInfo_es_ES, "1"            },
            new object?[] { new Base100Digit(02), "0"       , CultureInfo_es_ES, "2"            },
            new object?[] { new Base100Digit(03), "0"       , CultureInfo_es_ES, "3"            },
            new object?[] { new Base100Digit(04), "0"       , CultureInfo_es_ES, "4"            },
            new object?[] { new Base100Digit(05), "0"       , CultureInfo_es_ES, "5"            },
            new object?[] { new Base100Digit(06), "0"       , CultureInfo_es_ES, "6"            },
            new object?[] { new Base100Digit(07), "0"       , CultureInfo_es_ES, "7"            },
            new object?[] { new Base100Digit(08), "0"       , CultureInfo_es_ES, "8"            },
            new object?[] { new Base100Digit(09), "0"       , CultureInfo_es_ES, "9"            },
            new object?[] { new Base100Digit(10), "0"       , CultureInfo_es_ES, "10"           },
            new object?[] { new Base100Digit(16), "0"       , CultureInfo_es_ES, "16"           },
            new object?[] { new Base100Digit(42), "0"       , CultureInfo_es_ES, "42"           },
            new object?[] { new Base100Digit(80), "0"       , CultureInfo_es_ES, "80"           },
            new object?[] { new Base100Digit(99), "0"       , CultureInfo_es_ES, "99"           },
        };

        public static IEnumerable<object?[]> Base100DigitWithInvalidFormatAndCultureInfo => new[]
        {
            //              Digit                 Invalid Format   CultureInfo        
            new object?[] { new Base100Digit(00), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(01), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(02), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(03), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(04), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(05), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(06), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(07), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(08), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(09), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(10), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(16), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(42), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(80), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(99), "r"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(00), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(01), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(02), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(03), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(04), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(05), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(06), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(07), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(08), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(09), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(10), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(16), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(42), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(80), "R"            , CultureInfo_en_US },
            new object?[] { new Base100Digit(99), "R"            , CultureInfo_en_US },
            
            //              Digit                 Invalid Format   CultureInfo
            new object?[] { new Base100Digit(00), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(01), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(02), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(03), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(04), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(05), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(06), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(07), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(08), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(09), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(10), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(16), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(42), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(80), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(99), "r"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(00), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(01), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(02), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(03), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(04), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(05), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(06), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(07), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(08), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(09), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(10), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(16), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(42), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(80), "R"            , CultureInfo_de_DE },
            new object?[] { new Base100Digit(99), "R"            , CultureInfo_de_DE },
            
            //              Digit                 Invalid Format   CultureInfo
            new object?[] { new Base100Digit(00), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(01), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(02), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(03), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(04), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(05), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(06), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(07), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(08), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(09), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(10), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(16), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(42), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(80), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(99), "r"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(00), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(01), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(02), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(03), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(04), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(05), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(06), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(07), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(08), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(09), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(10), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(16), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(42), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(80), "R"            , CultureInfo_fr_FR },
            new object?[] { new Base100Digit(99), "R"            , CultureInfo_fr_FR },
            
            //              Digit                 Invalid Format   CultureInfo
            new object?[] { new Base100Digit(00), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(01), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(02), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(03), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(04), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(05), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(06), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(07), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(08), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(09), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(10), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(16), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(42), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(80), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(99), "r"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(00), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(01), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(02), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(03), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(04), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(05), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(06), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(07), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(08), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(09), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(10), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(16), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(42), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(80), "R"            , CultureInfo_es_ES },
            new object?[] { new Base100Digit(99), "R"            , CultureInfo_es_ES },
        };
        
        #endregion

        public Base100DigitTests()
        {
            //set default culture
            CultureInfo.CurrentCulture = CultureInfo_en_US;
            Thread.CurrentThread.CurrentCulture = CultureInfo_en_US;
        }
        
        [Fact(DisplayName = "Base100Digit.MinValue.Value SHOULD equal 0")]
        public void MinValue_Should_Equal0()
        {
            //Arrange
            const byte expectedValue = 0;
            
            //Act
            byte actualValue = Base100Digit.MinValue.Value;
            
            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact(DisplayName = "Base100Digit.MaxValue.Value SHOULD equal 99")]
        public void MaxValue_Should_Equal99()
        {
            //Arrange
            const byte expectedValue = 99;
            
            //Act
            byte actualValue = Base100Digit.MaxValue.Value;
            
            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact(DisplayName = "default(Base100Digit) SHOULD equal 0")]
        public void DefaultBase100Digit_Should_Equal_0()
        {
            //Arrange
            const byte expectedValue = 0;
            
            //Act
            Base100Digit defaultDigit = default;
            byte actualValue = defaultDigit.Value;
            
            //Assert
            Assert.Equal(expectedValue, actualValue);
        }
        
        [Fact(DisplayName = "new Base100Digit().Value SHOULD equal 0")]
        public void ParameterlessNewBase100Digit_Should_Equal_0()
        {
            //Arrange
            const byte expectedValue = 0;
            
            //Act
            Base100Digit defaultDigit = new();
            byte actualValue = defaultDigit.Value;
            
            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory(DisplayName = "Value Property SHOULD equal the initialization value")]
        [MemberData(nameof(AllValidBase100DigitByteValues))]
        public void Value_Should_EqualInitializationValue(in byte value)
        {
            //Arrange
            Base100Digit digit = new Base100Digit(value);
            
            //Act
            byte actualValue = digit.Value;
            
            //Assert
            Assert.Equal(expected: value, actualValue);
        }

        [Theory(DisplayName = "Constructor SHOULD throw an ArgumentOutOfRangeException when initialization value is larger than 99")]
        [MemberData(nameof(AllInvalidBase100DigitByteValues))]
        public void Constructor_Should_ThrowArgumentOutOfRangeException_When_ValueIsLargerThan99(byte value)
        {
            //Arrange
            void TestCode()
            {
                Base100Digit digit = new Base100Digit(value);
            }
            
            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Theory(DisplayName = "GetHashCode() SHOULD return the the value it was initialized with")]
        [MemberData(nameof(AllValidBase100DigitByteValues))]
        public void GetHashCode_Should_ReturnInitializationValue(in byte value)
        {
            //Arrange
            int expectedValue = value;
            Base100Digit digit = new Base100Digit(value);
            
            //Act
            int actualValue = digit.GetHashCode();
            
            //Assert
            Assert.Equal(expectedValue, actualValue);
        }
        
        [Theory(DisplayName = "GetHashCode() and the Value property SHOULD equal")]
        [MemberData(nameof(AllValidBase100DigitByteValues))]
        public void GetHashCode_Should_EqualValueProperty(in byte initialValue)
        {
            //Arrange:
            Base100Digit digit = new Base100Digit(initialValue);
            
            //Act:
            byte value = digit.Value;
            int hashCode = digit.GetHashCode();

            //Assert:
            Assert.Equal(expected: initialValue, actual: value);
            Assert.Equal(expected: initialValue, actual: hashCode);
            //  therefore:  value == hashCode
        }

        #region ToString Tests
        
        [Theory(DisplayName = "ToString() SHOULD return the expected representation")]
        [MemberData(nameof(Base100DigitToStringRepresentationsUsingCultureInfo))]
        public void ToString_Should_ReturnExpectedStringRepresentation(
            Base100Digit digit, 
            CultureInfo cultureInfo,
            string expectedStringRepresentation)
        {
            //Arrange:
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            
            //Act:
            string actualStringRepresentation = digit.ToString();
            
            //Assert:
            Assert.Equal(expectedStringRepresentation, actualStringRepresentation);
        }

        [Theory(DisplayName = "ToString() SHOULD return the expected representation WHEN a format string is provided")]
        [MemberData(nameof(Base100DigitToStringRepresentationsUsingFormatAndCultureInfo))]
        public void ToString_Should_ReturnExpectedStringRepresentation_When_SpecificFormatIsProvided(
            Base100Digit digit, 
            string? format,
            CultureInfo cultureInfo,
            string expectedStringRepresentation)
        {
            //Arrange:
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            
            //Act
            string actualStringRepresentation = digit.ToString(format);
            
            //Assert
            Assert.Equal(expectedStringRepresentation, actualStringRepresentation);
        }
        
        [Theory(DisplayName = "ToString() SHOULD return the expected representation WHEN a format string and null as format provider is provided")]
        [MemberData(nameof(Base100DigitToStringRepresentationsUsingFormatAndCultureInfo))]
        public void ToString_Should_ReturnExpectedStringRepresentation_When_SpecificFormatAndNullFormatProviderIsProvided(
            Base100Digit digit, 
            string? format,
            CultureInfo cultureInfo,
            string expectedStringRepresentation)
        {
            //Arrange:
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            
            //Act
            string actualStringRepresentation = digit.ToString(format, formatProvider: null);
            
            //Assert
            Assert.Equal(expectedStringRepresentation, actualStringRepresentation);
        }

        [Theory(DisplayName = "ToString() SHOULD return the expected representation WHEN a format provider is provided")]
        [MemberData(nameof(Base100DigitToStringRepresentationsUsingCultureInfo))]
        public void ToString_Should_ReturnExpectedStringRepresentation_When_SpecificFormatProviderIsProvided(
            Base100Digit digit, 
            CultureInfo cultureInfo, 
            string expectedStringRepresentation)
        {
            //Arrange: (nothing to do here)

            //Act:
            string actualStringRepresentation = digit.ToString(formatProvider: cultureInfo);
            
            //Assert:
            Assert.Equal(expectedStringRepresentation, actualStringRepresentation);
        }

        [Theory(DisplayName = "ToString() SHOULD return the expected representation WHEN a format string and a format provider is provided")]
        [MemberData(nameof(Base100DigitToStringRepresentationsUsingFormatAndCultureInfo))]
        public void ToString_Should_ReturnExpectedStringRepresentation_When_SpecificFormatAndFormatProviderIsProvided(
            Base100Digit digit, 
            string? format, 
            CultureInfo cultureInfo, 
            string expectedStringRepresentation)
        {
            //Arrange: (nothing to do here)

            //Act: 
            string actualStringRepresentation = digit.ToString(format, formatProvider: cultureInfo);
            
            //Assert:
            Assert.Equal(expectedStringRepresentation, actualStringRepresentation);
        }

        [Theory(DisplayName = "ToString() SHOULD throw an FormatException WHEN an invalid format string is provided")]
        [MemberData(nameof(Base100DigitWithInvalidFormatAndCultureInfo))]
        public void ToString_Should_ThrowFormatException_When_InvalidFormatIsProvided(
            Base100Digit digit, 
            string invalidFormat,
            CultureInfo cultureInfo)
        {
            //Arrange:
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            void TestCode()
            {
                string stringRepresentation = digit.ToString(invalidFormat); 
            }

            //Act && Assert: 
            Assert.Throws<FormatException>(TestCode);
        }
        
        [Theory(DisplayName = "ToString() SHOULD throw an FormatException WHEN an invalid format string and an format provider is provided")]
        [MemberData(nameof(Base100DigitWithInvalidFormatAndCultureInfo))]
        public void ToString_Should_ThrowFormatException_When_InvalidFormatAndCultureInfoIsProvided(
            Base100Digit digit,
            string invalidFormat,
            CultureInfo cultureInfo)
        {
            //Arrange:
            void TestCode()
            {
                string stringRepresentation = digit.ToString(invalidFormat, formatProvider: cultureInfo);
            }
            
            //Act && Assert: 
            Assert.Throws<FormatException>(TestCode);
        }
        
        #endregion
    }
}