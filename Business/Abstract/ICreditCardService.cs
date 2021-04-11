using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<CreditCard> GetById(int id);

        IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId);

        IResult Add(CreditCard creditCard);

        IResult Delete(CreditCard creditCard);
    }
}
