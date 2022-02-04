using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace YJKBooks.Entities
{
    public partial class Book
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Genre
        {
            Fiction,
            Fantasy,
            Classic,
            Romance,
            Drama, 
            SciFi,
            Tragedy,
            Philosophical,
            Modernist,
            MagicRealism,

        }

    }
}
