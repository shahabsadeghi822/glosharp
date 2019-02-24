using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Glosharp.Models.Response
{
    [JsonObject]
    public class Board
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "columns")]
        public List<BoardColumn> Columns { get; set; }

        [JsonProperty(PropertyName = "archived_columns")]
        public List<BoardColumn> ArchivedColumns { get; set; }

        [JsonProperty(PropertyName = "invited_members")]
        public List<BoardMember> InvitedMembers { get; set; }

        [JsonProperty(PropertyName = "members")]
        public List<BoardMember> Members { get; set; }

        [JsonProperty(PropertyName = "labels")]
        public List<Label> Labels { get; set; }

        [JsonProperty(PropertyName = "created_date")]
        public string CreatedDate { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public PartialUser CreatedBy { get; set; }

        [JsonProperty(PropertyName = "archived_date")]
        public string ArchivedDate { get; set; }


    }
}
