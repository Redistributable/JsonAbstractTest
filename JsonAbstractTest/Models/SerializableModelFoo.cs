using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using JsonAbstractTest.Converters;

namespace JsonAbstractTest.Models
{
    /// <summary>
    /// <see cref="ISerializableSample"/> クラスを継承するモデル クラスの例です。
    /// </summary>
    [JsonConverter(typeof(ConcretedTypeConverter<SerializableModelFoo, SerializableSampleConverter>))]
    public class SerializableModelFoo : ISerializableSample
    {
        // 非公開フィールド
        private string typeName;
        private string fooContent;
        private int fooIntegerValue;


        // 公開プロパティ

        /// <summary>
        /// 具体型の名前を取得します。
        /// </summary>
        public string TypeName
        {
            get => this.typeName;
        }

        /// <summary>
        /// Content を取得または設定します。(サンプル)
        /// <see cref="SerializableModelFoo"/> クラスのみが持つプロパティです。
        /// </summary>
        public string FooContent
        {
            get => this.fooContent;
            set => this.fooContent = value;
        }

        /// <summary>
        /// 数値を取得または設定します。(サンプル)
        /// <see cref="SerializableModelFoo"/> クラスのみが持つプロパティです。
        /// </summary>
        public int FooIntegerValue
        {
            get => this.fooIntegerValue;
            set => this.fooIntegerValue = value;
        }


        // コンストラクタ

        /// <summary>
        /// 新しい <see cref="SerializableModelFoo"/> クラスのインスタンスを初期化します。
        /// </summary>
        public SerializableModelFoo()
        {
            this.typeName = nameof(SerializableModelFoo);
        }


        // 静的コンストラクタ

        /// <summary>
        /// <see cref="SerializableModelFoo"/> クラスを初期化します。
        /// </summary>
        static SerializableModelFoo()
        {
            SerializableSampleConverter.RegistSupportType(typeof(SerializableModelFoo));
        }
    }
}
