using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ContactsValidator : AbstractValidator<Contacts>
    {

        public ContactsValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.PhoneNumber1).NotEmpty();
        }

    }
}
