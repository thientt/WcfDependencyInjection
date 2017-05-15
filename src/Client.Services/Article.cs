using System.Runtime.Serialization;
using Core.Utilities;
using FluentValidation;

namespace Client.Entities
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class Article : EntityBase
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Contents { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public int BlogId { get; set; }

        public int ContentLength => Contents.Length;

        protected override IValidator GetValidator()
        {
            return new ArticleValidator();
        }
    }

    //Validator class
    internal class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(a => a.Author).NotEmpty();
            RuleFor(a => a.BlogId).GreaterThan(0);
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.Contents).NotEmpty();
        }
    }
}