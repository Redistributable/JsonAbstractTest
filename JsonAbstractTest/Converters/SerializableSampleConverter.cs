using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using JsonAbstractTest.Models;

namespace JsonAbstractTest.Converters
{
    using self = SerializableSampleConverter;


    /// <summary>
    /// <see cref="ISerializableSample"/> に付与されるインターフェイスです。
    /// </summary>
    public class SerializableSampleConverter : JsonConverter
    {
        // 非公開フィールド


        // 非公開静的フィールド
        private static List<Type> _supportedTypes;


        // 公開プロパティ

        /// <summary>
        /// このコンバーターが JSON の読み取りに対応しているかどうかを示す真偽値を取得します。
        /// </summary>
        public override bool CanRead
        {
            get => true;
        }

        /// <summary>
        /// このコンバーターが JSON の書き込みに対応しているかどうかを示す真偽値を取得します。
        /// </summary>
        public override bool CanWrite
        {
            get => false;
        }


        // コンストラクタ

        /// <summary>
        /// 新しい <see cref="SerializableSampleConverter"/> クラスのインスタンスを初期化します。
        /// </summary>
        public SerializableSampleConverter()
        {
            // 実装なし
        }


        // 静的コンストラクタ

        /// <summary>
        /// <see cref="SerializableSampleConverter"/> クラスを初期化します。
        /// </summary>
        static SerializableSampleConverter()
        {
            self._supportedTypes = new List<Type>();
        }


        // 非公開静的メソッド

        /// <summary>
        /// <see cref="ISerializableSample"/> との型の互換性を確認します。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool _checkCompatibility(Type type)
        {
            return typeof(ISerializableSample).IsAssignableFrom(type);
        }

        /// <summary>
        /// _supportedTypes 内で <paramref name="typeName"/> と同じ名前を持つ型を検索します。
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private static Type _getSupportedType(string typeName)
        {
            return self._supportedTypes.Where(item => item.Name == typeName).Single();
        }


        // 公開メソッド

        /// <summary>
        /// このコンバーターが、指定した <see cref="Type"/> の示す型に対応しているかどうかを判断します。
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return self._checkCompatibility(objectType);
        }

        /// <summary>
        /// JSON を読み込んでインスタンスを生成します。
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // 型名の読み込み
            var token = JToken.ReadFrom(reader);
            var typeName = token.Value<string>(nameof(ISerializableSample.TypeName));

            // 型名から Type を取得
            var type = self._getSupportedType(typeName);

            // 具体型を指定して読み込む
            return token.ToObject(type);
        }

        /// <summary>
        /// 指定されたインスタンスを JSON へ変換し、書き込みます。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // serializer.Serialize を使用すると、このメソッドが内部で呼び出されるため、スタックオーバーフローしてしまう
            //serializer.Serialize(writer, value);

            // CanWrite を false にしているため、実装不要。
            throw new NotImplementedException();
        }


        // 公開静的メソッド

        /// <summary>
        /// デシリアライズ後の具体型として利用可能な型を登録します。
        /// </summary>
        /// <param name="type"><see cref="ISerializableSample"/> と互換性のある型</param>
        /// <exception cref="InvalidOperationException"><see cref="ISerializableSample"/> と互換性の無い方が指定されています。</exception>
        public static void RegistSupportType(Type type)
        {
            if (!self._checkCompatibility(type))
                throw new InvalidOperationException($"{nameof(ISerializableSample)} クラスと互換性の無い型が指定されています。");

            self._supportedTypes.Add(type);
        }
    }
}
