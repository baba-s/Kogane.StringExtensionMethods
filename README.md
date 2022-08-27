# Kogane String Extension Methods

string 型の拡張メソッド

## 使用例

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        var str   = string.Empty;
        var texts = new[] { "フシギダネ", "フシギソウ", "フシギバナ" };

        // string.Format の拡張メソッド版
        Debug.Log( str.FormatWith( 25, "ピカチュウ" ) );

        // string.Join の拡張メソッド版
        Debug.Log( texts.ConcatWith( "\n" ) );

        // \n で string.Join する拡張メソッド
        Debug.Log( texts.ConcatWithNewLine() );

        // null もしくは空文字列なら true
        if ( str.IsNullOrEmpty() )
        {
        }

        // null でも空文字列でもないなら true 
        if ( str.IsNotNullOrEmpty() )
        {
        }

        // null もしくは空文字列もしくは空白文字のみなら true
        if ( str.IsNullOrWhiteSpace() )
        {
        }

        // null でも空文字列でも空白文字のみでもないなら true
        if ( str.IsNotNullOrWhiteSpace() )
        {
        }

        // 文字列が null もしくは空文字列なら既定値を取得
        Debug.Log( str.DefaultIfEmpty() );
        Debug.Log( str.DefaultIfEmpty( "ピカチュウ" ) );

        // null もしくは空文字列もしくは空白文字のみなら既定値を取得
        Debug.Log( str.DefaultIfWhiteSpace() );
        Debug.Log( str.DefaultIfWhiteSpace( "ピカチュウ" ) );

        // 指定された区切り文字で分割して取得
        // デフォルトの Split では文字列を渡すことができないが
        // この Split 拡張メソッドでは文字列を渡すことができる
        var list = str.Split( "\n" );

        // 指定された長さに制限した文字列を取得
        Debug.Log( str.Limit( 5 ) );

        // 指定された長さに制限した文字列を取得
        // 文字列の末尾に指定した文字列を追加
        Debug.Log( str.Limit( 5, "..." ) );

        // 指定された文字列を削除
        Debug.Log( str.ReplaceEmpty( "ピカチュウ" ) );

        // スネークケースの文字列をキャメルケースに変換
        Debug.Log( str.SnakeToUpperCamel() ); // quoted_printable_encode → QuotedPrintableEncode
        Debug.Log( str.SnakeToLowerCamel() ); // quoted_printable_encode → quotedPrintableEncode

        // Windows 形式のファイルパスに変換
        Debug.Log( str.ToWindowsPath() ); // temp/doc.txt → temp\\doc.txt

        // Mac 形式のファイルパスに変換
        Debug.Log( str.ToMacPath() ); // temp\\doc.txt → temp/doc.txt

        // 指定された回数分繰り返し連結した文字列を取得
        Debug.Log( str.Repeat( 5 ) );

        // 指定したいずれかの文字列が部分一致する場合 true
        Debug.Log( str.ContainsAny( "ピカチュウ", "カイリュー" ) );

        // 文字列の末尾に拡張子を追加
        // 既に拡張子が追加されている場合は何もしない
        Debug.Log( str.SafeAddExtension( ".exe" ) );

        // 改行コード（\r、\n）を削除
        Debug.Log( str.RemoveNewLine() );

        // Unicode から Shift-JIS に変換
        Debug.Log( str.ToShiftJis() );

        // 指定した文字列が見つかった場合、最後に見つかった部分を削除した文字列を取得
        Debug.Log( str.RemoveAtLast( "ピカチュウ" ) );

        // すべての文字が小文字なら true
        Debug.Log( str.IsLower() );

        // すべての文字が大文字なら true
        Debug.Log( str.IsUpper() );
    }
}
```
