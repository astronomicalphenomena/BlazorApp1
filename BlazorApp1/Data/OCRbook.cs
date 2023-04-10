using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Data
{
    [PrimaryKey(nameof(BookNameID), nameof(PageNumber))]
    public class OCRbook
    {

        public int BookNameID { get; set; }

        public int PageNumber
        {
            get; set;
        }
        [Column(TypeName = "varbinary(MAX)")]
        public PageJson Text { get; set; }

        public BookName BookName { get; set; }
    }

    public class PageJson
    {
        public List<Rec_Res> rec_res { get; set; }
        public List<List<float>> boxes { get; set; }
    }

    public class BookName
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<OCRbook> OCRbooks { get; }
    }

    [JsonArray]
    public class Rec_Res : List<string>
    {
        public string Text { get => this[0]; set => this[0] = value; }
    }
}
