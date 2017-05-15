using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Core.Utilities;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Common
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class Validatable
    {
        protected IValidator _validator = null;
        protected IEnumerable<ValidationFailure> _validityErrors;

        [DataMember]
        public IEnumerable<ValidationFailure> ValidityErrors => _validityErrors;

        public virtual bool IsValid => (_validityErrors != null && _validityErrors.Any());

        protected virtual IValidator GetValidator()
        {
            return null;
        }

        public void Validate()
        {
            if (_validator == null) return;
            var results = _validator.Validate(this);
            _validityErrors = results.Errors;
        }
    }
}