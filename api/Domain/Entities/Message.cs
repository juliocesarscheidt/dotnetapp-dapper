using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entity
{
    [Table("message")]
    public class Message
    {
        [Dapper.Contrib.Extensions.KeyAttribute]
        [Display(Name = "id")]
        public int id { get; set; }

        [Display(Name = "user_id")]
        public int user_id { get; set; }

        [Display(Name = "content")]
        public string content { get; set; }

        [Display(Name = "created_at")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime created_at { get; set; }

        [Display(Name = "updated_at")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime updated_at { get; set; }

        [Display(Name = "deleted_at")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime deleted_at { get; set; }
    }
}
