using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using JsonAbstractTest.Models;

namespace JsonAbstractTest
{
    /// <summary>
    /// メイン エントリ ポイントを定義します。
    /// </summary>
    public static class MainClass
    {
        // 非公開静的メソッド

        /// <summary>
        /// 指定した <see cref="SerializableParent"/> クラスのインスタンスをシリアライズします。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private static string _serializeTest(SerializableParent target)
        {
            // インデントが為された JSON データを作成
            return JsonConvert.SerializeObject(target, Formatting.Indented);
        }

        /// <summary>
        /// 指定した文字列をデシリアライズし、<see cref="SerializableParent"/> クラスのインスタンスを取得します。
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static SerializableParent _deserializeTest(string json)
        {
            return JsonConvert.DeserializeObject<SerializableParent>(json);
        }

        /// <summary>
        /// 標準出力へ複数行のテキストに行番号を添えて出力します。
        /// </summary>
        /// <param name="text"></param>
        private static void _outputText(string text)
        {
            var lines = text.Replace("\r\n", "\n").Split('\n');
            foreach (var l in lines.Select((str, idx) => new { index = idx++, str = str }))
                Console.WriteLine("{0:000} | {1}", l.index, l.str);
        }


        // 公開静的メソッド

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(string[] args)
        {
            // サンプルインスタンスの定義
            var example01 = new SerializableParent()
            {
                // 型が string で固定されているプロパティ
                ConcreteValue = "This property's type is concrete!",
                
                // 型がインターフェイスのため、デシリアライズの際に具体的な型がわからないプロパティ
#if true
                AbstractValue = new SerializableModelFoo()
                {
                    FooContent = $"This object is {nameof(SerializableModelFoo)}.",
                    FooIntegerValue = 2018,
                },
#else
                AbstractValue = new SerializableModelBar()
                {
                    BarContent = $"This object is {nameof(SerializableModelBar)}.",
                },
#endif
            };


            // シリアライズ
            var json = _serializeTest(example01);
            _outputText(json);


            // デシリアライズ
            var obj = _deserializeTest(json);


            Console.WriteLine("Completed!!");
        }
    }
}
