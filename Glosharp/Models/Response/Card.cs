using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Glosharp.Models.Response
{
    public class Card
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }
        
        [JsonProperty(PropertyName = "description")]
        public CardDescription Description { get; set; }
        
        [JsonProperty(PropertyName = "board_id")]
        public string BoardId { get; set; }
        
        [JsonProperty(PropertyName = "column_id")]
        public string ColumnId { get; set; }
        
        [JsonProperty(PropertyName = "created_date")]
        public string CreatedDate { get; set; }
        
        [JsonProperty(PropertyName = "updated_date")]
        public string UpdatedDate { get; set; }
        
        [JsonProperty(PropertyName = "archived_date")]
        public string ArchivedDate { get; set; }
        
        [JsonProperty(PropertyName = "assignees")]
        public List<PartialUser> Assignees { get; set; }
        
        [JsonProperty(PropertyName = "labels")]
        public List<Label> Labels { get; set; }
        
        [JsonProperty(PropertyName = "due_date")]
        public string DueDate { get; set; }
        
        [JsonProperty(PropertyName = "comment_count")]
        public int CommentCount { get; set; }
        
        [JsonProperty(PropertyName = "attachment_count")]
        public int AttachmentCount { get; set; }
        
        [JsonProperty(PropertyName = "completed_task_count")]
        public int CompletedTaskCount { get; set; }
        
        [JsonProperty(PropertyName = "total_task_count")]
        public int TotalTaskCount { get; set; }
        
        [JsonProperty(PropertyName = "created_by")]
        public PartialUser CreatedBy { get; set; }
    }
}