﻿using RentACar.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RentACar.Business.Abstract
{
    public interface IBrandService
    {

        IDataResult<IQueryable<Brand>> GetAllBrands();
        Task<IDataResult<Brand>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Brand brand);
        Task<IResult> UpdateAsync(Brand brand);
        Task<IResult> DeleteAsync(Brand brand);

    }
}
