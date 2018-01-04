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
    /// シリアライズ可能なモデルのインターフェイスを定義します。
    /// </summary>
    [JsonConverter(typeof(SerializableSampleConverter))]
    public interface ISerializableSample
    {
        // プロパティ

        /// <summary>
        /// 具体型の名前を取得します。
        /// </summary>
        string TypeName
        {
            get;
        }
    }
}
