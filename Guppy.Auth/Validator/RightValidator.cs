namespace Guppy.Auth.Validator
{
    using Contracts.Validator;
    using Models;
    using Guppy.Contracts;
    using FluentValidation;

    class RightValidator : BaseValidator<RightDataModel>, IRightValidator
    {
        private IDal<RightDataModel> dal;

        public RightValidator(IDal<RightDataModel> dal)
        {
            this.dal = dal;

            RuleFor(model => model.Name).NotEmpty().WithMessage("Please supply a right name");
            RuleFor(model => model.Name).Must(NotBeInUse).WithMessage("Name already in use");
        }
           

        /// <summary>
        /// Nots the be in use.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="arg">The argument.</param>
        /// <returns></returns>
        private bool NotBeInUse(RightDataModel item, string arg)
        {
            var rtn = true; 
            if (item.IsNew)
            {
                rtn = (dal.Get(x => x.Name == item.Name, null) == null);
            }
            else
            {
                rtn = (dal.Get(x => x.Name == item.Name && x.Id != item.Id, null) == null);
            }

            return rtn;
        }
    }

}