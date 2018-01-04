using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonAbstractTest.Models
{
    /// <summary>
    /// 抽象型プロパティを持つモデルクラスを定義します。
    /// </summary>
    public class SerializableParent
    {
        // 非公開フィールド
        private string concreteValue;
        private ISerializableSample abstractValue;


        // 公開プロパティ

        /// <summary>
        /// <see cref="String"/> 型の値を取得または設定します。
        /// プロパティの定義の時点で型が具体化されているプロパティです。
        /// </summary>
        public string ConcreteValue
        {
            get => this.concreteValue;
            set => this.concreteValue = value;
        }

        /// <summary>
        /// <see cref="ISerializableSample"/> 互換型の値を取得または設定します。
        /// プロパティの定義の時点では、具体的な型が指定されていない抽象型プロパティです。
        /// </summary>
        public ISerializableSample AbstractValue
        {
            get => this.abstractValue;
            set => this.abstractValue = value;
        }


        // コンストラクタ

        /// <summary>
        /// 新しい <see cref="SerializableParent"/> クラスのインスタンスを初期化します。
        /// </summary>
        public SerializableParent()
        {
             // 実装なし
        }
    }
}
