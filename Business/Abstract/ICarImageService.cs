using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService 
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetById(int id);
        IResult Add(CarImage entity);
        IResult Update(CarImage entity);
        IResult Delete(CarImage entity);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
    }
}
