using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    [PrimaryKey(nameof(BookNameID), nameof(PageNumber),nameof(Line))]
    public class OCRBookLine
    {
        public int BookNameID { get; set; }

        public int PageNumber
        {
            get; set;
        }
        public int Line
        {
            get; set;
        }
        public string Text { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public BookName BookName { get; set; }
    }


}
