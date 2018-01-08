namespace NineGag.Infrastructure.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentBindingModel
    {
        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }
    }
}
