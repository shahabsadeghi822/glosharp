using System.Reflection;

namespace Glosharp.Models.Response
{
    public class CardDescription
    {
        public string Text { get; set; }
        
        public string CreatedDate { get; set; }
        
        public string UpdatedDate { get; set; }
        
        public PartialUser CreatedBy { get; set; }
        
        public PartialUser UpdatedBy { get; set; }
    }
}