using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace JsonAbstractTest.Converters
{
    /// <summary>
    /// <typeparamref name="TTarget"/> 型であることが確定しているJSONデータに対するコンバータを提供します．
    /// </summary>
    /// <typeparam name="TTarget">デシリアライズ時の具体型</typeparam>
    /// <typeparam name="TAbstractConverter">抽象型での <see cref="JsonConverter"/> 互換クラス</typeparam>
    public class ConcretedTypeConverter<TTarget, TAbstractConverter> : JsonConverter where TAbstractConverter : JsonConverter, new()
    {
        // 非公開フィールド
        private Type _targetType;
        private JsonConverter _abstractTypeConverter;


        // 公開プロパティ

        /// <summary>
        /// このコンバーターが JSON の読み取りに対応しているかどうかを示す真偽値を取得します。
        /// </summary>
        public override bool CanRead
        {
            get => false;
        }

        /// <summary>
        /// このコンバーターが JSON の書き込みに対応しているかどうかを示す真偽値を取得します。
        /// </summary>
        public override bool CanWrite
        {
            get => this._abstractTypeConverter.CanWrite;
        }


        // コンストラクタ

        /// <summary>
        /// 新しい <see cref="ConcretedTypeConverter{TTarget, TAbstractConverter}"/> クラスのインスタンスを初期化します．
        /// </summary>
        public ConcretedTypeConverter()
        {
            this._targetType = typeof(TTarget);
            this._abstractTypeConverter = new TAbstractConverter();
        }


        // 公開メソッド

        /// <summary>
        /// このコンバーターが、指定した <see cref="Type"/> の示す型に対応しているかどうかを判断します。
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return this._targetType.Equals(objectType);
        }

        /// <summary>
        /// JSON を読み込んで <see cref="TTarget"/> 型のインスタンスを生成します。
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定されたインスタンスを JSON へ変換し、書き込みます。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            this._abstractTypeConverter.WriteJson(writer, value, serializer);
        }
    }
}
