using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YTCSearcherApi.Models
{
    public class RequestModel
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Text { get; set; }

        [Column(TypeName = "int")]
        public int CommentsNum { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan Time { get; set; }

        public RequestModel() { }

        public RequestModel(RequestDataModel data)
        {
            Text = data.Text;
            CommentsNum = data.CommentsNum;

            var datetime = DateTime.UtcNow;
            Date = datetime.Date;
            Time = datetime.TimeOfDay;
        }
    }
}