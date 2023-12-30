using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kogane
{
    /// <summary>
    /// string 型の拡張メソッドを管理するクラス
    /// </summary>
    public static class StringExtensionMethods
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// 指定した文字列の書式項目を指定した配列内の対応するオブジェクトの文字列形式に置換します
        /// </summary>
        public static string FormatWith( this string format, object arg0 )
        {
            return string.Format( format, arg0 );
        }

        /// <summary>
        /// 指定した文字列の書式項目を指定した配列内の対応するオブジェクトの文字列形式に置換します
        /// </summary>
        public static string FormatWith
        (
            this string format,
            object      arg0,
            object      arg1
        )
        {
            return string.Format( format, arg0, arg1 );
        }

        /// <summary>
        /// 指定した文字列の書式項目を指定した配列内の対応するオブジェクトの文字列形式に置換します
        /// </summary>
        public static string FormatWith
        (
            this string format,
            object      arg0,
            object      arg1,
            object      arg2
        )
        {
            return string.Format( format, arg0, arg1, arg2 );
        }

        /// <summary>
        /// 指定した文字列の書式項目を指定した配列内の対応するオブジェクトの文字列形式に置換します
        /// </summary>
        public static string FormatWith( this string format, params object[] args )
        {
            return string.Format( format, args );
        }

        /// <summary>
        /// コレクションを空文字で連結して返します
        /// </summary>
        public static string ConcatWith<T>( this IEnumerable<T> self )
        {
            return string.Join( "", self );
        }

        /// <summary>
        /// コレクションを指定した文字で連結して返します
        /// </summary>
        public static string ConcatWith<T>( this IEnumerable<T> self, string separator )
        {
            return string.Join( separator, self );
        }

        /// <summary>
        /// コレクションを改行文字で連結して返します
        /// </summary>
        public static string ConcatWithNewLine<T>( this IEnumerable<T> self )
        {
            return self.ConcatWith( "\n" );
        }

        /// <summary>
        /// コレクションを `,` で連結して返します
        /// </summary>
        public static string ConcatWithComma<T>( this IEnumerable<T> self )
        {
            return self.ConcatWith( "," );
        }

        /// <summary>
        /// 指定された文字列が null または Empty 文字列であるかどうかを示します
        /// </summary>
        public static bool IsNullOrEmpty( this string value )
        {
            return string.IsNullOrEmpty( value );
        }

        /// <summary>
        /// 指定された文字列が null または空であるか、空白文字だけで構成されているかどうかを返します
        /// </summary>
        public static bool IsNullOrWhiteSpace( this string value )
        {
            return value == null || value.Trim() == "";
        }

        /// <summary>
        /// 指定された文字列が null ではない、 Empty 文字列ではないかどうかを示します
        /// </summary>
        public static bool IsNotNullOrEmpty( this string self )
        {
            return !self.IsNullOrEmpty();
        }

        /// <summary>
        /// 指定された文字列が null ではない、空ではない、空白文字だけで構成されていないかどうかを返します
        /// </summary>
        public static bool IsNotNullOrWhiteSpace( this string self )
        {
            return !self.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// 文字列が空の場合は string.Empty を返します
        /// </summary>
        public static string DefaultIfEmpty( this string self )
        {
            return string.IsNullOrEmpty( self ) ? string.Empty : self;
        }

        /// <summary>
        /// 文字列が空の場合は defaultValue を返します
        /// </summary>
        public static string DefaultIfEmpty( this string self, string defaultValue )
        {
            return string.IsNullOrEmpty( self ) ? defaultValue : self;
        }

        /// <summary>
        /// 文字列が空もしくは空白文字だけで構成されている場合は string.Empty を返します
        /// </summary>
        public static string DefaultIfWhiteSpace( this string self )
        {
            return IsNullOrWhiteSpace( self ) ? string.Empty : self;
        }

        /// <summary>
        /// 文字列が空もしくは空白文字だけで構成されている場合は defaultValue を返します
        /// </summary>
        public static string DefaultIfWhiteSpace( this string self, string defaultValue )
        {
            return IsNullOrWhiteSpace( self ) ? defaultValue : self;
        }

        /// <summary>
        /// 文字列を指定された長さに制限して返します
        /// </summary>
        public static string Limit( this string self, int maxLength )
        {
            return self.Limit( maxLength, string.Empty );
        }

        /// <summary>
        /// 文字列を指定された長さに制限して返します
        /// </summary>
        public static string Limit
        (
            this string self,
            int         maxLength,
            string      suffix
        )
        {
            if ( self.Length <= maxLength ) return self;
            return string.Concat( self.Substring( 0, maxLength ).Trim(), suffix ?? string.Empty );
        }

        /// <summary>
        /// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
        /// </summary>
        public static string[] Split( this string self, char separator )
        {
            return self.Split( new[] { separator }, StringSplitOptions.None );
        }

        /// <summary>
        /// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
        /// </summary>
        public static string[] Split
        (
            this string        self,
            char               separator,
            StringSplitOptions options
        )
        {
            return self.Split( new[] { separator }, options );
        }

        /// <summary>
        /// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
        /// </summary>
        public static string[] Split( this string self, string separator )
        {
            return self.Split( new[] { separator }, StringSplitOptions.None );
        }

        /// <summary>
        /// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
        /// </summary>
        public static string[] Split
        (
            this string        self,
            string             separator,
            StringSplitOptions options
        )
        {
            return self.Split( new[] { separator }, options );
        }

        /// <summary>
        /// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
        /// </summary>
        public static string[] Split( this string self, params string[] separator )
        {
            return self.Split( separator, StringSplitOptions.None );
        }

        /// <summary>
        /// <para>指定した文字列をすべて空文字列に置換した新しい文字列を返します</para>
        /// <para>"ABCABC".ReplaceEmpty("B") → ACAC</para>
        /// </summary>
        public static string ReplaceEmpty( this string self, string oldValue )
        {
            return self.Replace( oldValue, string.Empty );
        }

        /// <summary>
        /// <para>スネークケースをアッパーキャメル(パスカル)ケースに変換します</para>
        /// <para>例) quoted_printable_encode → QuotedPrintableEncode</para>
        /// </summary>
        public static string SnakeToUpperCamel( this string self )
        {
            if ( string.IsNullOrEmpty( self ) ) return self;

            return self
                    .Split( new[] { '_' }, StringSplitOptions.RemoveEmptyEntries )
                    .Select( s => char.ToUpperInvariant( s[ 0 ] ) + s.Substring( 1, s.Length - 1 ) )
                    .Aggregate( string.Empty, ( s1, s2 ) => s1 + s2 )
                ;
        }

        /// <summary>
        /// <para>スネークケースをローワーキャメル(パスカル)ケースに変換します</para>
        /// <para>例) quoted_printable_encode → quotedPrintableEncode</para>
        /// </summary>
        public static string SnakeToLowerCamel( this string self )
        {
            if ( string.IsNullOrEmpty( self ) ) return self;

            return self
                    .SnakeToUpperCamel()
                    .Insert( 0, char.ToLowerInvariant( self[ 0 ] ).ToString() )
                    .Remove( 1, 1 )
                ;
        }

        /// <summary>
        /// <para>Windows 形式のファイルパスに変換します</para>
        /// <para>例) temp/doc.txt → temp\\doc.txt</para>
        /// </summary>
        public static string ToWindowsPath( this string self )
        {
            return self.Replace( "/", "\\" );
        }

        /// <summary>
        /// <para>Mac 形式のファイルパスに変換します</para>
        /// <para>例) temp\\doc.txt → temp/doc.txt</para>
        /// </summary>
        public static string ToMacPath( this string self )
        {
            return self.Replace( "\\", "/" );
        }

        /// <summary>
        /// 指定された文字列を指定された回数分繰り返し連結した文字列を生成して返します
        /// </summary>
        public static string Repeat( this string self, int repeatCount )
        {
            var builder = new StringBuilder();
            for ( var i = 0; i < repeatCount; i++ )
            {
                builder.Append( self );
            }

            return builder.ToString();
        }

        /// <summary>
        /// <para>指定されたいずれかの文字列を含むかどうかを返します</para>
        /// <para>var str = "ピカチュウカイリュー";</para>
        /// <para>Debug.Log( str.ContainsAny( "ピカチュウ", "カイリュー" ) ); // True</para>
        /// <para>Debug.Log( str.ContainsAny( "カイリュー", "ヤドラン" ) ); // True</para>
        /// <para>Debug.Log( str.ContainsAny( "ヤドラン", "ピジョン" ) ); // False</para>
        /// </summary>
        public static bool ContainsAny( this string self, params string[] list )
        {
            return list.Any( x => self.Contains( x ) );
        }

        /// <summary>
        /// <para>指定された文字列に拡張子を追加して返します</para>
        /// <para>既に拡張子が設定されている場合は何もしません</para>
        /// </summary>
        public static string SafeAddExtension( this string self, string extension )
        {
            return self.EndsWith( extension ) ? self : self + extension;
        }

        /// <summary>
        /// 改行コードを削除した文字列を返します
        /// </summary>
        public static string RemoveNewLine( this string self )
        {
            return self
                    .ReplaceEmpty( "\n" )
                    .ReplaceEmpty( "\r" )
                ;
        }

        /// <summary>
        /// <para>Unicode 文字列から Shift-JIS 文字列に変換して返します</para>
        /// <para>http://blog.livedoor.jp/pandora200x/archives/50087762.html</para>
        /// </summary>
        public static string ToShiftJis( this string unicodeStrings )
        {
#if UNITY_EDITOR
            var unicode       = Encoding.Unicode;
            var unicodeBytes  = unicode.GetBytes( unicodeStrings );
            var shiftJis      = Encoding.GetEncoding( "shift_jis" );
            var shiftJisBytes = Encoding.Convert( unicode, shiftJis, unicodeBytes );
            var shiftJisChars = new char[ shiftJis.GetCharCount( shiftJisBytes, 0, shiftJisBytes.Length ) ];

            shiftJis.GetChars
            (
                bytes: shiftJisBytes,
                byteIndex: 0,
                byteCount: shiftJisBytes.Length,
                chars: shiftJisChars,
                charIndex: 0
            );

            return new( shiftJisChars );
#else
			return unicodeStrings;
#endif
        }

        /// <summary>
        /// 入力文字列内に含まれるエスケープされた文字を変換して返します
        /// </summary>
        public static string Unescape( this string self )
        {
            return Regex.Unescape( self );
        }

        /// <summary>
        /// 文字 (\、*、+、?、|、{、[、(、)、^、$、.、#、および空白) をエスケープコードに置き換えることにより、このような文字をエスケープして返します
        /// </summary>
        public static string Escape( this string self )
        {
            return Regex.Escape( self );
        }

        /// <summary>
        /// <para>指定された文字列がこのインスタンス内で最後に見つかった場合、</para>
        /// <para>その文字列を削除した新しい文字列を返します</para>
        /// </summary>
        public static string RemoveAtLast( this string self, string value )
        {
            return self.Remove( self.LastIndexOf( value ), value.Length );
        }

        /// <summary>
        /// 文字列がすべて小文字の場合 true を返します
        /// </summary>
        public static bool IsLower( this string self )
        {
            for ( var i = 0; i < self.Length; i++ )
            {
                if ( char.IsUpper( self[ i ] ) )
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 文字列がすべて大文字の場合 true を返します
        /// </summary>
        public static bool IsUpper( this string self )
        {
            for ( var i = 0; i < self.Length; i++ )
            {
                if ( char.IsLower( self[ i ] ) )
                {
                    return false;
                }
            }

            return true;
        }

        public static string ReplaceFirst
        (
            this string self,
            string      oldValue,
            string      newValue
        )
        {
            var startIndex = self.IndexOf( oldValue );

            if ( startIndex == -1 ) return self;

            return self
                    .Remove( startIndex, oldValue.Length )
                    .Insert( startIndex, newValue )
                ;
        }

        public static string ReplaceFirst
        (
            this string      self,
            string           oldValue,
            string           newValue,
            StringComparison comparisonType
        )
        {
            var startIndex = self.IndexOf( oldValue, comparisonType );

            if ( startIndex == -1 ) return self;

            return self
                    .Remove( startIndex, oldValue.Length )
                    .Insert( startIndex, newValue )
                ;
        }

        public static string ReplaceIf
        (
            this string self,
            bool        conditional,
            string      oldValue,
            string      newValue
        )
        {
            return conditional ? self.Replace( oldValue, newValue ) : self;
        }

        public static string ReplaceIf
        (
            this string      self,
            bool             conditional,
            string           oldValue,
            string           newValue,
            StringComparison comparisonType
        )
        {
            return conditional ? self.Replace( oldValue, newValue, comparisonType ) : self;
        }

        public static string GetIfNotNullOrWhiteSpace( this string self, string defaultValue )
        {
            return self.IsNotNullOrWhiteSpace() ? self : defaultValue;
        }

        public static bool StartsWith
        (
            this string           self,
            IReadOnlyList<string> values
        )
        {
            for ( var i = 0; i < values.Count; i++ )
            {
                var value = values[ i ];
                if ( self.StartsWith( value ) )
                {
                    return true;
                }
            }

            return false;
        }

        public static bool StartsWith
        (
            this string           self,
            IReadOnlyList<string> values,
            StringComparison      comparisonType
        )
        {
            for ( var i = 0; i < values.Count; i++ )
            {
                var value = values[ i ];
                if ( self.StartsWith( value, comparisonType ) )
                {
                    return true;
                }
            }

            return false;
        }

        public static string[] SplitByOneCharacter( this string self )
        {
            return self.Select( x => x.ToString() ).ToArray();
        }

        public static string[] SubstringAtCount( this string self, int count )
        {
            var result = new List<string>();
            var length = ( int )Math.Ceiling( ( double )self.Length / count );

            for ( var i = 0; i < length; i++ )
            {
                var start = count * i;
                if ( self.Length <= start )
                {
                    break;
                }

                result.Add
                (
                    self.Length < start + count
                        ? self.Substring( start )
                        : self.Substring( start, count )
                );
            }

            return result.ToArray();
        }
    }
}