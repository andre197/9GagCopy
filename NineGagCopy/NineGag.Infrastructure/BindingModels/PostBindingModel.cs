namespace NineGag.Infrastructure.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostBindingModel
    {
        [Required]
        public string Title { get; set; }

        public byte[] Picture { get; set; }

        public string Url { get; set; }

        public string UserId { get; set; }
    }
}
