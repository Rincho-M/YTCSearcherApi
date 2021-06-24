namespace YTCSearcherApi.Models
{
    public class RequestDataModel
    {
        public string Text { get; set; }
        public int CommentsNum { get; set; }

        public override string ToString()
        {
            return $"{typeof(RequestDataModel)}\nText: {Text}\nCommentsNum: {CommentsNum}";
        }
    }
}
