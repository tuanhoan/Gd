using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Importation.Definition;

namespace GD.Data.Services
{
    public interface IValidator<T>
    {
        Task<List<ValidationResult>> ValidateAsync(T entity, OperationTypes operation, string userName);
    }

    //public interface IBatchValidator<T>
    //{
    //    Task ValidateAsync(IndexModel<T>[] items, OperationTypes operation, string userName, CancellationToken cancellationToken = default);
    //}


    public interface IHeaderDetailValidator<THeader, TDetail>
    {
        Task<List<ValidationResult>> ValidateAsync(THeader header, OperationTypes operation, string userName);
        Task<List<ValidationResult>> ValidateAsync(THeader header, TDetail detail, OperationTypes operation, string userName);
    }

    ///
    /// usage: Use enumValue.HasFlag(OperationTypes.Create),... to check value
    ///
    [Flags]
    public enum OperationTypes
    {
        None = 0,
        Create = 1,
        Update = 2,
        Delete = 3,
    }
}
