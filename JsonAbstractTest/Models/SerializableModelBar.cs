using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonAbstractTest.Converters;

namespace JsonAbstractTest.Models
{
    /// <summary>
    /// <see cref="ISerializableSample"/> クラスを継承するモデル クラスの例です。
    /// </summary>
    public class SerializableModelBar : ISerializableSample
    {
        // 非公開フィールド
        private string typeName;
        private string barContent;
        

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
        /// <see cref="SerializableModelBar"/> クラスのみが持つプロパティです。
        /// </summary>
        public string BarContent
        {
            get => this.barContent;
            set => this.barContent = value;
        }


        // コンストラクタ

        /// <summary>
        /// 新しい <see cref="SerializableModelBar"/> クラスのインスタンスを初期化します。
        /// </summary>
        public SerializableModelBar()
        {
            this.typeName = nameof(SerializableModelBar);
        }


        // 静的コンストラクタ

        /// <summary>
        /// <see cref="SerializableModelBar"/> クラスを初期化します。
        /// </summary>
        static SerializableModelBar()
        {
            SerializableSampleConverter.RegistSupportType(typeof(SerializableModelBar));
        }
    }
}