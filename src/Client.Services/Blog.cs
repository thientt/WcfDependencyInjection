using System.Runtime.Serialization;
using Core.Utilities;
using FluentValidation;

namespace Client.Entities
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class Blog : EntityBase
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Owner { get; set; }

        protected override IValidator GetValidator()
        {
            return new BlogValidator();
        }
    }

    internal class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Owner).NotEmpty();
            RuleFor(b => b.Id).GreaterThan(0);
        }
    }
}